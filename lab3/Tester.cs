class Tester()
{
private static Random random = new Random();
private static int arrBadIndexExceptionCount = 0;
private static int arrBadFileExceptionCount = 0;
private static int chainBadIndexExceptionCount = 0;
private static int chainBadFileExceptionCount = 0;
    public static void Test()
    {
        BaseList<int> list1 = new ArrList<int>();
        BaseList<int> list2 = new ChainList<int>();

        for (int i = 0; i < 10000; i++)
        {
            int operation = random.Next(6); //выбор операции
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
                        list1.Insert(index, value);
                        list2.Insert(index, value);
                        break;
                    case 2:
                        list1.Delete(index);
                        list2.Delete(index);
                        break;
                    case 3:
                        list1.Clear();
                        list2.Clear();
                        break;
                    case 4:
                        list1.LoadFromFile("fileForTest.txt");
                        list2.LoadFromFile("fileForTest.txt");
                        break;
                    case 5:
                        list1[index] = value;
                        list2[index] = value;
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                CountExceptions(list1, e); // учет исключений для arrlist
                CountExceptions(list2, e); // учет исключений для chainlist
            }
        }
        Console.WriteLine(list1.Count == list2.Count);
        bool testEquals = list1.Equals(list2);
        Console.WriteLine($"Списки {(testEquals ? "одинаковы" : "различны")}.");
        Console.WriteLine($"Количетсво изменений в ArrList: {list1.ChangeCount}");
        Console.WriteLine($"Количество изменений в ChainList: {list2.ChangeCount}");

        Console.WriteLine($"Количество срабатываний исключения BadIndexException для динамического списка: " + arrBadIndexExceptionCount);
        Console.WriteLine($"Количество срабатываний исключения BadFileException для динамического списка: " + arrBadFileExceptionCount);
        Console.WriteLine($"Количество срабатываний исключения BadIndexException для связанного списка: " + chainBadIndexExceptionCount);
        Console.WriteLine($"Количество срабатываний исключения BadFileException для связанного списка: " + chainBadFileExceptionCount);
        Console.WriteLine();
        Console.WriteLine($"ПРОВЕРКА arrList + chainList");
        BaseList<int> sumArr = list1 + list2;
        sumArr.Print();
        Console.WriteLine($"ПРОВЕРКА chainList + arrList");
        sumArr = list2 + list1;
        sumArr.Print();
        Console.WriteLine();
        Console.WriteLine($"ПРОВЕРКА FOREACH");
        list1.ForEach(list1);
        list2.ForEach(list2);
        Console.WriteLine();
        Console.WriteLine($"ПРОВЕРКА arrList == chainList");
        Console.WriteLine(list1 == list2);
        Console.WriteLine($"ПРОВЕРКА arrList != chainList");
        Console.WriteLine(list1 != list2);
        Console.WriteLine();
        Console.WriteLine("Тестирование завершено.");
    }
    public static void CountExceptions<T>(BaseList<T> list, Exception ex) where T : IComparable<T>
    {
        if (ex is BadIndexException)
        {
            if (list is ArrList<T>)
            {
                arrBadIndexExceptionCount++;
            }
            else if (list is ChainList<T>)
            {
                chainBadIndexExceptionCount++;
            }
        }
        else if (ex is BadFileException)
        {
            if (list is ArrList<T>)
            {
                arrBadFileExceptionCount++;
            }
            else if (list is ChainList<T>)
            {
                chainBadFileExceptionCount++;
            }
        }
    }  
}