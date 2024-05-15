#pragma once
#include "BaseList.h"

class ChainList : public BaseList {
private:
    class Node {
    public:
        int Data;
        Node* Next;
        Node(int data) : Data(data), Next(nullptr) {}
    };

    Node* head;

public:
    ChainList();
    ~ChainList();

    void Add(int data) override;
    void Insert(int data, int pos) override;
    void Delete(int pos) override;
    void Clear() override;
    int& operator[](int i) override;
    virtual BaseList* Clone() override;
    void Sort() override;

    static int getConstructorCount();
    static int getDestructorCount();

private:
    Node* NodeFind(int pos);

    static int constructorCount;
    static int destructorCount;

    static bool isCloning;
};