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