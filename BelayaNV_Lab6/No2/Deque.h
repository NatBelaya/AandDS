#pragma once
#include<iostream>
class Deque
{
private:
	static const int MAX = 50;
	int* arr;
	int front;
	int rear;
	int size;
public:

	Deque(int cap);

	// Checks whether Deque is full or not.
	bool isFull();

	// Checks whether Deque is empty or not.
	bool isEmpty();

	// Inserts an element at front
	void insertFront(int key);

	// function to inset element at rear end
	// of Deque.
	void insertRear(int key);

	// Deletes element at front end of Deque
	void deleteFront();

	// Delete element at rear end of Deque
	void deleteRear();

	// Returns front element of Deque
	int getFront();

	// function return rear element of Deque
	int getRear();
};