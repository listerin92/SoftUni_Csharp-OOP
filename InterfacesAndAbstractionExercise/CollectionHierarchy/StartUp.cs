using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split(' ');
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myListCollection = new MyList();
            IItem addRemoveCollectionItem = null;
            IItem myListCollectionItem = null;
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                IItem addCollectionItem = new AddCollection(cmdArgs[i]);
                Console.Write(addCollection.Add(addCollectionItem) + " ");

            }

            Console.WriteLine();
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                addRemoveCollectionItem = new AddRemoveCollection(cmdArgs[i]);
                Console.Write(addRemoveCollection.Add(addRemoveCollectionItem) + " ");
            }

            Console.WriteLine();
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                myListCollectionItem = new MyList(cmdArgs[i]);
                Console.Write(myListCollection.Add(myListCollectionItem) + " ");
            }

            Console.WriteLine();
            int numberOfRemoves = int.Parse(Console.ReadLine());
            for (int i = 0; i <= numberOfRemoves - 1; i++)
            {

                Console.Write(addRemoveCollection.Remove() + " ");
            }

            Console.WriteLine();
            for (int i = 0; i <= numberOfRemoves - 1; i++)
            {
                Console.Write(myListCollection.Remove() + " ");
            }
        }
    }
}