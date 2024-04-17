using System;
using System.IO;

// Делегат для обработчика события изменения списка
public delegate void ChangeEventHandler(object sender, EventArgs e);

// Исключение для случаев некорректного индекса
public class BadIndexException : Exception
{
    public BadIndexException(string message) : base(message)
    {
    }
}

// Исключение для случаев проблем с файлом
public class BadFileException : Exception
{
    public BadFileException(string message) : base(message)
    {
    }
}
public abstract class BaseList<T> where T : IComparable<T>
{
    // Событие изменения списка
    public event ChangeEventHandler Change;
    private int changeCount = 0; // Счетчик изменений списка

    // Метод для вызова события изменения списка
    protected virtual void OnChange(EventArgs e)
    {
        changeCount++;
        Change?.Invoke(this, e);
    }

    // Свойство для доступа к количеству изменений списка
    public int ChangeCount
    {
        get { return changeCount; }
    }

    // Метод для сохранения данных списка в файл
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

    // Метод для загрузки данных списка из файла
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

    protected int count; // Поле для хранения количества элементов списка

    // Свойство для доступа к количеству элементов списка
    public int Count
    {
        get { return count; }
    }

    // Абстрактные методы, которые должны быть реализованы в производных классах
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

    // Абстрактный метод для создания пустой копии списка
    protected abstract BaseList<T> EmptyClone();

    // Метод для клонирования списка
    public BaseList<T> Clone()
    {
        BaseList<T> copy = EmptyClone();
        copy.Assign(this);
        return copy;
    }

    //пузырьковая сортировка
    public virtual void Sort()
    {
        // внешний цикл проходит по всем элементам списка за исключением последнего
        for (int i = 0; i < Count - 1; i++)
        {
            // внутренний цикл проходит по всем элементам списка, исключая уже отсортированные
            for (int j = 0; j < Count - i - 1; j++)
            {
                // если текущий элемент больше следующего, меняем их местами
                if (this[j].CompareTo(this[j + 1]) > 0)
                {
                    T temp = this[j];
                    this[j] = this[j + 1];
                    this[j + 1] = temp;
                }
            }
        }
    }

    // Метод для сравнения списка с другим списком на равенство
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

    // Метод для присваивания элементов из другого списка
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

    // Метод для присваивания элементов данного списка другому списку
    public void AssignTo(BaseList<T> dest)
    {
        dest.Assign(this);
    }

    // Метод для выполнения заданного действия над каждым элементом списка
    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < Count; i++)
        {
            action(this[i]);
        }
    }

    // Перегрузка оператора ==
    public static bool operator ==(BaseList<T> list1, BaseList<T> list2)
    {
        if (list1 is null)
        {
            return list2 is null;
        }
        else if (list2 is null)
        {
            return false;
        }

        // Приведение списков к одному типу и сравнение
        BaseList<T> convertedList2 = list2 as BaseList<T>;
        return list1.Equals(convertedList2);
    }

    // Перегрузка оператора !=
    public static bool operator !=(BaseList<T> list1, BaseList<T> list2)
    {
        return !(list1 == list2);
    }

    // Перегрузка оператора +
    public static BaseList<T> operator +(BaseList<T> list1, BaseList<T> list2)
    {
        // Создаем новый список, используя тип данных первого списка
        BaseList<T> result = (BaseList<T>)Activator.CreateInstance(list1.GetType());

        // Копируем элементы из первого списка
        for (int i = 0; i < list1.Count; i++)
        {
            result.Add(list1[i]);
        }

        // Копируем элементы из второго списка
        for (int i = 0; i < list2.Count; i++)
        {
            result.Add(list2[i]);
        }

        // Возвращаем объединенный список
        return result;
    }
}