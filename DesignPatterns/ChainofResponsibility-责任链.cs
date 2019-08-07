using System;
using System.Collections.Generic;
using System.Text;

namespace 责任链
{
    //在现实生活中，有很多请求并不是一个人说了就算的，例如面试时的工资，低于1万的薪水可能技术经理就可以决定了，但是1万~1万5的薪水可能技术经理就没这个权利批准，可能需要请求技术总监的批准。
    //责任链模式——某个请求需要多个对象进行处理，从而避免请求的发送者和接收之间的耦合关系。将这些对象连成一条链子，并沿着这条链子传递该请求，直到有对象处理它为止。具体结构图如下所示：

    namespace ChainofResponsibility
    {
        // 采购请求
        public class PurchaseRequest
        {
            // 金额
            public double Amount { get; set; }
            // 产品名字
            public string ProductName { get; set; }
            public PurchaseRequest(double amount, string productName)
            {
                Amount = amount;
                ProductName = productName;
            }
        }

        // 审批人,Handler
        public abstract class Approver
        {
            public Approver NextApprover { get; set; }
            public string Name { get; set; }
            public Approver(string name)
            {
                this.Name = name;
            }
            public abstract void ProcessRequest(PurchaseRequest request);
        }

        // ConcreteHandler
        public class Manager : Approver
        {
            public Manager(string name)
                : base(name)
            { }

            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 10000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler,副总
        public class VicePresident : Approver
        {
            public VicePresident(string name)
                : base(name)
            {
            }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 25000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else if (NextApprover != null)
                {
                    NextApprover.ProcessRequest(request);
                }
            }
        }

        // ConcreteHandler，总经理
        public class President : Approver
        {
            public President(string name)
                : base(name)
            { }
            public override void ProcessRequest(PurchaseRequest request)
            {
                if (request.Amount < 100000.0)
                {
                    Console.WriteLine("{0}-{1} approved the request of purshing {2}", this, Name, request.ProductName);
                }
                else
                {
                    Console.WriteLine("Request需要组织一个会议讨论");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                PurchaseRequest requestTelphone = new PurchaseRequest(4000.0, "Telphone");
                PurchaseRequest requestSoftware = new PurchaseRequest(10000.0, "Visual Studio");
                PurchaseRequest requestComputers = new PurchaseRequest(40000.0, "Computers");

                Approver manager = new Manager("LearningHard");
                Approver Vp = new VicePresident("Tony");
                Approver Pre = new President("BossTom");

                // 设置责任链
                manager.NextApprover = Vp;
                Vp.NextApprover = Pre;

                // 处理请求
                manager.ProcessRequest(requestTelphone);
                manager.ProcessRequest(requestSoftware);
                manager.ProcessRequest(requestComputers);
                Console.ReadLine();
            }
        }
    }
}
