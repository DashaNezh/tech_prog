#include "ArrList.h"

ArrList::ArrList() {
    capacity = 5;
    buf = new int*[capacity]; // Выделяем память под массив указателей
    for (int i = 0; i < capacity; ++i) {
        buf[i] = new int; // Выделяем память для каждого элемента массива
    }
    count = 0;
}

void ArrList::Add(int data) {
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
    *(buf[count]) = data; // Записываем значение по адресу, хранящемуся в buf[count]
    count++;
}

void ArrList::Insert(int data, int pos) {
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
    *(buf[pos]) = data; // Вставляем новое значение
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

int ArrList::Count() {
    return count;
}

int& ArrList::operator[](int i) {
    if (i < 0 || i >= count) {
        throw std::out_of_range("Index out of range");
    }
    return *(buf[i]); // Возвращаем значение по адресу, хранящемуся в buf[i]
}

void ArrList::Print() {
    for (int i = 0; i < count; ++i) {
        std::cout << *(buf[i]) << " "; // Выводим значение по адресу, хранящемуся в buf[i]
    }
    std::cout << std::endl;
}