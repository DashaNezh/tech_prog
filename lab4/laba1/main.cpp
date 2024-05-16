#include "ArrList.h"
#include "ChainList.h"

class Tester {
public:
    static void Test() {
        ArrList list1;
        ChainList list2;
        bool listsAreEqual = true;

        for (int i = 0; i < 10000; i++) {
            int operation = rand() % 5; //выбор операции
            int value = rand() % 1000; // случ. знач.
            int index = 1 + rand() % 100; // случ. индекс

            try {
                switch (operation) {
                    case 0:
                        list1.Add(value);
                        list2.Add(value);
                        break;
                    case 1:
                        if (list1.Count() > 0 && list2.Count() > 0) {
                            list1.Insert(value, index);
                            list2.Insert(value, index);
                        }
                        break;
                    case 2:
                        if (list1.Count() > 0 && list2.Count() > 0) {
                            list1.Delete(index);
                            list2.Delete(index);
                        }
                        break;
                    case 3:
                        //list1.Clear();
                        //list2.Clear();
                        break;
                    case 4:
                        if (list1.Count() > 0 && list2.Count() > 0) {
                            // Гарантируем, что индекс находится в допустимом диапазоне
                            index = rand() % list1.Count();
                            list1[index] = value;
                            list2[index] = value;
                        }
                        break;
                }
            } catch (const std::out_of_range& e) {
                std::cout << "Error: " << e.what() << " at operation: " << operation << std::endl;
                break;
            }
        }

        std::cout << "Checking equality of lists..." << std::endl;
        std::cout << "List sizes: " << list1.Count() << " and " << list2.Count() << std::endl;
        if (list1.Count() != list2.Count()) {
            std::cout << "Lists are different" << std::endl;
            listsAreEqual = false;
        } else {
            for (int i = 0; i < list1.Count(); i++) {
                if (list1[i] != list2[i]) {
                    std::cout << "Lists are different" << std::endl;
                    listsAreEqual = false;
                    break;
                }
            }
        }

        if (listsAreEqual) {
            std::cout << "Lists are the same" << std::endl;
        }
    }
};

int main() {
    std::cout << "Checking ArrList" << std::endl;
    ArrList dynamicArray;
    dynamicArray.Add(1);
    dynamicArray.Add(2);
    dynamicArray.Add(3);
    dynamicArray.Add(4);
    dynamicArray.Add(5);
    std::cout << "After add: ";
    dynamicArray.Print(); //1 2 3 4 5
    dynamicArray.Insert(9, 2);
    std::cout << "After insert: ";
    dynamicArray.Print();  //1 2 9 3 4 5
    dynamicArray.Delete(1);
    std::cout << "After delete: ";
    dynamicArray.Print(); //1 9 3 4 5
    dynamicArray.Clear();
    std::cout << "After clear: ";
    dynamicArray.Print(); //пустая строка
    dynamicArray.Add(1);
    dynamicArray.Add(2);
    std::cout << "Add 2 items: ";
    dynamicArray.Print(); //1 2
    dynamicArray[0] = 9;
    int value = dynamicArray[0];
    std::cout << "Change the first item na 9: ";
    dynamicArray.Print(); // 9 2
    std::cout << "Value of the first item is: " << value << std::endl; //9
    int currentCount = dynamicArray.Count();
    std::cout << "Current count: " << currentCount << std::endl; //2

    std::cout << std::endl;

    std::cout << "Checking ChainList" << std::endl;
    ChainList list;
    list.Add(1);
    list.Add(2);
    list.Add(3);
    std::cout << "After add: ";
    list.Print(); // 1 2 3
    list.Insert(6, 2);
    std::cout << "After insert: ";
    list.Print(); //1 2 6
    list.Delete(1);
    std::cout << "After delete: ";
    list.Print(); // 1 6
    list.Clear();
    std::cout << "After clear: ";
    list.Print(); // пустая строка
    list.Add(1);
    list.Add(2);
    std::cout << "Add 2 items: ";
    list.Print(); // 1 2
    list[1] = 45;
    int valueOfChainList = list[1];
    std::cout << "Change the second item to 45: ";
    list.Print();// 1 45
    std::cout << "Value of the second item: " << valueOfChainList << std::endl; //45
    int currentCountOfChainList = list.Count();
    std::cout << "Currnet count: " << currentCountOfChainList << std::endl; //2

    std::cout << std::endl;
    std::cout << "***TESTING***" << std::endl;
    std::cout << std::endl;
    Tester::Test();

    return 0;
}