class Tester()
{
private static Random random = new Random();
private static int arrBadIndexExceptionCount = 0;
private static int arrBadFileExceptionCount = 0;
private static int chainBadIndexExceptionCount = 0;
private static int chainBadFileExceptionCount = 0;
    public static void Test()
    {
        BaseList<string> list1 = new ArrList<string>();
        BaseList<string> list2 = new ChainList<string>();

        for (int i = 0; i < 10000; i++)
        {
            int operation = random.Next(7); //выбор операции
            string value = "Value" + random.Next(1000); // случ. знач.
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
                            list1.Insert(index, value);
                            list2.Insert(index, value);
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
                        list1.LoadFromFile("fileForTest.txt");
                        list2.LoadFromFile("fileForTest.txt");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                CountExceptions(list1, e);
                CountExceptions(list2, e);
                break;
            }
        }
        //list1.Assign(list2);
        //list1.AssignTo(list2); 
        //list2 = list1.Clone();
        Console.WriteLine(list1.Count);
        Console.WriteLine(list2.Count);
        bool testEquals = list1.Equals(list2);
        Console.WriteLine($"Списки {(testEquals ? "одинаковы" : "различны")}.");
        Console.WriteLine($"Количетсво изменений в динамик лист: {list1.ChangeCount}");
        Console.WriteLine($"Количество изменений в линкед лист: {list2.ChangeCount}");

        Console.WriteLine("Количество срабатываний исключения BadIndexException для динамического списка: " + arrBadIndexExceptionCount);
        Console.WriteLine("Количество срабатываний исключения BadFileException для динамического списка: " + arrBadFileExceptionCount);
        Console.WriteLine("Количество срабатываний исключения BadIndexException для связанного списка: " + chainBadIndexExceptionCount);
        Console.WriteLine("Количество срабатываний исключения BadFileException для связанного списка: " + chainBadFileExceptionCount);

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