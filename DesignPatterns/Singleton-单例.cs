using System;
using System.Threading;

namespace 单例模式
{
    //　单例模式指的是确保某一个类只有一个实例，并提供一个全局访问点。解决的是实体对象个数的问题，而其他的建造者模式都是解决new所带来的耦合关系问题。其实现要点有：
    //类只有一个实例。问：如何保证呢？答：通过私有构造函数来保证类外部不能对类进行实例化
    //提供一个全局的访问点。问：如何实现呢？答：创建一个返回该类对象的静态方法
    //单例模式的结构图如下所示：
    /// <summary>
    /// 单例模式的实现
    /// </summary>
    public class Singleton
    {
        // 定义一个静态变量来保存类的实例
        private static Singleton uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private Singleton()
        {
        }

        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            //当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new Singleton();
                    }
                }
            }
            return uniqueInstance;
            //if (uniqueInstance == null)
            //{
            //    Interlocked.CompareExchange<Singleton>(ref uniqueInstance, new Singleton(), null);
            //}
            //return uniqueInstance;
        }
    }
}
