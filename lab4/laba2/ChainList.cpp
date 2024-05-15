#include "ChainList.h"

int ChainList::constructorCount = 0;
int ChainList::destructorCount = 0;
bool ChainList::isCloning = false;

ChainList::ChainList() : head(nullptr) {
    if (!isCloning){
        constructorCount++; 
    } 
}

ChainList::~ChainList() {
    Clear();
    destructorCount++;
}

int ChainList::getConstructorCount() {
    return constructorCount;
}

int ChainList::getDestructorCount() {
    return destructorCount;
}

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

int& ChainList::operator[](int i) {
    Node* node = NodeFind(i); // Используем NodeFind для нахождения узла
    if (node == nullptr) {
        throw std::out_of_range("Index out of range");
    }
    return node->Data;
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

BaseList* ChainList :: Clone() {
    ChainList::isCloning = true; // Устанавливаем флаг клонирования
    ChainList* copy = new ChainList();
    copy->Assign(this);
    ChainList::isCloning = false; // Сбрасываем флаг клонирования
    return copy;
}

void ChainList :: Sort() {
    if (head == nullptr || head->Next == nullptr)
        return; // если список пуст или 1 элемент, сортировка не требуется 
    Node* current = head;
    while (current != nullptr) // пока не до конца
    {
        // проверяем, является ли текущий узел последним в списке
        // или его значение меньше или равно значению следующего узла
        if (current->Next == nullptr || current->Data <= current->Next->Data)
        {
            current = current->Next; // бежим к следующему узлу
        }
        else
        {
            // если значение текущего узла больше значения следующего узла,
            // меняем их значения местами
            int temp = current->Data;
            current->Data = current->Next->Data;
            current->Next->Data = temp;
            current = current->Next; // идем дальше
            // если следующий узел не является головой списка,
            // возвращаемся к началу списка для повторной проверки
            if (current != head)
            {
                current = head;
            }
        }
    }
}