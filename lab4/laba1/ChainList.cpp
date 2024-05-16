#include "ChainList.h"

ChainList::ChainList() : head(nullptr), count(0) {}

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