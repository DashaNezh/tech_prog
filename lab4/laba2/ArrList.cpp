#include "ArrList.h"

int ArrList::constructorCount = 0;
int ArrList::destructorCount = 0;
bool ArrList::isCloning = false;

ArrList::~ArrList()
{
    for (int i = 0; i < capacity; ++i) {
        delete buf[i]; // Освобождаем память для каждого элемента массива
    }
    delete[] buf;
    destructorCount++;
}

ArrList::ArrList() 
{
    if (!isCloning){
        constructorCount++;
    }
    capacity = 5;
    buf = new int*[capacity]; // Выделяем память под массив указателей
    for (int i = 0; i < capacity; ++i) {
        buf[i] = new int; // Выделяем память для каждого элемента массива
    }
    count = 0;
}

int ArrList::getConstructorCount() {
    return constructorCount;
}

int ArrList::getDestructorCount() {
    return destructorCount;
}

void ArrList::Add(int a) {
    if (count >= capacity) {
        // Увеличиваем емкость массива указателей
        int newCapacity = capacity * 2;
        int** newBuf = new int*[newCapacity];
        for (int i = 0; i < newCapacity; ++i) {
            if (i < capacity) {
                newBuf[i] = buf[i]; // Копируем указатели из старого буфера
            } else {
                newBuf[i] = new int; // Выделяем новую память для дополнительных элементов
            }
        }
        delete[] buf; // Освобождаем память для старого массива указателей
        buf = newBuf;
        capacity = newCapacity;
    }
    *(buf[count]) = a; // Записываем значение по адресу, хранящемуся в buf[count]
    count++;
}

void ArrList::Insert(int a, int pos) {
    if (pos < 0 || pos > count) return; 
    if (count >= capacity) {
        // Увеличиваем емкость массива указателей аналогично методу Add
        int newCapacity = capacity * 2;
        int** newBuf = new int*[newCapacity];
        for (int i = 0; i < newCapacity; ++i) {
            if (i < capacity) {
                newBuf[i] = buf[i];
            } else {
                newBuf[i] = new int;
            }
        }
        delete[] buf;
        buf = newBuf;
        capacity = newCapacity;
    }
    for (int i = count; i > pos; --i) {
        *(buf[i]) = *(buf[i - 1]); // Сдвигаем элементы вправо
    }
    *(buf[pos]) = a; // Вставляем новое значение
    count++;
}

void ArrList::Delete(int pos) {
    if (pos < 0 || pos >= count) return;
    for (int i = pos; i < count - 1; ++i) {
        *(buf[i]) = *(buf[i + 1]); // Сдвигаем элементы влево
    }
    count--;
}

void ArrList::Clear() {
    count = 0; // Просто обнуляем количество элементов
}

int& ArrList::operator[](int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    return *(buf[i]); // Возвращаем значение по адресу, хранящемуся в buf[i]
}

BaseList* ArrList::Clone() {
    ArrList::isCloning = true; // Устанавливаем флаг клонирования
    ArrList* copy = new ArrList();
    copy->Assign(this);
    ArrList::isCloning = false; // Сбрасываем флаг клонирования
    return copy;
}
