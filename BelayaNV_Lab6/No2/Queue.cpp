#include "Queue.h"

Queue::Queue(int cap) {
	front = rear = 0;
	capacity = cap;
	queue = new int[capacity];
}

void Queue::queueAdd(int data) {
	// check queue is full or not
	if (capacity == rear) {
		std::cout << "\nQueue is full\n";
	}

	// insert element at the rear
	else {
		queue[rear] = data;
		rear++;
	}
}

void Queue::queueRemove() {
	// if queue is empty
	if (front == rear) {
		std::cout << "\nQueue is empty\n";
		//return false;
	}

	// shift all the elements from index 2 till rear
	// to the right by one
	else {
		for (int i = 0; i < rear - 1; i++) {
			queue[i] = queue[i + 1];
		}

		// decrement rear 
		rear--;
	}
}

bool Queue::queueDisplay() {
	int i;
	if (front == rear) {
		//std::cout << "\nQueue is Empty\n";
		return false;
	}

	// traverse front to rear and print elements
	//for (i = front; i < rear; i++) {
		//std::cout << queue[i] + " <-- ";
	//}
	//std::cout << "\n";
	return true;
}

void Queue::queueFront() {
	if (front == rear) {
		std::cout << "\nQueue is Empty\n";
		return;
	}
	std::cout << "\nFront Element is: " + queue[front];
}