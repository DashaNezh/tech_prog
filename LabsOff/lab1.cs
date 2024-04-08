// using System;

// namespace lab1{
// //динамический список
//     public class ArrList 
//     {
//         private int[] buf; // массив для хранения элементов 
//         private int count = 0; // кол-во элементов в списке

//         public ArrList()
//         {
//             buf = new int[5]; // задаем нач. размер
//             count = 0;
//         }

//         // метод для добавления элементов в список
//         public void Add(int a)
//         {
//             if (buf.Length <= count) //проверка заполности буфера
//             {
//                 int[] newBuf = new int[buf.Length * 2]; // создаем новый буфер увеличив его(если надо) и копируем в него элементы
//                 for (int i = 0; i < buf.Length; i++)
//                 {
//                     newBuf[i] = buf[i];
//                 }
//                 buf = newBuf;
//             }
//             //добавляем элемент и увеливаем кол-во элементов
//             buf[count] = a;
//             count++;
//         }

//         // метод для добавления элемента на определенную позицию
//         public void Insert(int a, int pos)
//         {
//             if (pos < 0 || pos > count)
//             {
//                 return; // позиция вне диапазона списка
//             }
//             if (buf.Length <= count)  //проверка заполности буфера
//             {
//                 // создаем новый буфер увеличив его(если надо) и копируем в него элементы
//                 int[] newBuf = new int[buf.Length * 2];
//                 for (int i = 0; i < buf.Length; i++)
//                 {
//                     newBuf[i] = buf[i];
//                 }
//                 buf = newBuf;
//             }
//             //сдвигаем элементы вправо, чтобы освободить место
//             for (int i = count; i > pos; i--)
//             {
//                 buf[i] = buf[i - 1];
//             }
//             //вставляем элемент на указанную позицию и увеличиваем кол-во элементов 
//             buf[pos] = a;
//             count++;
//         }

//         // метод для удаления элемента с определенной позиции
//         public void Delete(int pos)
//         {
//             if (pos < 0 || pos >= count)
//             {
//                 return; //проверка позиции
//             }
//             //сдвигаем элементы влево для удаления
//             for (int i = pos; i < count - 1; i++)
//             {
//                 buf[i] = buf[i + 1];
//             }
//             //уменьшаем кол-во элементов
//             count--;
//         }

//         // метод очистки списка
//         public void Clear()
//         {
//             for (int i = 0; i < count; i++)
//             {
//                 buf[i] = 0; //зануляем все элементы
//             }
//             count = 0; //сбрасываем кол-во элементов
//         }

//         //метод для вывода элементов списка (в столбик)
//         public void Print()
//         {
//             Console.WriteLine("Динамический массив:");
//             for (int i = 0; i < count; i++)
//             {
//                 Console.Write(buf[i] + " ");
//             }
//             Console.WriteLine();
//         }
        
//         // получение кол-ва элементов в списке
//         public int Count
//         {
//             get
//             {
//                 return count;
//             }
//         }

//         //индексатор для доступа к элементам списка
//         public int this[int i]
//         {
//             get
//             {
//                 if (i >= count || i < 0)
//                 {
//                     throw new ArgumentOutOfRangeException("Element is out of range");
//                 }
//                 return buf[i]; //возращаем элемент списка по указанному индексу
//             }

//             set
//             {
//                 if (i >= count || i < 0)
//                 {
//                     //throw new ArgumentOutOfRangeException("Element is out of range");
//                     return;
//                 }
//                 buf[i] = value; //присваиваем новое значение элементу списка по указанному индексу
//             }
//         }

//         public void deleteDublicates()
//         {
//             if (count <= 0) //проверяем на кол-во элементов в списке
//             {
//                 return;
//             }
//             for (int i = 0; i < count; i++)
//             {
//                 int currentElement = this[i];
//                 bool isDublicate = false;
//                 for (int j = count - 1; j > i; j--)
//                 {
//                     if (this[j] == currentElement)
//                     {
//                         Delete(j);
//                         isDublicate = true;
//                     }
//                 }
//                 if (isDublicate == true)
//                 {
//                     Delete(i);
//                     i--;
//                 }
//             }
//         }
//     }
//     //цепной список
//     public class ChainList
//     {
//         private class Node
//         {
//             public int Data; //данные в узле
//             public Node Next; // ссылка на след. элемент

//             //конструктор для создания узла с заданными нач. условиями 
//             public Node(int data)
//             {
//                 Data = data;
//                 Next = null; //нач. условие 
//             }
//         }
//         private Node head; //голова списка 1 узел
//         private int count; //кол-во узлов в списке

//         //сам цепной список
//         public ChainList()
//         {
//             head = null; //создание пустого списка
//             count = 0;
//         }

//         //метод для добавления узлов
//         public void Add(int data)
//         {
//             Node newNode = new Node(data); //создаем новый список
//             if (head == null)
//             {
//                 head = newNode;//создание 1-ого узла, если его нет (newNode становится головой списка)
//             }
//             else
//             {
//                 Node current = head; // current - голова списка
//                 while (current.Next != null) //идем к последнему узлу
//                 {
//                     current = current.Next;
//                 }
//                 current.Next = newNode; //добавляем новый узел в конец
//             }
//             count++;
//         }
        
//         //метод для добавления узла на указанную позицию
//         public void Insert(int data, int pos)
//         {
//             if (pos < 0 || pos > count)
//             {
//                 return; // проверка позиции
//             }

//             Node newNode = new Node(data); // создаем новый узел с указынными данными
//             if (pos == 0) //вставка в начало
//             {
//                 //делаем его головным
//                 newNode.Next = head;
//                 head = newNode;
//             }
//             else //вставка в середину или в конец списка
//             {
//                 //находим узел, который находится до позиции вставки
//                 Node current = head;
//                 for (int i = 0; i < pos - 1; i++)
//                 {
//                     current = current.Next;
//                 }
//                 newNode.Next = current.Next; // вставляем новый узел между current и current.Next
//                 current.Next = newNode;
//             }
//             count++;
//         }

//         //метод для удаления узла с указанной позиции
//         public void Delete(int pos)
//         {
//             if (pos < 0 || pos > count)
//             {
//                 return; //проверка позиции
//             }
//             if (pos == 0)
//             {
//                 head = head.Next; //удаление головы списка
//             }
//             else // удаление из середины или конца списка
//             {
//                 //находим узел, который находится до позиции удаления
//                 Node current = head;
//                 for (int i = 0; i < pos - 1; i ++)
//                 {
//                     current = current.Next; 
//                 }
//                 // проверяем, не является ли current.Next последним элементом
//                 if(current.Next != null)
//                 {
//                     // если удаляем последний элемент, то устанавливаем Next предпоследнего элемента в null
//                     if (current.Next.Next == null)
//                     {
//                         current.Next = null;
//                     }
//                     else
//                     {
//                         current.Next = current.Next.Next; //пропускаем узел, который хотим удалить 
//                     }
//                 }
//             }
//             count--;
//         }

//         //метод для очистки 
//         public void Clear()
//         {
//             head = null; //удаляем ссылку на голову списка
//             count = 0;
//         }

//         //получение кол-ва узлов списка
//         public int Count
//         {
//             get
//             {
//                 return count;   
//             }
//         }
//         //индексатор для доступа к узлам списка
//         public int this[int i]
//         {
//             get
//             {
//                 //начинаем с головного узла
//                 Node current = head;
//                 for (int j = 0; j < i; j++)
//                 {
//                     // переходим к след. узлу, пока не достигнем нужного индекса
//                     if (current != null)
//                     {
//                         current = current.Next;
//                     }
//                     else
//                     {
//                         throw new ArgumentOutOfRangeException("Index out of range");
//                     }
//                 }
//                 //возвращаем данные узла по указанному индексу
//                 return current.Data;
//             }
//             set
//             {
//                 //начинаем с головного узла
//                 Node current = head;
//                 for (int j = 0; j < i; j ++)
//                 {
//                     //переходим к след. узлу, пока не достигнем нужного индекса
//                     if (current != null)
//                     {
//                         current = current.Next;
//                     }
//                     else
//                     {
//                         //throw new ArgumentOutOfRangeException("Index out of range");
//                         return;
//                     }
//                 }
//                 //проверяем, что узел существует
//                 if (current != null)
//                 {
//                     current.Data = value; //присваиваем новое значение
//                 }
//                 else
//                 {
//                     //throw new ArgumentOutOfRangeException("Index out of range");
//                     return;
//                 }
//             }
//         }

//         //метод для вывода узлов списка (в строку)
//         public void Print()
//         {
//             Console.WriteLine($"Цепной список: ");
//             Node current = head;
//             while (current != null)
//             {
//                 Console.Write(current.Data + " ");
//                 current = current.Next;
//             }
//             Console.WriteLine();
//         }

//         public void deleteDublicates()
//         {
//             for (int i = 0; i < count; i++)
//             {
//                 int currentElement = this[i];
//                 bool isDublicate = false;
//                 for (int j = count - 1; j > i; j--)
//                 {
//                     if (this[j] == currentElement)
//                     {
//                         Delete(j);
//                         isDublicate = true;
//                     }
//                 }
//                 if (isDublicate == true)
//                 {
//                     Delete(i);
//                     i--;
//                 }
//             }

//         }
//     }

//     class Tester()
//     {
//         private static Random random = new Random();
//         public static void Test()
//         {
//             ArrList list1 = new ArrList();
//             ChainList list2 = new ChainList();

//             for (int i = 0; i < 10000; i++)
//             {
//                 int operation = random.Next(5); //выбор операции
//                 int value = random.Next(1000); // случ. знач.
//                 int index = random.Next(1, 100); // случ. индекс

//                 try
//                 {
//                     switch(operation)
//                     {
//                         case 0:
//                             list1.Add(value);
//                             list2.Add(value);
//                             break;
//                         case 1:
//                             if(list1.Count > 0 && list2.Count > 0)
//                             {
//                                 list1.Insert(value, index);
//                                 list2.Insert(value, index);
//                             }
//                             break;
//                         case 2:
//                             if (list1.Count > 0 && list2.Count > 0)
//                             {
//                                 list1.Delete(index);
//                                 list2.Delete(index);
//                             }
//                             break;
//                         case 3:
//                             //list1.Clear();
//                             //list2.Clear();
//                             break;
//                         case 4:
//                             if(list1.Count > 0 && list2.Count > 0)
//                             {
//                                 list1[index] = value;
//                                 list2[index] = value;
//                             }
//                             break;
//                     }
//                 }
//                 catch (Exception e)
//                 {
//                     Console.WriteLine($"Ошибка: {e.Message}");
//                     break;
//                 }
//             }
//             Console.WriteLine($"Проверка на одинаковость: ");
//             Console.WriteLine(list1.Count);
//             Console.WriteLine(list2.Count);
//             for (int i = 0; i < list1.Count; i++)
//             {
//                     if (list1[i] != list2[i])
//                     {
//                         Console.WriteLine($"Листы разные");
//                     }
//                     else
//                     {
//                         Console.WriteLine($"Листы одинаковые");
//                     }
//             }
//         }  
//     }

//     class Program
//     {
//         public static void Main(string[] args)
//         {
//             ArrList dynamicArray = new ArrList();
//             dynamicArray.Add(1);
//             dynamicArray.Add(2);
//             dynamicArray.Add(3);
//             dynamicArray.Add(4);
//             dynamicArray.Add(5);
//             Console.WriteLine($"После добавления: "); 
//             dynamicArray.Print(); //1 2 3 4 5
//             dynamicArray.Insert(9, 2);
//             Console.WriteLine($"После вставки: ");
//             dynamicArray.Print();  //1 2 9 3 4 5
//             dynamicArray.Delete(1);
//             Console.WriteLine($"После удаления: "); 
//             dynamicArray.Print(); //1 9 3 4 5
//             dynamicArray.Clear();
//             Console.WriteLine($"После очистки: "); 
//             dynamicArray.Print(); //пустая строка
//             dynamicArray.Add(1);
//             dynamicArray.Add(2);
//             Console.WriteLine($"Добавила два элемента");
//             dynamicArray.Print(); //1 2
//             dynamicArray[0] = 9;
//             int value = dynamicArray[0];
//             Console.WriteLine($"Изменила первый элемент на 9");
//             dynamicArray.Print(); // 9 2
//             Console.WriteLine($"Значение 1-ого элемента: {value}"); //9
//             int currentCount = dynamicArray.Count;
//             Console.WriteLine($"Текущее кол-во элементов: {currentCount}"); //2
            
//             Console.WriteLine();

//             ChainList list = new ChainList();
//             list.Add(1);
//             list.Add(2);
//             list.Add(3);
//             Console.WriteLine($"После добавления: ");
//             list.Print(); // 1 2 3
//             list.Insert(6, 2);
//             Console.WriteLine($"После вставки: ");
//             list.Print(); //1 2 6
//             list.Delete(1);
//             Console.WriteLine($"После удаления: ");
//             list.Print(); // 1 6
//             list.Clear();
//             Console.WriteLine($"После очистки: ");
//             list.Print(); // пустая строка
//             list.Add(1);
//             list.Add(2);
//             Console.WriteLine($"Добавила два элемента"); 
//             list.Print(); // 1 2
//             list[1] = 45;
//             int valueOfChainList = list[1];
//             Console.WriteLine($"Изменила второй элемент на 45");
//             list.Print();// 1 45
//             Console.WriteLine($"Значение 2-ого элемента: {valueOfChainList}"); //45
//             int currentCountOfChainList = list.Count;
//             Console.WriteLine($"Текущее кол-во элементов: {currentCountOfChainList}"); //2

//             Console.WriteLine();
//             Console.WriteLine($"***ТЕСТИРОВАНИЕ***");
//             Console.WriteLine();
//             Console.WriteLine($"***ПРОВЕРКА МЕТОДА ДЛЯ ЗАЩИТЫ***");
//             ArrList newList = new ArrList();
//             newList.Add(1);
//             newList.Add(1);
//             newList.Add(3);
//             newList.Add(9);
//             newList.Add(1);
//             newList.Add(3);
//             Console.WriteLine($"Добавила элементы");
//             newList.Print();
//             newList.deleteDublicates();
//             Console.WriteLine($"Сделала удаление дубликатов");
//             newList.Print();
//             Console.WriteLine();
//             ChainList newList1 = new ChainList();
//             newList1.Add(1);
//             newList1.Add(1);
//             newList1.Add(3);
//             newList1.Add(9);
//             newList1.Add(1);
//             newList1.Add(3);
//             Console.WriteLine($"Добавила элементы");
//             newList1.Print();
//             newList1.deleteDublicates();
//             Console.WriteLine($"Сделала удаление дубликатов");
//             newList1.Print();
//             Console.WriteLine();
//             //Tester.Test();
//         }
//     }
// }