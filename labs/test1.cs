namespace test1{
    class ArrList{
        int [] buf = null;
        int count = 0;
        public static void Add(int [] arrayBy, int [] arrayTo){
            int lengthOfArrayBy = arrayBy.Length;
            Array.Resize(ref arrayBy, lengthOfArrayBy + arrayTo.Length);
            Array.Copy(arrayTo, 0, arrayBy, lengthOfArrayBy, arrayTo.Length);
        }
    }
    class programP{
        int [] A = new int [] {1, 2, 3, 4};
        int [] B = new int [] {5, 6, 7}
        Add(A, B);
        foreach (int item in A)
        {
            Console.WriteLine(item);
        }
    }
}