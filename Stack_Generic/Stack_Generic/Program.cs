namespace Stack_Generic;

class Program
{
    static void Main(string[] args)
    {
        Stack<int> list = new Stack<int>();

        for(int i = 0; i < 10; i++)
        {// 0 1 2 3 4 5 6 7 8 9
            list.Push(i);
        }

        //Console.WriteLine(list.Pop());        
        for(int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
        //Console.WriteLine(list.Peek());
    
        foreach(int i in list)
        {
            Console.Write(i + " ");
        }

    }
}
