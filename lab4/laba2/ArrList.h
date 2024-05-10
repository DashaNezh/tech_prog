#pragma once
#include "BaseList.h"
#include <iostream>

class ArrList : public BaseList {
public:
    ArrList();

    void Add(int a) override;

    void Insert(int a, int pos) override;

    void Delete(int pos) override;
    
    void Clear() override;

    int& operator[](int i) override;

    BaseList* Clone() override;

private:
    int** buf; 
    int capacity;
};