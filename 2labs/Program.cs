using System;
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
        Tester.Test();
    }
}