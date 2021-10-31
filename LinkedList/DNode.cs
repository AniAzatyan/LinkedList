using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class DNode<T>
    {
        internal T _data;
        internal DNode<T> prev;
        internal DNode<T> next;
        
        public DNode(T data)
        {
            _data = data;
            prev = null;
            next = null;
        }
      
        public T Value
        {
            get { return _data; }
            set { _data = value; }
        }

    }
}
