//цепной список
public class ChainList
{
    private class Node
    {
        public int Data; //данные в узле
        public Node Next; // ссылка на след. элемент

        //конструктор для создания узла с заданными нач. условиями 
        public Node(int data)
        {
            Data = data;
            Next = null; //нач. условие 
        }
    }
    private Node head; //голова списка 1 узел
    private int count; //кол-во узлов в списке

    //сам цепной список
    public ChainList()
    {
        head = null; //создание пустого списка
        count = 0;
    }

    //метод для добавления узлов
    public void Add(int data)
    {
        Node newNode = new Node(data); //создаем новый список
        if (head == null)
        {
            head = newNode;//создание 1-ого узла, если его нет (newNode становится головой списка)
        }
        else
        {
            Node current = head; // current - голова списка
            while (current.Next != null) //идем к последнему узлу
            {
                current = current.Next;
            }
            current.Next = newNode; //добавляем новый узел в конец
        }
        count++;
    }
        
    //метод для добавления узла на указанную позицию
    public void Insert(int data, int pos)
    {
        if (pos < 0 || pos > count)
        {
            return; // проверка позиции
        }

        Node newNode = new Node(data); // создаем новый узел с указынными данными
        if (pos == 0) //вставка в начало
        {
            //делаем его головным
            newNode.Next = head;
            head = newNode;
        }
        else //вставка в середину или в конец списка
        {
            //находим узел, который находится до позиции вставки
            Node current = head;
            for (int i = 0; i < pos - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next; // вставляем новый узел между current и current.Next
            current.Next = newNode;
        }
        count++;
    }

    //метод для удаления узла с указанной позиции
    public void Delete(int pos)
    {
        if (pos < 0 || pos > count)
        {
            return; //проверка позиции
        }
        if (pos == 0)
        {
            head = head.Next; //удаление головы списка
        }
        else // удаление из середины или конца списка
        {
            //находим узел, который находится до позиции удаления
            Node current = head;
            for (int i = 0; i < pos - 1; i ++)
            {
                current = current.Next; 
            }
            // проверяем, не является ли current.Next последним элементом
            if(current.Next != null)
            {
                // если удаляем последний элемент, то устанавливаем Next предпоследнего элемента в null
                if (current.Next.Next == null)
                {
                    current.Next = null;
                }
                else
                {
                    current.Next = current.Next.Next; //пропускаем узел, который хотим удалить 
                }
            }
        }
        count--;
    }

    //метод для очистки 
    public void Clear()
    {
        head = null; //удаляем ссылку на голову списка
        count = 0;
    }

    //получение кол-ва узлов списка
    public int Count
    {
        get
        {
            return count;   
        }
    }
    //индексатор для доступа к узлам списка
    public int this[int i]
    {
        get
        {
            //начинаем с головного узла
            Node current = head;
            for (int j = 0; j < i; j++)
            {
                // переходим к след. узлу, пока не достигнем нужного индекса
                if (current != null)
                {
                    current = current.Next;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range");
                }
            }
            //возвращаем данные узла по указанному индексу
            return current.Data;
        }
        set
        {
            //начинаем с головного узла
            Node current = head;
            for (int j = 0; j < i; j ++)
            {
                //переходим к след. узлу, пока не достигнем нужного индекса
                if (current != null)
                {
                    current = current.Next;
                }
                else
                {
                    //throw new ArgumentOutOfRangeException("Index out of range");
                    return;
                }
            }
            //проверяем, что узел существует
            if (current != null)
            {
                current.Data = value; //присваиваем новое значение
            }
            else
            {
                //throw new ArgumentOutOfRangeException("Index out of range");
                return;
            }
        }
    }

    //метод для вывода узлов списка (в строку)
    public void Print()
    {
        Console.WriteLine($"Цепной список: ");
        Node current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
     }

    public void deleteDublicates()
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