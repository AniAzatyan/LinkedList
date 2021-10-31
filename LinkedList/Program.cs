using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            _DoublyLinkedList<string> list = new _DoublyLinkedList<string>();
            list.InsertFront("Anna");
            list.InsertFront("Liana");
            list.InsertFront("Diana");
            list.InsertFront("Nana");
            DNode<string> b = list.GetLastNode();
            DNode<string> a = list.Find("Liana");
            list.InsertAfter(a, "Suren");
            list.InsertLast("Davit");
            list.Remove("Nana");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            _SinglyLinkedList<string> list1 = new _SinglyLinkedList<string>();
            list1.InsertFront("Anna");
            list1.InsertFront("Liana");
            list1.InsertFront("Diana");
            list1.InsertFront("Nana");
            Node<string> c = list1.GetLastNode();
            Node<string> d = list1.Find("Liana");
            list1.InsertAfter(d, "Suren");
            list1.InsertLast("Davit");
            //list1.Remove("Liana");
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
