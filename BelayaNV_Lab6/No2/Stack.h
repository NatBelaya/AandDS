#pragma once
#include<iostream>

class Stack {
private:
	int MAX;
	int* STACK;
	int TOP;

public:
	Stack(int cap);

	bool peek();

	void PUSH(int item);

	void POP();
};
