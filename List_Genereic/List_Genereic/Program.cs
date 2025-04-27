namespace List_Generic;

class Program
{
    static void Main(string[] args)
    {
        ListT<int> list = new ListT<int>();

        for (int i = 0; i < 10; i++)
        {
            list.Add(i);
        }
        for (int i = 0; i < 10; i++)
        {
            Console.Write(list[i] + " ");
        }
        list.Insert(0, 999);
        Console.WriteLine();
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }

        // foreach(int i in list)
    }
}
