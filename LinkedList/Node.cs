using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node<T>
    {
        public Node<T> next;
        public T _data;
        public Node(T data)
        {     _data = data;
               next = null;
        }
        public T Value
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}

