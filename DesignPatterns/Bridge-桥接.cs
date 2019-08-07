using System;
using System.Collections.Generic;
using System.Text;

namespace 桥接1
{
    // 桥接模式旨在将抽象化与实现化解耦，使得两者可以独立地变化。意思就是说，桥接模式把原来基类的实现化细节再进一步进行抽象，构造到一个实现化的结构中，然后再把原来的基类改造成一个抽象化的等级结构，这样就可以实现系统在多个维度的独立变化，桥接模式的结构图如下所示。
    /// <summary>
    /// 电视机，提供抽象方法
    /// </summary>
    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void tuneChannel();
    }

    /// <summary>
    /// 长虹牌电视机，重写基类的抽象方法
    /// 提供具体的实现
    /// </summary>
    public class ChangHong : TV
    {
        public override void On()
        {
            Console.WriteLine("长虹牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("长虹牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("长虹牌电视机换频道");
        }
    }

    /// <summary>
    /// 三星牌电视机，重写基类的抽象方法
    /// </summary>
    public class Samsung : TV
    {
        public override void On()
        {
            Console.WriteLine("三星牌电视机已经打开了");
        }

        public override void Off()
        {
            Console.WriteLine("三星牌电视机已经关掉了");
        }

        public override void tuneChannel()
        {
            Console.WriteLine("三星牌电视机换频道");
        }
    }
    /// <summary>
    /// 抽象概念中的遥控器，扮演抽象化角色
    /// </summary>
    public class RemoteControl
    {
        // 字段
        private TV implementor;

        // 属性
        public TV Implementor
        {
            get { return implementor; }
            set { implementor = value; }
        }

        /// <summary>
        /// 开电视机，这里抽象类中不再提供实现了，而是调用实现类中的实现
        /// </summary>
        public virtual void On()
        {
            implementor.On();
        }

        /// <summary>
        /// 关电视机
        /// </summary>
        public virtual void Off()
        {
            implementor.Off();
        }

        /// <summary>
        /// 换频道
        /// </summary>
        public virtual void SetChannel()
        {
            implementor.tuneChannel();
        }
    }

    /// <summary>
    /// 具体遥控器
    /// </summary>
    public class ConcreteRemote : RemoteControl
    {
        public override void SetChannel()
        {
            Console.WriteLine("---------------------");
            base.SetChannel();
            Console.WriteLine("---------------------");
        }
    }
    /// <summary>
    /// 以电视机遥控器的例子来演示桥接模式
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            // 创建一个遥控器
            RemoteControl remoteControl = new ConcreteRemote();
            // 长虹电视机
            remoteControl.Implementor = new ChangHong();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.WriteLine();

            // 三星牌电视机
            remoteControl.Implementor = new Samsung();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            Console.Read();
        }
    }
}
namespace 桥接2
{
    // 客户端调用
    // 类似Web应用程序
    class Client
    {
        static void Main(string[] args)
        {
            BusinessObject customers = new CustomersBusinessObject("ShangHai");
            customers.Dataacces = new CustomersDataAccess();

            customers.Add("小六");
            Console.WriteLine("增加了一位成员的结果：");
            customers.ShowAll();
            customers.Delete("王五");
            Console.WriteLine("删除了一位成员的结果：");
            customers.ShowAll();
            Console.WriteLine("更新了一位成员的结果：");
            customers.Update("Learning_Hard");
            customers.ShowAll();

            Console.Read();
        }
    }

    // BLL 层
    public class BusinessObject
    {
        // 字段
        private DataAccess dataacess;
        private string city;

        public BusinessObject(string city)
        {
            this.city = city;
        }

        // 属性
        public DataAccess Dataacces
        {
            get { return dataacess; }
            set { dataacess = value; }
        }

        // 方法
        public virtual void Add(string name)
        {
            Dataacces.AddRecord(name);
        }

        public virtual void Delete(string name)
        {
            Dataacces.DeleteRecord(name);
        }

        public virtual void Update(string name)
        {
            Dataacces.UpdateRecord(name);
        }

        public virtual string Get(int index)
        {
            return Dataacces.GetRecord(index);
        }
        public virtual void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0}的顾客有：", city);
            Dataacces.ShowAllRecords();
        }
    }

    public class CustomersBusinessObject : BusinessObject
    {
        public CustomersBusinessObject(string city)
            : base(city) { }

        // 重写方法
        public override void ShowAll()
        {
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    /// <summary>
    /// 相当于三层架构中数据访问层（DAL）
    /// </summary>
    public abstract class DataAccess
    {
        // 对记录的增删改查操作
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void UpdateRecord(string name);
        public abstract string GetRecord(int index);
        public abstract void ShowAllRecords();
    }

    public class CustomersDataAccess : DataAccess
    {
        // 字段
        private List<string> customers = new List<string>();

        public CustomersDataAccess()
        {
            // 实际业务中从数据库中读取数据再填充列表
            customers.Add("Learning Hard");
            customers.Add("张三");
            customers.Add("李四");
            customers.Add("王五");
        }
        // 重写方法
        public override void AddRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            customers.Remove(name);
        }

        public override void UpdateRecord(string updatename)
        {
            customers[0] = updatename;
        }

        public override string GetRecord(int index)
        {
            return customers[index];
        }

        public override void ShowAllRecords()
        {
            foreach (string name in customers)
            {
                Console.WriteLine(" " + name);
            }
        }

    }
}
