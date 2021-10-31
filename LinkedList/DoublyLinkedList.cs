using System;
using System.Collections;
using System.Collections.Generic;


namespace LinkedList
{
    public class _DoublyLinkedList<T> : IEnumerable<T>
    {
        internal DNode<T> head;
        internal int count;

        public int Count
        {
            get { return count; }
        }
        public DNode<T> First
        {
            get { return head; }
        }
        public void InsertFront(T data)
        {
            DNode<T> newNode = new DNode<T>(data);
            newNode.next = head;
            newNode.prev = null;
            if (head != null)
            {
                head.prev = newNode;
            }
            head = newNode;
            count++;
        }
        public void InsertLast(T data)
        {
            DNode<T> newNode = new DNode<T>(data);
            if (head == null)
            {
                newNode.prev = null;
                head = newNode;
                return;
            }
            DNode<T> lastNode = GetLastNode();
            lastNode.next = newNode;
            newNode.prev = lastNode;
            count++;
        }
        public void InsertAfter(DNode<T> prev_node, T data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given prevoius node cannot be null");
                return;
            }
            DNode<T> newNode = new DNode<T>(data);
            newNode.next = prev_node.next;
            prev_node.next = newNode;
            newNode.prev = prev_node;
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
            count++;
        }
        public void InsertBefore(DNode<T> next_node, T data)
        {
            if (next_node == null)
            {
                Console.WriteLine("The given next node cannot be null");
                return;
            }
            DNode<T> newNode = new DNode<T>(data);
            //newNode.next = prev_node.next;
            //prev_node.next = newNode;
            //newNode.prev = prev_node;

            newNode.next = next_node;
            newNode.prev = next_node.prev;
            next_node.prev.next = newNode;
            next_node.prev = newNode;
            count++;
            if (next_node == head)
            {
                head = newNode;
            }
        }
        public DNode<T> GetLastNode()
        {
            DNode<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        public DNode<T> Find(T value)
        {
            DNode<T> node = head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node._data, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
                else
                {
                    do
                    {
                        if (node._data == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != head);
                }
            }
            return null;
        }
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        public void InternalRemoveNode(DNode<T> node)
        {
            
            if (node.next == node)
            {
                head = null;
            }
            else if (node == head)
            {
                head = node.next;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (head == node)
                {
                    head = node.next;
                }
            }
            count--;

        }
        public bool Remove(T value)
        {
            DNode<T> node = Find(value);
            if (node != null)
            {
                InternalRemoveNode(node);
                return true;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public struct Enumerator : IEnumerator<T>
        {
            private _DoublyLinkedList<T> list;
            private DNode<T> node;
            private T current;
            private int index;

            internal Enumerator(_DoublyLinkedList<T> list)
            {
                this.list = list;
                node = list.head;
                current = default(T);
                index = 0;
            }

            public T Current
            {
                get { return current; }
            }

            object System.Collections.IEnumerator.Current
            {
                get
                {
                 return current;
                }
            }

            public bool MoveNext()
            {
                if (node == null)
                {
                    index = list.Count + 1;
                    return false;
                }

                ++index;
                current = node._data;
                node = node.next;
                if (node == list.head)
                {
                    node = null;
                }
                return true;
            }

            void System.Collections.IEnumerator.Reset()
            {
                current = default(T);
                node = list.head;
                index = 0;
            }

            public void Dispose()
            {
            }

        }
    }

}

