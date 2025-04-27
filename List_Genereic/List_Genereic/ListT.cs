namespace List_Generic;
public class ListT<T> 
{
    private T[] list {get;set;}
    private int count {get;set;}
    private int capacity {get;set;}

    public ListT()
    {
        this.capacity = 4;
        this.count = 0;
        list = new T[capacity];
    }

    public int Count
    {
        get {return this.count;}
        set {this.count = value;}
    }

    public int Capacity
    {
        get {return this.capacity;}
        set {this.capacity = value;}
    }

    public T this[int index]
    {
        get {return list[index];}
        set {list[index] = value;}
    }

    private void Resize()
    {
        capacity *= 2;
        T[] newList = new T[capacity];
        for(int i = 0; i < count; i++)
        {
            newList[i] = list[i];
        }
        list = newList;
    }

    public void Add(T item)
    {
        if(capacity == count)
        {
            Resize();
        }
        list[count++] = item;
    }

    public void Remove(T item)
    {
        int index = -1;
        for(int i = 0; i < count; i++)
        {
            if(list[i].Equals(item))
            {
                index = i;
                break;
            }
        }
        if(index == -1) Console.WriteLine("There is no given item");


        for(int i = index; i < count - 1; i++)
        {
            list[i] = list[i + 1];
        }
        
        count--;        
    }

    public void RemoveAt(int index)
    {
        for(int i = index; i < count - 1; i++)
        {
            list[i] = list[i + 1];
        }
        count--;
    }

    public bool Contains(T item)
    {
        for(int i = 0; i < count; i++)
        {
            if(list[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void Insert(int index, T item)
    {
        count++;
        for(int i = count; i > index; i--)
        {
            list[i] = list[i - 1];
        }
        list[index] = item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i = 0; i < count; i++)
        {
            yield return list[i];
        }
    }
}
