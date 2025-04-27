using System.Collections;

namespace Stack_Generic;

public class Stack<T> : IEnumerable<T>
{
    private T[] list { get; set; }
    private int count { get; set; }
    private int capacity { get; set; }
    private int top { get; set; }
    public Stack()
    {
        this.capacity = 4;
        this.count = 0;
        list = new T[capacity];
    }

    public int Count
    {
        get { return this.count; }
        set { this.count = value; }
    }

    public int Capacity
    {
        get { return this.capacity; }
        set { this.capacity = value; }
    }

    public T this[int index]
    {
        get { return list[index]; }
        set { list[index] = value; }
    }

    private void Resize()
    {
        capacity *= 2;
        T[] newList = new T[capacity];
        for (int i = 0; i < count; i++)
        {
            newList[i] = list[i];
        }
        list = newList;
    }

    public void Push(T item)
    {
        if (count == capacity)
        {
            Resize();
        }
        list[count++] = item;
    }

    public T Pop()
    {
        T temp = list[count - 1];
        count--;
        return temp;
    }

    public T Peek()
    {
        return list[count - 1];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            yield return list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = count - 1; i >= 0; i--)
        {
            yield return list[i];
        }
    }


}
