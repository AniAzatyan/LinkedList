using System;
using System.Collections;
using System.Collections.Generic;


namespace LinkedList
{
    public class _SinglyLinkedList<T> : IEnumerable<T>
    {
        internal Node<T> head;
        internal int count;
        public int Count
        {
            get { return count; }
        }

        public Node<T> First
        {
            get { return head; }
        }
        public void InsertAfter(Node<T> prev_node, T new_data)
        {
            if (prev_node == null)
            {
                Console.WriteLine("The given previous node Cannot be null");
                return;
            }
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
        }
        public void InsertFront(T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            new_node.next = head;
            head = new_node;
        }
        internal void InsertLast(T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);
            if (head == null)
            {
                head = new_node;
                return;
            }
            Node<T> lastNode = GetLastNode();
            lastNode.next = new_node;
        }
        internal Node<T> GetLastNode()
        {
            Node<T> temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            return temp;
        }
        //public bool Remove(T value)
        //{
        //    Node<T> node = Find(value);
        //    if (node != null)
        //    {
        //        InternalRemoveNode(node);
        //        return true;
        //    }
        //    return false;
        //}
        //internal void InternalRemoveNode(Node<T> node)
        //{
        //    if (node.next == node)
        //    {
        //        head = null;
        //    }
        //    else
        //    {
        //        node.next.prev = node.prev;
        //        node.prev.next = node.next;
        //        if (head == node)
        //        {
        //            head = node.next;
        //        }
        //    }
        //    count--;
        //}
        public Node<T> Find(T value)
        {
            Node<T> node = head;
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
        public void ReverseLinkedList()
        {
            Node<T> prev = null;
            Node<T> current = head;
            Node<T> temp = null;
            while (current != null)
            {
                temp = current.next;
                current.next = prev;
                prev = current;
                current = temp;
            }
            head = prev;
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
            private _SinglyLinkedList<T> list;
            private Node<T> node;
            private T current;
            private int index;

            internal Enumerator(_SinglyLinkedList<T> list)
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
