using System;
using System.IO;

public delegate void ChangeEventHandler(object sender, EventArgs e);

public class BadIndexException : Exception
{
    public BadIndexException(string message) : base(message)
    {
    }
}

public class BadFileException : Exception
{
    public BadFileException(string message) : base(message)
    {
    }
}

public abstract class BaseList<T> where T : IComparable<T>
{
    public event ChangeEventHandler Change;
    private int changeCount = 0;

    protected virtual void OnChange(EventArgs e)
    {
        changeCount++;
        Change?.Invoke(this, e);
    }

    public int ChangeCount
    {
        get { return changeCount; }
    }

    public void SaveToFile(string fileName)
    {
        StreamWriter writer = null;
        try
        {
            writer = new StreamWriter(fileName);
            for (int i = 0; i < Count; i++)
            {
                writer.WriteLine(this[i].ToString());
            }
            Console.WriteLine("Данные успешно записаны в файл: " + fileName);
        }
        catch (Exception ex)
        {
            throw new BadFileException("Ошибка при сохранении данных в файл: " + ex.Message);
        }
        finally
        {
            if (writer != null)
            {
                writer.Close();
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        StreamReader reader = null;
        try
        {
            reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null) // Заменена строка "== reader.ReadLine()" на "="
            {
                T item = (T)Convert.ChangeType(line, typeof(T)); // Использован метод Convert.ChangeType
                Add(item);
            }
            Console.WriteLine("Данные успешно загружены из файла: " + fileName); // Исправлено "выгружены" на "загружены"
        }
        catch (Exception ex)
        {
            throw new BadFileException("Ошибка при загрузке данных из файла: " + ex.Message);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
            }
        }
    }

    protected int count;
    public int Count
    {
        get { return count; }
    }

    public abstract void Add(T item);
    public abstract void Insert(int pos, T item);
    public abstract void Delete(int pos);
    public abstract void Clear();

    public abstract T this[int i] { get; set; }
    public void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.Write(this[i] + " ");
        }
        Console.WriteLine();
    }

    protected abstract BaseList<T> EmptyClone();
    public BaseList<T> Clone()
    {
        BaseList<T> copy = EmptyClone();
        copy.Assign(this);
        return copy;
    }

    public virtual void Sort()
    {
        T[] tempArray = new T[Count];
        for (int i = 0; i < Count; i++)
        {
            tempArray[i] = this[i];
        }

        Array.Sort(tempArray);

        for (int i = 0; i < Count; i++)
        {
            this[i] = tempArray[i];
        }
    }

    public bool Equals(BaseList<T> list)
    {
        if (list == null || !(list is BaseList<T>))
        {
            return false;
        }

        BaseList<T> otherList = (BaseList<T>)list;

        if (this.Count != otherList.Count)
        {
            return false;
        }

        for (int i = 0; i < this.Count; i++)
        {
            if (this[i].CompareTo(otherList[i]) != 0)
            {
                return false;
            }
        }
        return true;
    }

    public void Assign(BaseList<T> source)
    {
        Clear();
        if (source == null)
        {
            return;
        }
        for (int i = 0; i < source.Count; i++)
        {
            Add(source[i]);
        }
    }

    public void AssignTo(BaseList<T> dest)
    {
        dest.Assign(this);
    }

    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < Count; i++)
        {
            action(this[i]);
        }
    }
}
