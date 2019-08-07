using System;
using System.Collections.Generic;
using System.Text;

namespace 抽象工厂
{
    //　　抽象工厂模式指的是提供一个创建一系列相关或相互依赖对象的接口，使得客户端可以在不必指定产品的具体类型的情况下，创建多个产品族中的产品对象，强调的是”系列对象“的变化。其实现要点有：
    //•	提供一系列对象的接口。问：如何去实现呢？答：提供多个产品的抽象接口
    //•	创建多个产品族中的多个产品对象。问：如何做到呢？答：每个具体工厂创建一个产品族中的多个产品对象，多个具体工厂就可以创建多个产品族中的多个对象了。

    /// <summary>
    /// 下面以绝味鸭脖连锁店为例子演示下抽象工厂模式
    /// 因为每个地方的喜欢的口味不一样，有些地方喜欢辣点的，有些地方喜欢吃不辣点
    /// 客户端调用
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 南昌工厂制作南昌的鸭脖和鸭架
            AbstractFactory nanChangFactory = new NanChangFactory();
            YaBo nanChangYabo = nanChangFactory.CreateYaBo();
            nanChangYabo.Print();
            YaJia nanChangYajia = nanChangFactory.CreateYaJia();
            nanChangYajia.Print();

            // 上海工厂制作上海的鸭脖和鸭架
            AbstractFactory shangHaiFactory = new ShangHaiFactory();
            shangHaiFactory.CreateYaBo().Print();
            shangHaiFactory.CreateYaJia().Print();

            Console.Read();
        }
    }

    /// <summary>
    /// 抽象工厂类，提供创建两个不同地方的鸭架和鸭脖的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        // 抽象工厂提供创建一系列产品的接口，这里作为例子，只给出了绝味中鸭脖和鸭架的创建接口
        public abstract YaBo CreateYaBo();
        public abstract YaJia CreateYaJia();
    }

    /// <summary>
    /// 南昌绝味工厂负责制作南昌的鸭脖和鸭架
    /// </summary>
    public class NanChangFactory : AbstractFactory
    {
        // 制作南昌鸭脖
        public override YaBo CreateYaBo()
        {
            return new NanChangYaBo();
        }
        // 制作南昌鸭架
        public override YaJia CreateYaJia()
        {
            return new NanChangYaJia();
        }
    }

    /// <summary>
    /// 上海绝味工厂负责制作上海的鸭脖和鸭架
    /// </summary>
    public class ShangHaiFactory : AbstractFactory
    {
        // 制作上海鸭脖
        public override YaBo CreateYaBo()
        {
            return new ShangHaiYaBo();
        }
        // 制作上海鸭架
        public override YaJia CreateYaJia()
        {
            return new ShangHaiYaJia();
        }
    }

    /// <summary>
    /// 鸭脖抽象类，供每个地方的鸭脖类继承
    /// </summary>
    public abstract class YaBo
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 鸭架抽象类，供每个地方的鸭架类继承
    /// </summary>
    public abstract class YaJia
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 南昌的鸭脖类，因为江西人喜欢吃辣的，所以南昌的鸭脖稍微会比上海做的辣
    /// </summary>
    public class NanChangYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭脖");
        }
    }

    /// <summary>
    /// 上海的鸭脖没有南昌的鸭脖做的辣
    /// </summary>
    public class ShangHaiYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭脖");
        }
    }

    /// <summary>
    /// 南昌的鸭架
    /// </summary>
    public class NanChangYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("南昌的鸭架子");
        }
    }

    /// <summary>
    /// 上海的鸭架
    /// </summary>
    public class ShangHaiYaJia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("上海的鸭架子");
        }
    }
    /// <summary>
    /// 如果绝味又想开一家湖南的分店时，因为湖南喜欢吃麻的
    /// 所以这是有需要有一家湖南的工厂专门制作
    /// </summary>
    public class HuNanFactory : AbstractFactory
    {
        // 制作湖南鸭脖
        public override YaBo CreateYaBo()
        {
            return new HuNanYaBo();
        }

        // 制作湖南鸭架
        public override YaJia CreateYaJia()
        {
            return new HuNanYajia();
        }
    }

    /// <summary>
    /// 湖南的鸭脖
    /// </summary>
    public class HuNanYaBo : YaBo
    {
        public override void Print()
        {
            Console.WriteLine("湖南的鸭脖");
        }
    }

    /// <summary>
    /// 湖南的鸭架
    /// </summary>
    public class HuNanYajia : YaJia
    {
        public override void Print()
        {
            Console.WriteLine("湖南的鸭架子");
        }
    }
}
