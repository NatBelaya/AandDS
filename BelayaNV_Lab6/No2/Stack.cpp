#include "Stack.h"

Stack::Stack(int cap) {
	TOP = -1;
	STACK = new int[cap];
	MAX = cap;
}

void Stack::POP()
{
	int deletedItem;
	if (TOP == -1)
	{
		std::cout << "Stack is empty.\n";
		//return false;
	}

	deletedItem = STACK[TOP];
	TOP--;
	//std::cout << deletedItem + " deleted successfully\n";
	//return true;
}

void Stack::PUSH(int item)
{
	if (TOP == MAX - 1)
	{
		std::cout << "\nStack is full. Can't add item\n";
		return;
	}
	TOP++;
	STACK[TOP] = item;
}

bool Stack::peek()
{
	int i;
	if (TOP == -1)
	{
		std::cout << "Stack is empty.";
		return false;
	}

	//std::cout << STACK[TOP] + "<- TOP";
	//for (i = TOP - 1; i >= 0; i--)
	//{
		//std::cout << "\n" + STACK[i];
	//}
	//std::cout << "\n";
	return true;
}