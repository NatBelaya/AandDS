#pragma once
#include<iostream>

class Stack {
private:
	int MAX;
	int* STACK;
	int TOP;

public:
	Stack(int cap);

	void peek();

	void PUSH(int item);

	void POP();
};
