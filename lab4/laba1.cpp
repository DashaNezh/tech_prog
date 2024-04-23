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
    int* buf;
    int count;
};

ArrList::ArrList() {
    buf = new int[5];
    count = 0;
}

void ArrList::Add(int data) {
    if (count >= 5) {
        int* newBuf = new int[count * 2];
        for (int i = 0; i < count; i++) {
            newBuf[i] = buf[i];
        }
        delete[] buf;
        buf = newBuf;
    }
    buf[count++] = data;
}

void ArrList::Insert(int data, int pos) {
    if (pos < 0 || pos > count) return;
    if (count >= 5) {
        int* newBuf = new int[count * 2];
        for (int i = 0; i < count; i++) {
            newBuf[i] = buf[i];
        }
        delete[] buf;
        buf = newBuf;
    }
    for (int i = count; i > pos; i--) {
        buf[i] = buf[i - 1];
    }
    buf[pos] = data;
    count++;
}

void ArrList::Delete(int pos) {
    if (pos < 0 || pos >= count) return;
    for (int i = pos; i < count - 1; i++) {
        buf[i] = buf[i + 1];
    }
    count--;
}

void ArrList::Clear() {
    delete[] buf;
    buf = new int[5];
    count = 0;
}

int ArrList::Count() {
    return count;
}

int& ArrList::operator[](int i) {
    if (i < 0) {
        throw std::out_of_range("Index is negative");
    }
    if (i >= count) {
        // Если индекс больше или равен текущему размеру,
        // увеличиваем размер массива до i + 1
        int newSize = i + 1;
        int* newBuf = new int[newSize];
        for (int j = 0; j < count; j++) {
            newBuf[j] = buf[j];
        }
        delete[] buf;
        buf = newBuf;
        count = newSize;
    }
    return buf[i];
}

void ArrList::Print() {
    for (int i = 0; i < count; i++) {
        std::cout << buf[i] << " ";
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
    const int& operator[](int i) const;
    void Print();

private:
    int& Get(int i);
    const int& Get(int i) const;
    void Set(int i, int value);
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
        Node* current = head;
        for (int i = 0; i < pos - 1; i++) {
            current = current->Next;
        }
        newNode->Next = current->Next;
        current->Next = newNode;
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
        Node* current = head;
        for (int i = 0; i < pos - 1; i++) {
            current = current->Next;
        }
        Node* temp = current->Next;
        current->Next = current->Next->Next;
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
    return Get(i);
}

const int& ChainList::operator[](int i) const {
    return Get(i);
}

int& ChainList::Get(int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    
    Node* current = head;
    for (int j = 0; j < i; j++) {
        if (current == nullptr) {
            throw std::runtime_error("List is corrupted");
        }
        current = current->Next;
    }
    
    if (current == nullptr) {
        throw std::runtime_error("List is corrupted");
    }
    
    return current->Data;
}

const int& ChainList::Get(int i) const {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    
    const Node* current = head;
    for (int j = 0; j < i; j++) {
        if (current == nullptr) {
            throw std::runtime_error("List is corrupted");
        }
        current = current->Next;
    }
    
    if (current == nullptr) {
        throw std::runtime_error("List is corrupted");
    }
    
    return current->Data;
}

void ChainList::Set(int i, int value) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    
    Node* current = head;
    for (int j = 0; j < i; j++) {
        if (current == nullptr) {
            throw std::runtime_error("List is corrupted");
        }
        current = current->Next;
    }
    
    if (current == nullptr) {
        throw std::runtime_error("List is corrupted");
    }
    
    current->Data = value;
}

void ChainList::Print() {
    Node* current = head;
    while (current != nullptr) {
        std::cout << current->Data << " ";
        current = current->Next;
    }
    std::cout << std::endl;
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
    ArrList dynamicArray;
    dynamicArray.Add(1);
    dynamicArray.Add(2);
    dynamicArray.Add(3);
    dynamicArray.Add(4);
    dynamicArray.Add(5);
    std::cout << "After adding: ";
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