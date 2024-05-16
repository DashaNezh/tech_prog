#include <iostream>

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
    ChainList();
    void Add(int data);
    void Insert(int data, int pos);
    void Delete(int pos);
    void Clear();
    int Count();
    int& operator[](int i);
    void Print();

private:
    Node* NodeFind(int pos);
};