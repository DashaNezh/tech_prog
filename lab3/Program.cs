using System;
class Program
{
    static void Main(string[] args)
    {
        BaseList<string> dynamicList = new ArrList<string>();
        BaseList<string> linkedList = new ChainList<string>();

        // Добавление элементов
        Console.WriteLine("*** ТЕСТИРОВКА ADD*** \n");
        dynamicList.Add("apple");
        dynamicList.Add("banana");
        dynamicList.Add("orange");

        linkedList.Add("apple");
        linkedList.Add("banana");
        linkedList.Add("orange");

        Console.WriteLine("Список DynamicList после добавления элементов:");
        dynamicList.Print();
        Console.WriteLine("Список LinkedList после добавления элементов:");
        linkedList.Print();
        Console.WriteLine();

        // Вставка элемента
        Console.WriteLine("*** ТЕСТИРОВКА Insert***\n");
        dynamicList.Insert(1, "grape");
        linkedList.Insert(1, "grape");

        Console.WriteLine("Список DynamicList после вставки элемента:");
        dynamicList.Print();
        Console.WriteLine("Список LinkedList после вставки элемента:");
        linkedList.Print();
        Console.WriteLine();

        // Удаление элемента
         Console.WriteLine("*** ТЕСТИРОВКА Delete***\n");
        dynamicList.Delete(2);
        linkedList.Delete(2);

        Console.WriteLine("Список DynamicList после удаления элемента:");
        dynamicList.Print();
        Console.WriteLine("Список LinkedList после удаления элемента:");
        linkedList.Print();
        Console.WriteLine();

        // Очистка списков
         Console.WriteLine("*** ТЕСТИРОВКА Clear***\n");
        dynamicList.Clear();
        linkedList.Clear();

        Console.WriteLine("Список DynamicList после очистки:");
        dynamicList.Print();
        Console.WriteLine("Список LinkedList после очистки:");
        linkedList.Print();
        Console.WriteLine();

        // Проверка на равенство списков
        Console.WriteLine("*** ТЕСТИРОВКА IsEqual***\n");
        dynamicList.Add("apple");
        dynamicList.Add("banana");
        dynamicList.Add("orange");

        linkedList.Add("apple");
        linkedList.Add("banana");
        linkedList.Add("orange");

        bool areListsEqual = dynamicList.Equals(linkedList);
        Console.WriteLine($"Списки {(areListsEqual ? "одинаковы" : "различны")}.");
        Console.WriteLine();


        Console.WriteLine("*** ТЕСТИРОВКА CHANGE***\n");

        Console.WriteLine($"Количество изменений DynamicList: {dynamicList.ChangeCount}");
        Console.WriteLine($"Количество изменений LinkedList: {linkedList.ChangeCount}");

        Console.WriteLine();

        // Проверка метода Assign
        Console.WriteLine("*** ТЕСТИРОВКА Assign***\n");
        BaseList<string> assignedList = new ArrList<string>();

        assignedList.Add("pineapple");
        assignedList.Add("grapefruit");

        Console.WriteLine("Исходный список dynamicList:");
        dynamicList.Print();
        Console.WriteLine("Исходный список assignedList:");
        assignedList.Print();

        dynamicList.Assign(assignedList);

        Console.WriteLine("Список DynamicList после применения метода Assign:");
        dynamicList.Print();
        Console.WriteLine("Список AssignedList после применения метода Assign:");
        assignedList.Print();
        Console.WriteLine();

        // Проверка метода AssignTo
         Console.WriteLine("*** ТЕСТИРОВКА AssignTo***\n");
        dynamicList.Add("watermelon");
        BaseList<string> assignedToList = new ArrList<string>();

        assignedToList.Add("grapes");
        assignedToList.Add("kiwi");

        Console.WriteLine("Список DynamicList после применения метода Assign:");
        dynamicList.Print();
        Console.WriteLine("Список AssignedToList после применения метода Assign:");
        assignedToList.Print();

        dynamicList.AssignTo(assignedToList);
        Console.WriteLine();

        Console.WriteLine("Список DynamicList после применения метода AssignTo:");
        dynamicList.Print();
        Console.WriteLine("Список AssignedToList после применения метода AssignTo:");
        assignedToList.Print();
        Console.WriteLine();

        // Тестирование методов SaveToFile и LoadFromFile
        Console.WriteLine("*** ТЕСТИРОВКА SaveToFile и LoadFromFile ***\n");

        string dynamicListFile = "dynamicList.txt";
        string linkedListFile = "linkedList.txt";

        dynamicList.SaveToFile(dynamicListFile);
        linkedList.SaveToFile(linkedListFile);

        dynamicList.Clear();
        linkedList.Clear();

        dynamicList.LoadFromFile(dynamicListFile);
        linkedList.LoadFromFile(linkedListFile);

        Console.WriteLine("Список DynamicList после загрузки из файла:");
        dynamicList.Print();
        Console.WriteLine("Список LinkedList после загрузки из файла:");
        linkedList.Print();
        Console.WriteLine();

        // Тестирование метода ForEach
        Console.WriteLine("*** ТЕСТИРОВКА ForEach ***\n");

        dynamicList.Add("apple");
        dynamicList.Add("banana");
        dynamicList.Add("orange");

        linkedList.Add("apple");
        linkedList.Add("banana");
        linkedList.Add("orange");

        dynamicList.ForEach(item => Console.WriteLine(item));
        Console.WriteLine();

        linkedList.ForEach(item => Console.WriteLine(item));
        Console.WriteLine();

        // Console.WriteLine("*** ВЫЗОВ МЕТОДА ТЕСТИРОВКИ ***");
        // TestPerformance();
    }
}    