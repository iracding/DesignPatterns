using System;
using System.Collections.Generic;
using System.Text;

namespace 模板
{
    //　在现实生活中，有论文模板，简历模板等。在现实生活中，模板的概念是给定一定的格式，然后其他所有使用模板的人可以根据自己的需求去实现它。同样，模板方法也是这样的。
　　//模板方法模式是在一个抽象类中定义一个操作中的算法骨架，而将一些具体步骤实现延迟到子类中去实现。模板方法使得子类可以不改变算法结构的前提下，重新定义算法的特定步骤，从而达到复用代码的效果。具体的结构图如下所示。
    // 客户端调用
    class Client
    {
        static void Main(string[] args)
        {
            // 创建一个菠菜实例并调用模板方法
            Spinach spinach = new Spinach();
            spinach.CookVegetabel();
            Console.Read();
        }
    }

    public abstract class Vegetabel
    {
        // 模板方法，不要把模版方法定义为Virtual或abstract方法，避免被子类重写，防止更改流程的执行顺序
        public void CookVegetabel()
        {
            Console.WriteLine("抄蔬菜的一般做法");
            this.pourOil();
            this.HeatOil();
            this.pourVegetable();
            this.stir_fry();
        }

        // 第一步倒油
        public void pourOil()
        {
            Console.WriteLine("倒油");
        }

        // 把油烧热
        public void HeatOil()
        {
            Console.WriteLine("把油烧热");
        }

        // 油热了之后倒蔬菜下去，具体哪种蔬菜由子类决定
        public abstract void pourVegetable();

        // 开发翻炒蔬菜
        public void stir_fry()
        {
            Console.WriteLine("翻炒");
        }
    }

    // 菠菜
    public class Spinach : Vegetabel
    {

        public override void pourVegetable()
        {
            Console.WriteLine("倒菠菜进锅中");
        }
    }

    // 大白菜
    public class ChineseCabbage : Vegetabel
    {
        public override void pourVegetable()
        {
            Console.WriteLine("倒大白菜进锅中");
        }
    }
}
