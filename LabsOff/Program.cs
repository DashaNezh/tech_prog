using System;
class Program
{
    public static void Main(string[] args)
    {
        ArrList dynamicArray = new ArrList();
        dynamicArray.Add(1);
        dynamicArray.Add(2);
        dynamicArray.Add(3);
        dynamicArray.Add(4);
        dynamicArray.Add(5);
        Console.WriteLine($"После добавления: "); 
        dynamicArray.Print(); //1 2 3 4 5
        dynamicArray.Insert(9, 2);
        Console.WriteLine($"После вставки: ");
        dynamicArray.Print();  //1 2 9 3 4 5
        dynamicArray.Delete(1);
        Console.WriteLine($"После удаления: "); 
        dynamicArray.Print(); //1 9 3 4 5
        dynamicArray.Clear();
        Console.WriteLine($"После очистки: "); 
        dynamicArray.Print(); //пустая строка
        dynamicArray.Add(1);
        dynamicArray.Add(2);
        Console.WriteLine($"Добавила два элемента");
        dynamicArray.Print(); //1 2
        dynamicArray[0] = 9;
        int value = dynamicArray[0];
        Console.WriteLine($"Изменила первый элемент на 9");
        dynamicArray.Print(); // 9 2
        Console.WriteLine($"Значение 1-ого элемента: {value}"); //9
        int currentCount = dynamicArray.Count;
        Console.WriteLine($"Текущее кол-во элементов: {currentCount}"); //2
        
        Console.WriteLine();

        ChainList list = new ChainList();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        Console.WriteLine($"После добавления: ");
        list.Print(); // 1 2 3
        list.Insert(6, 2);
        Console.WriteLine($"После вставки: ");
        list.Print(); //1 2 6
        list.Delete(1);
        Console.WriteLine($"После удаления: ");
        list.Print(); // 1 6
        list.Clear();
        Console.WriteLine($"После очистки: ");
        list.Print(); // пустая строка
        list.Add(1);
        list.Add(2);
        Console.WriteLine($"Добавила два элемента"); 
        list.Print(); // 1 2
        list[1] = 45;
        int valueOfChainList = list[1];
        Console.WriteLine($"Изменила второй элемент на 45");
        list.Print();// 1 45
        Console.WriteLine($"Значение 2-ого элемента: {valueOfChainList}"); //45
        int currentCountOfChainList = list.Count;
        Console.WriteLine($"Текущее кол-во элементов: {currentCountOfChainList}"); //2

        Console.WriteLine();
        Console.WriteLine($"***ТЕСТИРОВАНИЕ***");
        Console.WriteLine();
        Console.WriteLine($"***ПРОВЕРКА МЕТОДА ДЛЯ ЗАЩИТЫ***");
        ArrList newList = new ArrList();
        newList.Add(1);
        newList.Add(1);
        newList.Add(3);
        newList.Add(9);
        newList.Add(1);
        newList.Add(3);
        Console.WriteLine($"Добавила элементы");
        newList.Print();
        newList.deleteDublicates();
        Console.WriteLine($"Сделала удаление дубликатов");
        newList.Print();
        Console.WriteLine();
        ChainList newList1 = new ChainList();
        newList1.Add(1);
        newList1.Add(1);
        newList1.Add(3);
        newList1.Add(9);
        newList1.Add(1);
        newList1.Add(3);
        Console.WriteLine($"Добавила элементы");
        newList1.Print();
        newList1.deleteDublicates();
        Console.WriteLine($"Сделала удаление дубликатов");
        newList1.Print();
        Console.WriteLine();
        Tester.Test();
    }
}