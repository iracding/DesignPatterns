using System;
using System.Collections.Generic;
using System.Text;

namespace 策略者模式
{
    //　在现实生活中，中国的所得税，分为企业所得税、外商投资企业或外商企业所得税和个人所得税，针对于这3种所得税，每种所计算的方式不同，个人所得税有个人所得税的计算方式，而企业所得税有其对应计算方式。如果不采用策略模式来实现这样一个需求的话，
    //我们会定义一个所得税类，该类有一个属性来标识所得税的类型，并且有一个计算税收的CalculateTax()方法，在该方法体内需要对税收类型进行判断，通过if-else语句来针对不同的税收类型来计算其所得税。这样的实现确实可以解决这个场景，但是这样的设计不利于扩展，
    //如果系统后期需要增加一种所得税时，此时不得不回去修改CalculateTax方法来多添加一个判断语句，这样明白违背了“开放——封闭”原则。此时，我们可以考虑使用策略模式来解决这个问题，既然税收方法是这个场景中的变化部分，此时自然可以想到对税收方法进行抽象，
    //这也是策略模式实现的精髓所在。
    //策略模式是对算法的包装，是把使用算法的责任和算法本身分割开，委派给不同的对象负责。策略模式通常把一系列的算法包装到一系列的策略类里面。用一句话慨括策略模式就是——“将每个算法封装到不同的策略类中，使得它们可以互换”。
    // 所得税计算策略
    public interface ITaxStragety
    {
        double CalculateTax(double income);
    }

    // 个人所得税
    public class PersonalTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }

    // 企业所得税
    public class EnterpriseTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }

    public class InterestOperation
    {
        private ITaxStragety m_strategy;
        public InterestOperation(ITaxStragety strategy)
        {
            this.m_strategy = strategy;
        }

        public double GetTax(double income)
        {
            return m_strategy.CalculateTax(income);
        }
    }

    class App
    {
        static void Main(string[] args)
        {
            // 个人所得税方式
            InterestOperation operation = new InterestOperation(new PersonalTaxStrategy());
            Console.WriteLine("个人支付的税为：{0}", operation.GetTax(5000.00));

            // 企业所得税
            operation = new InterestOperation(new EnterpriseTaxStrategy());
            Console.WriteLine("企业支付的税为：{0}", operation.GetTax(50000.00));

            Console.Read();
        }
    }

}
