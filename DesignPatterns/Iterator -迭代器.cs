using System;
using System.Collections.Generic;
using System.Text;

namespace 迭代器模
{
    //　迭代器模式是针对集合对象而生的，对于集合对象而言，必然涉及到集合元素的添加删除操作，也肯定支持遍历集合元素的操作，此时如果把遍历操作也放在集合对象的话，集合对象就承担太多的责任了，此时可以进行责任分离，把集合的遍历放在另一个对象中，这个对象就是迭代器对象。
    //迭代器模式提供了一种方法来顺序访问一个集合对象中各个元素，而又无需暴露该对象的内部表示，这样既可以做到不暴露集合的内部结构，又可以让外部代码透明地访问集合内部元素
    // 抽象聚合类
    public interface IListCollection
    {
        Iterator GetIterator();
    }

    // 迭代器抽象类
    public interface Iterator
    {
        bool MoveNext();
        Object GetCurrent();
        void Next();
        void Reset();
    }

    // 具体聚合类
    public class ConcreteList : IListCollection
    {
        int[] collection;
        public ConcreteList()
        {
            collection = new int[] { 2, 4, 6, 8 };
        }

        public Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public int GetElement(int index)
        {
            return collection[index];
        }
    }

    // 具体迭代器类
    public class ConcreteIterator : Iterator
    {
        // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteList _list;
        private int _index;

        public ConcreteIterator(ConcreteList list)
        {
            _list = list;
            _index = 0;
        }


        public bool MoveNext()
        {
            if (_index < _list.Length)
            {
                return true;
            }
            return false;
        }

        public Object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }

        }
    }

    // 客户端
    class Program
    {
        static void Main(string[] args)
        {
            Iterator iterator;
            IListCollection list = new ConcreteList();
            iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }

            Console.Read();
        }
    }
}
