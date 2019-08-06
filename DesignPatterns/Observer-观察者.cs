﻿using System;
using System.Collections.Generic;
using System.Text;

namespace 观察者
{

    class Program
    {
        // 委托充当订阅者接口类
        public delegate void NotifyEventHandler(object sender);

        // 抽象订阅号类
        public class TenXun
        {
            public NotifyEventHandler NotifyEvent;

            public string Symbol { get; set; }
            public string Info { get; set; }
            public TenXun(string symbol, string info)
            {
                this.Symbol = symbol;
                this.Info = info;
            }

            #region 新增对订阅号列表的维护操作
            public void AddObserver(NotifyEventHandler ob)
            {
                NotifyEvent += ob;
            }
            public void RemoveObserver(NotifyEventHandler ob)
            {
                NotifyEvent -= ob;
            }

            #endregion

            public void Update()
            {
                if (NotifyEvent != null)
                {
                    NotifyEvent(this);
                }
            }
        }

        // 具体订阅号类
        public class TenXunGame : TenXun
        {
            public TenXunGame(string symbol, string info)
                : base(symbol, info)
            {
            }
        }

        // 具体订阅者类
        public class Subscriber
        {
            public string Name { get; set; }
            public Subscriber(string name)
            {
                this.Name = name;
            }

            public void ReceiveAndPrint(Object obj)
            {
                TenXun tenxun = obj as TenXun;

                if (tenxun != null)
                {
                    Console.WriteLine("Notified {0} of {1}'s" + " Info is: {2}", Name, tenxun.Symbol, tenxun.Info);
                }
            }
        }

        static void Main(string[] args)
        {
            TenXun tenXun = new TenXunGame("TenXun Game", "Have a new game published ....");
            Subscriber lh = new Subscriber("Learning Hard");
            Subscriber tom = new Subscriber("Tom");

            // 添加订阅者
            tenXun.AddObserver(new NotifyEventHandler(lh.ReceiveAndPrint));
            tenXun.AddObserver(new NotifyEventHandler(tom.ReceiveAndPrint));

            tenXun.Update();

            Console.WriteLine("-----------------------------------");
            Console.WriteLine("移除Tom订阅者");
            tenXun.RemoveObserver(new NotifyEventHandler(tom.ReceiveAndPrint));
            tenXun.Update();

            Console.ReadLine();
        }
    }

}
