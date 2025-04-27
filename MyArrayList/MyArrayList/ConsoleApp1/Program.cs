using System.Collections;


namespace MyArrayList;

class MyArrayList : IEnumerable, IComparer
{
    private Object[] _items { get; set; }
    private int _size { get; set; }
    private int _capacity { get; set; }

    public MyArrayList()
    {
        _size = 0;
        _capacity = 4;
        _items = new Object[_capacity];
    }

    public IEnumerator GetEnumerator()
    {
        for (int i = 0; i < _size; i++)
        {
            yield return _items[i];
        }
    }

    public int Compare(object obj1, object obj2)
    {
        if (obj1 == obj2) return 0;
        if (obj1 == null) return -1;
        if (obj2 == null) return 1;


        if (obj1 is int int1 && obj2 is int int2)
        {
            return int1.CompareTo(int2);
        }

        if (obj1 is double double1 && obj2 is double double2)
        {
            return double1.CompareTo(double2);
        }

        if (obj1 is string string1 && obj2 is string string2)
        {
            return string1.CompareTo(string2);
        }
        return obj1.ToString().CompareTo(obj2.ToString());

        throw new ArgumentException("Objects are not of type int");
    }


    public int BinarySearch(object? value, System.Collections.IComparer? comparer)
    {
        int left = 0;
        int right = Size - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            Object midValue = _items[mid];
            int comparision = comparer.Compare(midValue, value);

            if (comparision == 0)
            {
                return mid;
            }
            else if (comparision < 0)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return -1;
    }

    public int Size
    {
        get { return _size; }
    }

    public Object this[int index]
    {
        get
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            return _items[index];
        }
        set
        {
            if (index < 0 || index >= _size)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            _items[index] = value;
        }
    }

    private void Resize()
    {
        _capacity *= 2;
        Object[] newItems = new Object[_capacity];
        for (int i = 0; i < _size; i++)
        {
            newItems[i] = _items[i];
        }
        _items = newItems;
    }

    public void Add(Object item)
    {
        if (_size == _capacity)
        {
            Resize();
        }
        _items[_size++] = item;
    }

    public void Remove(Object item)
    {
        int index = -1;

        for (int i = 0; i < _size; i++)
        {
            if (_items[i].Equals(item))
            {
                index = i;
                break;
            }
        }
        for (int i = index; i < _size; i++)
        {
            _items[i] = _items[i + 1];
        }
        _size--;

    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Size)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
        for (int i = index; i < Size; i++)
        {
            _items[i] = _items[i + 1];
        }
        _size--;
    }

    public bool Contains(Object item)
    {
        for (int i = 0; i < Size; i++)
        {
            if (_items[i].Equals(item))
            {
                return true;
            }
        }
        return false;
    }

    public void Insert(int index, Object item)
    {
        _size++;
        if (Size == _capacity)
        {
            Resize();
        }
        if (index < 0 || index > Size)
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
        for (int i = Size; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }
        _items[index] = item;

    }
}

public class Program
{
    public static void Main()
    {
        MyArrayList items = new MyArrayList();

        for (int i = 0; i < 10; i++)
        {
            items.Add(i);
        }

        foreach (Object x in items)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();

        IComparer comparer = new MyArrayList();

        int index = items.BinarySearch(9, comparer);
        Console.WriteLine(index);


    }
}