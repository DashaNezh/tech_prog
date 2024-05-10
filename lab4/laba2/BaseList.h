#pragma once
#include <iostream>

class BaseList
{
protected:
    int count = 0;
    
public:
    virtual ~BaseList() {}

    int Count() const{
        return count;
    }
    virtual void Add(int a) = 0;
    virtual void Insert(int a, int pos) = 0;
    virtual void Delete(int pos) = 0;
    virtual void Clear() = 0;
    virtual int& operator[] (int i) = 0;

    void Print();

    virtual BaseList* Clone() = 0;

    void Assign(BaseList* source);

    void AssignTo(BaseList* dest);

    virtual void Sort();

    bool Equals(BaseList* list);
};

