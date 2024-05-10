#include "ArrList.h"
#include "ChainList.h"

class Tester {
public:
    static void Test() {
        BaseList* list1 = new ArrList();
        BaseList* list2 = new ChainList();
        bool listsAreEqual = true;

        for (int i = 0; i < 10000; i++) {
            int operation = rand() % 6; //выбор операции
            int value = rand() % 1000; // случ. знач.
            int index = 1 + rand() % 100; // случ. индекс

            try {
                switch (operation) {
                    case 0:
                        list1->Add(value);
                        list2->Add(value);
                        break;
                    case 1:
                        if (list1->Count() > 0 && list2->Count() > 0) {
                            list1->Insert(value, index);
                            list2->Insert(value, index);
                        }
                        break;
                    case 2:
                        if (list1->Count() > 0 && list2->Count() > 0) {
                            list1->Delete(index);
                            list2->Delete(index);
                        }
                        break;
                    case 3:
                        //list1.Clear();
                        //list2.Clear();
                        break;
                    case 4:
                        if (list1->Count() > 0 && list2->Count() > 0) {
                            // Гарантируем, что индекс находится в допустимом диапазоне
                            index = rand() % list1->Count();
                            (*list1)[index] = value;
                            (*list2)[index] = value;
                        }
                        break;
                    case 5:
                        list1->Sort();
                        list2->Sort();
                        break;
                }
            } catch (const std::out_of_range& e) {
                std::cout << "Error: " << e.what() << " at operation: " << operation << std::endl;
                break;
            }
        }
        list1->Assign(list2);
        list1->AssignTo(list2);
        if (list1->Equals(list2)){
            std :: cout << "Lists are the same" << std::endl;
        }
        else{
             std :: cout << "Lists aren't the same" << std::endl;
        }
        std::cout << "Checking equality of lists..." << std::endl;
        std::cout << "List sizes: " << list1->Count() << " and " << list2->Count() << std::endl;
        if (list1->Count() != list2->Count()) {
            std::cout << "Lists are different" << std::endl;
            listsAreEqual = false;
        } else {
            for (int i = 0; i < list1->Count(); i++) {
                if ((*list1)[i] != (*list2)[i]) {
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
    BaseList* dynamicArray = new ArrList();
    dynamicArray->Add(1);
    dynamicArray->Add(2);
    dynamicArray->Add(3);
    dynamicArray->Add(4);
    dynamicArray->Add(5);
    std::cout << "After add: " << std::endl;;
    dynamicArray->Print(); //1 2 3 4 5
    dynamicArray->Insert(9, 2);
    std::cout << "After insert: " << std::endl;;
    dynamicArray->Print();  //1 2 9 3 4 5
    dynamicArray->Delete(1);
    std::cout << "After delete: " << std::endl;;
    dynamicArray->Print(); //1 9 3 4 5
    dynamicArray->Clear();
    std::cout << "After clear: " << std::endl;;
    dynamicArray->Print(); //пустая строка
    dynamicArray->Add(1);
    dynamicArray->Add(2);
    std::cout << "Add 2 items: " << std::endl;;
    dynamicArray->Print(); //1 2
    (*dynamicArray)[0] = 9;
    int value = (*dynamicArray)[0];
    std::cout << "Change the first item na 9: " << std::endl;;
    dynamicArray->Print(); // 9 2
    std::cout << "Value of the first item is: " << value << std::endl; //9
    int currentCount = dynamicArray->Count();
    std::cout << "Current count: " << currentCount << std::endl; //2
    BaseList* newList1 = new ArrList();
    newList1->Add(23);
    newList1->Add(12);
    newList1->Add(3);
    newList1->Add(54);
    std::cout << "List1 after add: " << std::endl;
    newList1->Print();
    newList1->Sort();
    std::cout << "List1 after sort: " << std::endl;
    newList1->Print();
    BaseList* newList2 = new ArrList();
    newList2->Add(3);
    newList2->Add(2);
    newList2->Add(5);
    std::cout << std::endl;
    std::cout << "List2 after add: " << std::endl;
    newList2->Print();
    newList2->Assign(newList1);
    std::cout << "List2 after assign: " << std::endl;
    newList2->Print();
    std::cout << "List3: ";
    BaseList* newList3 = new ArrList();
    newList3->Print();
    newList3 = newList2->Clone();
    std::cout << "List3 after clone: " << std::endl;
    newList3->Print();
    std::cout << "list3 and list2 is equal?" << newList3->Equals(newList2) << std::endl;
    std::cout << std::endl;

    std::cout << "Checking ChainList" << std::endl;
    BaseList* list = new ChainList();
    list->Add(1);
    list->Add(2);
    list->Add(3);
    std::cout << "After add: " << std::endl;
    list->Print(); // 1 2 3
    list->Insert(6, 2);
    std::cout << "After insert: " << std::endl;
    list->Print(); //1 2 6
    list->Delete(1);
    std::cout << "After delete: " << std::endl;
    list->Print(); // 1 6
    list->Clear();
    std::cout << "After clear: " << std::endl;
    list->Print(); // пустая строка
    list->Add(1);
    list->Add(2);
    std::cout << "Add 2 items: " << std::endl;
    list->Print(); // 1 2
    (*list)[1] = 45;
    int valueOfChainList = (*list)[1];
    std::cout << "Change the second item to 45: " << std::endl;
    list->Print();// 1 45
    std::cout << "Value of the second item: " << valueOfChainList << std::endl; //45
    int currentCountOfChainList = list->Count();
    std::cout << "Currnet count: " << currentCountOfChainList << std::endl; //2

    BaseList* newListChain1 = new ChainList();
    newListChain1->Add(23);
    newListChain1->Add(12);
    newListChain1->Add(3);
    newListChain1->Add(54);
    std::cout << "List1 after add: " << std::endl;
    newListChain1->Print();
    newListChain1->Sort();
    std::cout << "List1 after sort: " << std::endl;
    newListChain1->Print();
    BaseList* newListChain2 = new ArrList();
    newListChain2->Add(3);
    newListChain2->Add(2);
    newListChain2->Add(5);
    std::cout << std::endl;
    std::cout << "List2 after add: " << std::endl;
    newListChain2->Print();
    newListChain2->Assign(newListChain1);
    std::cout << "List2 after assign: " << std::endl;
    newListChain2->Print();
    std::cout << "List3: ";
    BaseList* newListChian3 = new ArrList();
    newListChian3->Print();
    newListChian3 = newList2->Clone();
    std::cout << "List2 after clone: " << std::endl;
    newListChian3->Print();
    std::cout << "list3 and list2 is equal?" << newListChian3->Equals(newListChain2) << std::endl;

    std::cout << std::endl;
    std::cout << "***TESTING***" << std::endl;
    std::cout << std::endl;
    Tester::Test();

    return 0;
}