#include "Deque.h"

Deque::Deque(int cap)
{
	arr = new int[MAX];
	front = -1;
	rear = 0;
	size = cap;
}


bool Deque::isFull()
{
	return ((front == 0 && rear == size - 1) ||
		front == rear + 1);
}

bool Deque::isEmpty()
{
	return front == -1;
}


void Deque::insertFront(int key)
{
	// check whether Deque if  full or not
	if (isFull())
	{
		std::cout << "Deck is full";
		return;
	}

	// If queue is initially empty
	if (isEmpty())
	{
		front = 0;
		rear = 0;
	}

	// front is at first position of queue
	else if (front == 0)
		front = size - 1;

	else // decrement front end by '1'
		front = front - 1;

	// insert current element into Deque
	arr[front] = key;
}

void Deque::insertRear(int key)
{
	if (isFull())
	{
		std::cout << "Deque is full";
		return;
	}

	// If queue is initially empty
	if (isEmpty())
	{
		front = 0;
		rear = 0;
	}

	// rear is at last position of queue
	else if (rear == size - 1)
		rear = 0;

	// increment rear end by '1'
	else
		rear = rear + 1;

	// insert current element into Deque
	arr[rear] = key;
}

void Deque::deleteFront()
{
	// check whether Deque is empty or not
	if (isEmpty())
	{
		std::cout << "Deque is empty\n";
		return;
	}

	// Deque has only one element
	if (front == rear)
	{
		front = -1;
		rear = -1;
	}
	else
		// back to initial position
		if (front == size - 1)
			front = 0;

		else // increment front by '1' to remove current
			// front value from Deque
			front = front + 1;
}

void Deque::deleteRear()
{
	if (isEmpty())
	{
		std::cout << "Deque is empty";
		return;
	}

	// Deque has only one element
	if (front == rear)
	{
		front = -1;
		rear = -1;
	}
	else if (rear == 0)
		rear = size - 1;
	else
		rear = rear - 1;
}

int Deque::getFront()
{
	// check whether Deque is empty or not
	if (isEmpty())
	{
		std::cout << "Deque is empty";
		return -1;
	}
	return arr[front];
}

int Deque::getRear()
{
	// check whether Deque is empty or not
	if (isEmpty() || rear < 0)
	{
		std::cout << "Deck is empty\n";
		return -1;
	}
	return arr[rear];
}