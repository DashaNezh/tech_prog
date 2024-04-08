public abstract class BaseList
{
    //абстрактные методы, которое реализованы в классах-наследниках
    protected int count;
    public  int Count
    { 
        get{ return count;}
    }
    public abstract void Add(int a);
    public abstract void Insert(int a, int pos);
    public abstract void Delete(int pos);
    public abstract void Clear();

    public abstract int this[int i] { get; set; }
    public void Print()
    {
        for (int i = 0; i < Count; i++)
        {
            Console.Write(this[i] + " ");
        }
        Console.WriteLine();
    }
    protected abstract BaseList EmptyClone(); //создает пустышки для Clone()
    public BaseList Clone()
    {
        BaseList copy = EmptyClone();
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
                if (this[j] > this[j + 1])
                {
                    int temp = this[j];
                    this[j] = this[j + 1];
                    this[j + 1] = temp;
                }
            }
        }
    }
    public bool Equals(BaseList list)
    {
        // Проверяем, что другой список не равен null и что тип объекта является производным от BaseList
        if (list == null || ! (list is BaseList))
        {
            return false; 
        }

        // Приведение объекта к типу BaseList для сравнения
        BaseList otherList = (BaseList)list;

        // Сравниваем количество элементов
        if (this.Count != otherList.Count)
        {
            return false;
        }

        // Построение логики сравнения элементов списка
        for (int i = 0; i < this.Count; i++)
        {
            if (this[i] != otherList[i])
            {
                return false;
            }
        }
        return true;
    }
    public void Assign(BaseList source)
    {
        // очищаем текущий список, чтобы избежать дублирования элементов 
        Clear();
        // проверка источника на null
        if (source == null)  // Если источник пуст или null, просто завершаем выполнение метода
        {
            return;
        }
        // проходим по элементам источника и добавляем их в текущий список
        for (int i = 0; i < source.Count; i++)
        {
            // добавляем каждый элемент из источника в текущий список
            Add(source[i]);
        }
    }
    
    public void AssignTo(BaseList dest)
    {
        dest.Assign(this);
    }

    public virtual void deleteDublicates()
    {
        for (int i = 0; i < count; i++)
        {
            int currentElement = this[i];
            bool isDublicate = false;
            for (int j = count - 1; j > i; j--)
            {
                if (this[j] == currentElement)
                {
                    Delete(j);
                    isDublicate = true;
                }
            }
            if (isDublicate == true)
            {
                Delete(i);
                i--;
            }
        }

    }
}