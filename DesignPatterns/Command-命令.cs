using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern
{
    //命令模式属于对象的行为模式，命令模式把一个请求或操作封装到一个对象中，通过对命令的抽象化来使得发出命令的责任和执行命令的责任分隔开。命令模式的实现可以提供命令的撤销和恢复功能。具体的结构图如下所示。
    // 教官，负责调用命令对象执行请求
    public class Invoke
    {
        public Command _command;

        public Invoke(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Action();
        }
    }

    // 命令抽象类
    public abstract class Command
    {
        // 命令应该知道接收者是谁，所以有Receiver这个成员变量
        protected Receiver _receiver;

        public Command(Receiver receiver)
        {
            this._receiver = receiver;
        }

        // 命令执行方法
        public abstract void Action();
    }

    // 
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Action()
        {
            // 调用接收的方法，因为执行命令的是学生
            _receiver.Run1000Meters();
        }
    }

    // 命令接收者——学生
    public class Receiver
    {
        public void Run1000Meters()
        {
            Console.WriteLine("跑1000米");
        }
    }

    // 院领导
    class Program
    {
        static void Main(string[] args)
        {
            // 初始化Receiver、Invoke和Command
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoke i = new Invoke(c);

            // 院领导发出命令
            i.ExecuteCommand();
        }
    }
}
