using System;

namespace lab2
{
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
    
    public class ArrList : BaseList
    {
        private int[] buf; // массив для хранения элементов 
        // private int count;
        // Переопределение свойства для получения количества элементов в списке
        

        public ArrList()
        {
            buf = new int[5]; // задаем нач. размер
            count = 0;
        }

        // метод для добавления элементов в список
        public override void Add(int a)
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
        public override void Insert(int a, int pos)
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
        public override void Delete(int pos)
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
        public override void Clear()
        {
            for (int i = 0; i < count; i++)
            {
                buf[i] = 0; //зануляем все элементы
            }
            count = 0; //сбрасываем кол-во элементов
        }
   
        //индексатор для доступа к элементам списка
        public override int this[int i]
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
        // переопределение метода EmptyClone для создания пустой копии текущего списка
        protected override BaseList EmptyClone()
        {
            // создание нового объекта ArrList в качестве пустой копии списка.
            ArrList copy = new ArrList();
            return copy;
        }
    }
//цепной список
    public class ChainList : BaseList
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


        //сам цепной список
        public ChainList()
        {
            head = null; //создание пустого списка
            count = 0;
        }

        //метод для добавления узлов
        public override void Add(int data)
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
        public override void Insert(int data, int pos)
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
        public override void Delete(int pos)
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
        public override void Clear()
        {
            head = null; //удаляем ссылку на голову списка
            count = 0;
        }
        // получение кол-ва элементов списка
    
        //индексатор для доступа к узлам списка
        public override int this[int i]
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
        protected override BaseList EmptyClone()
        {
            ChainList copy = new ChainList(); //создаем пустышку как ChainList
            return copy;
        }
        // гномья сортировка 
        public override void Sort()
        {
            if (head == null || head.Next == null)
                return; // если список пуст или 1 элемент, сортировка не требуется 
            Node current = head;
            while (current != null) // пока не до конца
            {
                // проверяем, является ли текущий узел последним в списке
                // или его значение меньше или равно значению следующего узла
                if (current.Next == null || current.Data <= current.Next.Data)
                {
                    current = current.Next; // бежим к след 
                }
                else
                {
                    // если значение текущего узла больше значения следующего узла,
                    // меняем их значения местами
                    int temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    current = current.Next; // идем дальше
                    // если следующий узел не является головой списка,
                    // возвращаемся к началу списка для повторной проверки
                    if (current != head)
                    {
                        current = head;
                    }
                }
            }
        }

        // public void deleteDublicates()
        // {
        //     for (int i = 0; i < count; i++)
        //     {
        //         int currentElement = this[i];
        //         bool isDublicate = false;
        //         for (int j = count - 1; j > i; j--)
        //         {
        //             if (this[j] == currentElement)
        //             {
        //                 Delete(j);
        //                 isDublicate = true;
        //             }
        //         }
        //         if (isDublicate == true)
        //         {
        //             Delete(i);
        //             i--;
        //         }
        //     }

        // }

        public override void deleteDublicates()
        {
            Node current = head;
            while (current != null)
            {
                Node runner = current;
                while (runner.Next != null)
                {
                    if (runner.Next.Data == current.Data)
                    {
                        runner.Next = runner.Next.Next;
                        count--;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }
            }
        }
    }

    class Tester()
    {
        private static Random random = new Random();
        public static void Test()
        {
            BaseList list1 = new ArrList();
            BaseList list2 = new ChainList();

            for (int i = 0; i < 10000; i++)
            {
                int operation = random.Next(7); //выбор операции
                int value = random.Next(1000); // случ. знач.
                int index = random.Next(1, 100); // случ. индекс

                try
                {
                    switch(operation)
                    {
                        case 0:
                            list1.Add(value);
                            list2.Add(value);
                            break;
                        case 1:
                            if(list1.Count > 0 && list2.Count > 0)
                            {
                                list1.Insert(value, index);
                                list2.Insert(value, index);
                            }
                            break;
                        case 2:
                            if (list1.Count > 0 && list2.Count > 0)
                            {
                                list1.Delete(index);
                                list2.Delete(index);
                            }
                            break;
                        case 3:
                            //list1.Clear();
                            //list2.Clear();
                            break;
                        case 4:
                            if(list1.Count > 0 && list2.Count > 0)
                            {
                                list1[index] = value;
                                list2[index] = value;
                            }
                            break;
                        case 5:
                            list1.Sort();
                            list2.Sort();
                            break;
                        case 6:
                            list1.Equals(list2);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                    break;
                }
            }
            list1.Assign(list2);
            list1.AssignTo(list2); 
            list2 = list1.Clone();
            if (list1.Equals(list2)) 
                Console.WriteLine("!!!!!"); 
            else    
                Console.WriteLine(" error");
            Console.WriteLine($"Проверка на одинаковость: ");
            Console.WriteLine(list1.Count);
            Console.WriteLine(list2.Count);
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i])
                {
                    Console.WriteLine($"Листы разные");
                }
                else
                {
                    Console.WriteLine($"Листы одинаковые");
                }
            }
        }  
    }

        class Programm
        {
        public static void Main(string[] args)
        {
            // Console.WriteLine($"Динамический список");
            // Console.WriteLine();
            // BaseList dynamicArray = new ArrList();
            // dynamicArray.Add(1);
            // dynamicArray.Add(2);
            // dynamicArray.Add(3);
            // dynamicArray.Add(4);
            // dynamicArray.Add(5);
            // Console.WriteLine($"После добавления: "); 
            // dynamicArray.Print(); //1 2 3 4 5
            // dynamicArray.Insert(9, 2);
            // Console.WriteLine($"После вставки: ");
            // dynamicArray.Print();  //1 2 9 3 4 5
            // dynamicArray.Delete(1);
            // Console.WriteLine($"После удаления: "); 
            // dynamicArray.Print(); //1 9 3 4 5
            // dynamicArray.Clear();
            // Console.WriteLine($"После очистки: "); 
            // dynamicArray.Print(); //пустая строка
            // dynamicArray.Add(1);
            // dynamicArray.Add(2);
            // Console.WriteLine($"Добавила два элемента");
            // dynamicArray.Print(); //1 2
            // dynamicArray[0] = 9;
            // int value = dynamicArray[0];
            // Console.WriteLine($"Изменила первый элемент на 9");
            // dynamicArray.Print(); // 9 2
            // Console.WriteLine($"Значение 1-ого элемента: {value}"); //9
            // int currentCount = dynamicArray.Count;
            // Console.WriteLine($"Текущее кол-во элементов: {currentCount}"); //2

            // Console.WriteLine();
            // Console.WriteLine($"Связной список");
            // Console.WriteLine();
            // BaseList list = new ChainList();
            // list.Add(1);
            // list.Add(2);
            // list.Add(3);
            // Console.WriteLine($"После добавления: ");
            // list.Print(); // 1 2 3
            // list.Insert(6, 2);
            // Console.WriteLine($"После вставки: ");
            // list.Print(); //1 2 6
            // list.Delete(1);
            // Console.WriteLine($"После удаления: ");
            // list.Print(); // 1 6
            // list.Clear();
            // Console.WriteLine($"После очистки: ");
            // list.Print(); // пустая строка
            // list.Add(1);
            // list.Add(2);
            // Console.WriteLine($"Добавила два элемента"); 
            // list.Print(); // 1 2
            // list[1] = 45;
            // int valueOfChainList = list[1];
            // Console.WriteLine($"Изменила второй элемент на 45");
            // list.Print();// 1 45
            // Console.WriteLine($"Значение 2-ого элемента: {valueOfChainList}"); //45
            // int currentCountOfChainList = list.Count;
            // Console.WriteLine($"Текущее кол-во элементов: {currentCountOfChainList}"); //2

            // Console.WriteLine();

            // Console.WriteLine($"ТУТ ПРО BASELIST КАК БЫ");
            // Console.WriteLine();
            // Console.WriteLine($"ТУТ ПРО DYNAMICARRAY");
            // BaseList newarrList = new ArrList();
            // newarrList.Add(40);
            // newarrList.Add(25);
            // newarrList.Add(30);
            // Console.WriteLine($"После добавления");
            // newarrList.Print(); //40 25 30
            // newarrList.Sort();
            // Console.WriteLine($"После сортировки");
            // newarrList.Print(); //25 30 40
            // dynamicArray.Assign(newarrList);
            // Console.WriteLine($"После назначения:");
            // dynamicArray.Print(); // 25 30 40
            // BaseList assignToList1 = new ArrList();
            // assignToList1.Add(9);
            // assignToList1.Add(10);
            // assignToList1.Add(11);
            // Console.WriteLine($"dynamicArray:");
            // dynamicArray.Print();  //25 30 40
            // Console.WriteLine($"assignToList1:");
            // assignToList1.Print();  //9 10 11
            // dynamicArray.AssignTo(assignToList1);
            // Console.WriteLine($"dynamicArray после применения AssignTo:");
            // dynamicArray.Print();  //25 30 40
            // Console.WriteLine($"assignToList1 после применения AssignTo:");
            // assignToList1.Print();  //25 30 40
            // BaseList clonedList = (ArrList)dynamicArray.Clone();
            // Console.WriteLine($"Клонированный лист:");
            // clonedList.Print(); // 25 30 40
            // Console.WriteLine($"Равны ли листы? " + dynamicArray.Equals(newarrList)); // True
            // dynamicArray.Clear();
            // Console.WriteLine($"После очистки:");
            // dynamicArray.Print(); // пустая строка

            // Console.WriteLine($"ТУТ ПРО CHAINLIST:");
            // BaseList newarrChainList = new ChainList();
            // newarrChainList.Add(40);
            // newarrChainList.Add(25);
            // newarrChainList.Add(30);
            // Console.WriteLine($"После добавления");
            // newarrChainList.Print(); //40 25 30
            // newarrChainList.Sort();
            // Console.WriteLine($"После сортировки");
            // newarrChainList.Print(); //25 30 40
            // list.Assign(newarrChainList);
            // Console.WriteLine($"После Assign:");
            // list.Print(); //25 30 40
            // BaseList assignToList = new ChainList();
            // assignToList.Add(9);
            // assignToList.Add(10);
            // assignToList.Add(11);
            // Console.WriteLine($"list:");
            // list.Print();  //25 30 40
            // Console.WriteLine($"assignToList:");
            // assignToList.Print();  //9 10 11
            // list.AssignTo(assignToList);
            // Console.WriteLine($"list после применения AssignTo:");
            // list.Print();  //25 30 40
            // Console.WriteLine($"assignToList после применения AssignTo:");
            // assignToList.Print();  //25 30 40
            // BaseList clonedChainList = (ChainList)list.Clone();
            // Console.WriteLine($"Клонированный лист:");
            // clonedChainList.Print(); //25 30 40
            // Console.WriteLine("Равны ли листы? " + list.Equals(newarrChainList)); // True
            // list.Clear();
            // Console.WriteLine($"После очистки:");
            // list.Print(); // пустая строка

            // Console.WriteLine($"***ТЕСТИРОВАНИЕ***");
            // Console.WriteLine();
            // Tester.Test();

            BaseList list1 = new ArrList();
            BaseList list2 = new ChainList();
            list1.Add(1);
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(9);
            list1.Add(3);

            list2.Add(1);
            list2.Add(1);
            list2.Add(2);
            list2.Add(3);
            list2.Add(9);
            list2.Add(3);
            Console.WriteLine($"ArrList до удаления дубasdsdликатов");
            list1.Print();
            Console.WriteLine($"ChainLIst до удаления дубликатов");
            list2.Print();
            list1.deleteDublicates();
            list2.deleteDublicates();
            Console.WriteLine($"ArrList");
            list1.Print();
            Console.WriteLine($"ChainList");
            list2.Print();
            Console.WriteLine();
        }
    }
}