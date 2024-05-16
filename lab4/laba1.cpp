#include <iostream>
#include <ctime> // для функции time()
#include <cstdlib> // для функций rand() и srand()

class ArrList {
public:
    ArrList();
    void Add(int data);
    void Insert(int data, int pos);
    void Delete(int pos);
    void Clear();
    int Count();
    int& operator[](int i);
    void Print();

private:
    int** buf; // Массив указателей на целочисленные значения
    int capacity;
    int count;
};

ArrList::ArrList() {
    capacity = 5;
    buf = new int*[capacity]; // Выделяем память под массив указателей
    for (int i = 0; i < capacity; ++i) {
        buf[i] = new int; // Выделяем память для каждого элемента массива
    }
    count = 0;
}

void ArrList::Add(int data) {
    if (count >= capacity) {
        // Увеличиваем емкость массива указателей
        int newCapacity = capacity * 2;
        int** newBuf = new int*[newCapacity];
        for (int i = 0; i < newCapacity; ++i) {
            if (i < capacity) {
                newBuf[i] = buf[i]; // Копируем указатели из старого буфера
            } else {
                newBuf[i] = new int; // Выделяем новую память для дополнительных элементов
            }
        }
        delete[] buf; // Освобождаем память для старого массива указателей
        buf = newBuf;
        capacity = newCapacity;
    }
    *(buf[count]) = data; // Записываем значение по адресу, хранящемуся в buf[count]
    count++;
}

void ArrList::Insert(int data, int pos) {
    if (pos < 0 || pos > count) return;
    if (count >= capacity) {
        // Увеличиваем емкость массива указателей аналогично методу Add
        int newCapacity = capacity * 2;
        int** newBuf = new int*[newCapacity];
        for (int i = 0; i < newCapacity; ++i) {
            if (i < capacity) {
                newBuf[i] = buf[i];
            } else {
                newBuf[i] = new int;
            }
        }
        delete[] buf;
        buf = newBuf;
        capacity = newCapacity;
    }
    for (int i = count; i > pos; --i) {
        *(buf[i]) = *(buf[i - 1]); // Сдвигаем элементы вправо
    }
    *(buf[pos]) = data; // Вставляем новое значение
    count++;
}

void ArrList::Delete(int pos) {
    if (pos < 0 || pos >= count) return;
    for (int i = pos; i < count - 1; ++i) {
        *(buf[i]) = *(buf[i + 1]); // Сдвигаем элементы влево
    }
    count--;
}

void ArrList::Clear() {
    count = 0; // Просто обнуляем количество элементов
}

int ArrList::Count() {
    return count;
}

int& ArrList::operator[](int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    return *(buf[i]); // Возвращаем значение по адресу, хранящемуся в buf[i]
}

void ArrList::Print() {
    for (int i = 0; i < count; ++i) {
        std::cout << *(buf[i]) << " "; // Выводим значение по адресу, хранящемуся в buf[i]
    }
    std::cout << std::endl;
}

class ChainList {
private:
    class Node {
    public:
        int Data;
        Node* Next;
        Node(int data) : Data(data), Next(nullptr) {}
    };

    Node* head;
    int count;

public:
    ChainList() : head(nullptr), count(0) {}
    void Add(int data);
    void Insert(int data, int pos);
    void Delete(int pos);
    void Clear();
    int Count();
    int& operator[](int i);
    void Print();

private:
    Node* NodeFind(int pos); // Объявляем метод NodeFind
};

void ChainList::Add(int data) {
    Node* newNode = new Node(data);
    if (head == nullptr) {
        head = newNode;
    } else {
        Node* current = head;
        while (current->Next != nullptr) {
            current = current->Next;
        }
        current->Next = newNode;
    }
    count++;
}

void ChainList::Insert(int data, int pos) {
    if (pos < 0 || pos > count) return;

    Node* newNode = new Node(data);
    if (pos == 0) {
        newNode->Next = head;
        head = newNode;
    } else {
        Node* prevNode = NodeFind(pos - 1); // Используем NodeFind для нахождения предыдущего узла
        if (prevNode == nullptr) return; // Если позиция недопустима, выходим
        newNode->Next = prevNode->Next;
        prevNode->Next = newNode;
    }
    count++;
}

void ChainList::Delete(int pos) {
    if (pos < 0 || pos >= count) return;
    if (pos == 0) {
        Node* temp = head;
        head = head->Next;
        delete temp;
    } else {
        Node* prevNode = NodeFind(pos - 1); // Используем NodeFind для нахождения предыдущего узла
        if (prevNode == nullptr || prevNode->Next == nullptr) return; // Если позиция недопустима, выходим
        Node* temp = prevNode->Next;
        prevNode->Next = temp->Next;
        delete temp;
    }
    count--;
}

void ChainList::Clear() {
    while (head != nullptr) {
        Node* temp = head;
        head = head->Next;
        delete temp;
    }
    count = 0;
}

int ChainList::Count() {
    return count;
}

int& ChainList::operator[](int i) {
    Node* node = NodeFind(i); // Используем NodeFind для нахождения узла
    if (node == nullptr) {
        throw std::out_of_range("Index out of range");
    }
    return node->Data;
}

void ChainList::Print() {
    Node* current = head;
    while (current != nullptr) {
        std::cout << current->Data << " ";
        current = current->Next;
    }
    std::cout << std::endl;
}

ChainList::Node* ChainList::NodeFind(int pos) {
    if (pos >= count) return nullptr;
    int i = 0;
    Node* P = head;
    while (P != nullptr && i < pos) {
        P = P->Next;
        i++;
    }
    return (i == pos) ? P : nullptr;
}


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
    std::cout << "Checking ArrList";
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

    std::cout << "Checking ChainList";
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