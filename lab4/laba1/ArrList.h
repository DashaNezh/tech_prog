#include <iostream>

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
    int** buf; 
    int capacity;
    int count;
};