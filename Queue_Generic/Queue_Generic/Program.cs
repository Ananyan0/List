namespace Queue_Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<int> list = new Queue<int>();

        for (int i = 0; i < 10; i++)
        {// 0 1 2 3 4 5 6 7 8 9
            list.Enqueue(i);
        }
        list.Dequeue();
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }

    }
}
