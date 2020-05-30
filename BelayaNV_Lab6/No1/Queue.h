#pragma once
#include<iostream>
class Queue {
private:
	int front, rear, capacity;
	int* queue;

public:
	Queue(int cap);

	// function to insert an element
	// at the rear of the queue
	void queueAdd(int data);

	// function to delete an element
	// from the front of the queue
	void queueRemove();

	// print queue elements
	void queueDisplay();

	// print front of queue
	void queueFront();
};