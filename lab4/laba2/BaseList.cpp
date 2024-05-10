#include "BaseList.h"
#include <iostream>

void BaseList::Print() {
    for (int i = 0; i < count; i++) {
        std::cout << (*this)[i] << " ";
    }
    std::cout << std::endl;
}

void BaseList::Sort() {
    for (int i = 0; i < count; i++) {
        for (int j = 0; j < count; j++) {
            if ((*this)[i] < (*this)[j]) {
                int temp = (*this)[i];
                (*this)[i] = (*this)[j];
                (*this)[j] = temp;
            }
        }
    }
}

bool BaseList::Equals(BaseList* array) {
    if (count != array->Count()) {
        return false;
    }
    for (int i = 0; i < count; i++) {
        if ((*this)[i] != (*array)[i]) {
            return false;
        }
    }
    return true;
}

void BaseList::Assign(BaseList* sourse){
    Clear();
    if (sourse == nullptr){
        return;
    }

    for (int i = 0; i < sourse->Count(); i++){
        Add((*sourse)[i]);
    }
}

void BaseList::AssignTo (BaseList* dest) {
    dest->Assign(this);
}