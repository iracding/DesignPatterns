using System;
using System.Collections.Generic;
using System.Text;

namespace 原型模式
{
    //原型模式指的是通过给出一个原型对象来指明所要创建的对象类型，然后用复制的方法来创建出更多的同类型对象。其实现要点有：
    //给出一个原型对象。问：如何办到呢？答：很简单嘛，直接给出一个原型类就好了。
    //通过复制的方法来创建同类型对象。问：又是如何实现呢？答：.NET可以直接调用MemberwiseClone方法来实现浅拷贝
    ///火影忍者中鸣人的影分身和孙悟空的的变都是原型模式
    class Client
    {
        static void Main(string[] args)
        {
            // 孙悟空 原型
            MonkeyKingPrototype prototypeMonkeyKing = new ConcretePrototype("MonkeyKing");

            // 变一个
            MonkeyKingPrototype cloneMonkeyKing = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned1:\t" + cloneMonkeyKing.Id);

            // 变两个
            MonkeyKingPrototype cloneMonkeyKing2 = prototypeMonkeyKing.Clone() as ConcretePrototype;
            Console.WriteLine("Cloned2:\t" + cloneMonkeyKing2.Id);
            Console.ReadLine();
        }
    }

    /// <summary>
    /// 孙悟空原型
    /// </summary>
    public abstract class MonkeyKingPrototype
    {
        public string Id { get; set; }
        public MonkeyKingPrototype(string id)
        {
            this.Id = id;
        }

        // 克隆方法，即孙大圣说“变”
        public abstract MonkeyKingPrototype Clone();
    }

    /// <summary>
    /// 创建具体原型
    /// </summary>
    public class ConcretePrototype : MonkeyKingPrototype
    {
        public ConcretePrototype(string id)
            : base(id)
        { }

        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public override MonkeyKingPrototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (MonkeyKingPrototype)this.MemberwiseClone();
        }
    }
}
