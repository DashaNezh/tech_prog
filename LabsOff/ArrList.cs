//динамический список
public class ArrList 
{
    private int[] buf; // массив для хранения элементов 
    private int count = 0; // кол-во элементов в списке

    public ArrList()
    {
        buf = new int[5]; // задаем нач. размер
        count = 0;
    }

    // метод для добавления элементов в список
    public void Add(int a)
    {
        if (buf.Length <= count) //проверка заполности буфера
        {
            int[] newBuf = new int[buf.Length * 2]; // создаем новый буфер увеличив его(если надо) и копируем в него элементы
            for (int i = 0; i < buf.Length; i++)
            {
                newBuf[i] = buf[i];
            }
            buf = newBuf;
        }
        //добавляем элемент и увеливаем кол-во элементов
        buf[count] = a;
        count++;
    }

    // метод для добавления элемента на определенную позицию
    public void Insert(int a, int pos)
    {
        if (pos < 0 || pos > count)
        {
            return; // позиция вне диапазона списка
        }
        if (buf.Length <= count)  //проверка заполности буфера
        {
            // создаем новый буфер увеличив его(если надо) и копируем в него элементы
            int[] newBuf = new int[buf.Length * 2];
            for (int i = 0; i < buf.Length; i++)
            {
                newBuf[i] = buf[i];
            }
            buf = newBuf;
        }
        //сдвигаем элементы вправо, чтобы освободить место
        for (int i = count; i > pos; i--)
        {
            buf[i] = buf[i - 1];
        }
        //вставляем элемент на указанную позицию и увеличиваем кол-во элементов 
        buf[pos] = a;
        count++;
    }

    // метод для удаления элемента с определенной позиции
    public void Delete(int pos)
    {
        if (pos < 0 || pos >= count)
        {
            return; //проверка позиции
        }
        //сдвигаем элементы влево для удаления
        for (int i = pos; i < count - 1; i++)
        {
            buf[i] = buf[i + 1];
        }
        //уменьшаем кол-во элементов
        count--;
    }

    // метод очистки списка
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            buf[i] = 0; //зануляем все элементы
        }
        count = 0; //сбрасываем кол-во элементов
    }

    //метод для вывода элементов списка (в столбик)
    public void Print()
    {
        Console.WriteLine("Динамический массив:");
        for (int i = 0; i < count; i++)
        {
            Console.Write(buf[i] + " ");
        }
        Console.WriteLine();
    }
        
    // получение кол-ва элементов в списке
    public int Count
    {
        get
        {
            return count;
        }
    }

    //индексатор для доступа к элементам списка
    public int this[int i]
    {
        get
        {
            if (i >= count || i < 0)
            {
                throw new ArgumentOutOfRangeException("Element is out of range");
            }
            return buf[i]; //возращаем элемент списка по указанному индексу
        }

        set
        {
            if (i >= count || i < 0)
            {
                //throw new ArgumentOutOfRangeException("Element is out of range");
                return;
            }
            buf[i] = value; //присваиваем новое значение элементу списка по указанному индексу
        }
    }

    public void deleteDublicates()
    {
        if (count <= 0) //проверяем на кол-во элементов в списке
        {
            return;
        }
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