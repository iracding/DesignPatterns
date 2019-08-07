using System;
using System.Collections.Generic;
using System.Text;

namespace 外观
{
    //在系统中，客户端经常需要与多个子系统进行交互，这样导致客户端会随着子系统的变化而变化，此时可以使用外观模式把客户端与各个子系统解耦。外观模式指的是为子系统中的一组接口提供一个一致的门面，它提供了一个高层接口，这个接口使子系统更加容易使用。如电信的客户专员，你可以让客户专员来完成冲话费，修改套餐等业务，而不需要自己去与各个子系统进行交互。具体类结构图如下所示：
    /// <summary>
    /// 以学生选课系统为例子演示外观模式的使用
    /// 学生选课模块包括功能有：
    /// 验证选课的人数是否已满
    /// 通知用户课程选择成功与否
    /// 客户端代码
    /// </summary>
    class Student
    {
        private static RegistrationFacade facade = new RegistrationFacade();

        static void Main(string[] args)
        {
            if (facade.RegisterCourse("设计模式", "Learning Hard"))
            {
                Console.WriteLine("选课成功");
            }
            else
            {
                Console.WriteLine("选课失败");
            }

            Console.Read();
        }
    }

    // 外观类
    public class RegistrationFacade
    {
        private RegisterCourse registerCourse;
        private NotifyStudent notifyStu;
        public RegistrationFacade()
        {
            registerCourse = new RegisterCourse();
            notifyStu = new NotifyStudent();
        }

        public bool RegisterCourse(string courseName, string studentName)
        {
            if (!registerCourse.CheckAvailable(courseName))
            {
                return false;
            }

            return notifyStu.Notify(studentName);
        }
    }

    #region 子系统
    // 相当于子系统A
    public class RegisterCourse
    {
        public bool CheckAvailable(string courseName)
        {
            Console.WriteLine("正在验证课程 {0}是否人数已满", courseName);
            return true;
        }
    }

    // 相当于子系统B
    public class NotifyStudent
    {
        public bool Notify(string studentName)
        {
            Console.WriteLine("正在向{0}发生通知", studentName);
            return true;
        }
    }
    #endregion
}
