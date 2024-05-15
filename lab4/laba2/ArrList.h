#pragma once
#include "BaseList.h"
#include <iostream>

class ArrList : public BaseList {
public:
    ArrList();
    ~ArrList();

    void Add(int a) override;

    void Insert(int a, int pos) override;

    void Delete(int pos) override;
    
    void Clear() override;

    int& operator[](int i) override;
 
    BaseList* Clone() override;

    static int getConstructorCount();
    static int getDestructorCount();

private:
    int** buf; 
    int capacity;

    static int constructorCount;
    static int destructorCount;

    static bool isCloning;
};