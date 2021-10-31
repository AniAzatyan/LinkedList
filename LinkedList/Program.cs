using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------DoublyLinkedList----------------");
            _DoublyLinkedList<string> list = new _DoublyLinkedList<string>();
            list.InsertFront("Anna");
            list.InsertFront("Liana");
            list.InsertFront("Tatev");
            list.InsertFront("Diana");
            list.InsertFront("Nana");
            list.GetLastNode();
            DNode<string> a = list.Find("Liana");
            DNode<string> b = list.Find("Tatev");
            list.InsertAfter(a, "Suren");
            list.InsertBefore(b, "Karen");
            list.InsertLast("Davit");
            list.Remove("Nana");
            list.Contains("Karen");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        
            list.Reverse();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("----------------SinglyLinkedList----------------");
            _SinglyLinkedList<string> list1 = new _SinglyLinkedList<string>();
            list1.InsertFront("Anna");
            list1.InsertFront("Liana");
            list1.InsertFront("Diana");
            list1.InsertFront("Nana");
            list1.GetLastNode();
            Node<string> d = list1.Find("Liana");
            list1.InsertAfter(d, "Suren");
            list1.InsertLast("Davit");
            list1.Remove("Davit");
            list1.Remove("Nana");
            list1.Remove("Liana");
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            list1.Reverse();
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
