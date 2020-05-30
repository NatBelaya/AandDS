#include "Deque.h"
#include "Queue.h"
#include "Stack.h"
#include <thread>
#include <mutex>
#include <Windows.h>
#include <condition_variable> // std::condition_variable
#include <stdlib.h>     /* srand, rand */
#include <time.h>       /* time */

#pragma region variables
//wicked salads co.

//3 conveyor belts to containers
Stack condiments(50);
Stack veggies(50);
Stack containers(50);

//queue of 5 robots
Queue line(5);

//packing grounds (warehouse)
Deque shelf(150);

//mutex
std::mutex mtx;
#pragma endregion

#pragma region belts
void condiments_belt() {
	while (true) {
		std::this_thread::sleep_for(std::chrono::milliseconds(1500));
		condiments.PUSH(1);
		std::cout << ">condiment bottle arrived\n";
	}
}

void veggies_belt() {
	while (true) {
		std::this_thread::sleep_for(std::chrono::milliseconds(1500));
		veggies.PUSH(1);
		std::cout << ">veggies arrived\n";
	}
}

void containers_belt() {
	while (true) {
		std::this_thread::sleep_for(std::chrono::milliseconds(1500));
		containers.PUSH(1);
		std::cout << ">container arrived\n";
	}
}
#pragma endregion

#pragma region loaders
void loader_front() {
	int local_time = 1700 - (rand() % 30);
	std::this_thread::sleep_for(std::chrono::milliseconds(local_time));
	shelf.deleteFront();
	std::cout << "\n--Removed item from shelf front\n";
}

void loader_rear() {
	int local_time = 1700 - (rand() % 30);
	std::this_thread::sleep_for(std::chrono::milliseconds(local_time));
	shelf.deleteRear();
	std::cout << "\n--Removed item from shelf rear\n";
}
#pragma endregion

void warehouse() {
	int choice = rand() % 2;
	if (choice == 0) {
		shelf.insertFront(1);
		std::cout << "\n~added item to shelf front\n";
		loader_front();
	}
	else 
	{
		shelf.insertRear(1);
		std::cout << "\n~added item to shelf rear\n";
		loader_rear();
	}
}

// robots thread function
void robots_queue(int i) {
	int local_time;
	mtx.lock();
	line.queueAdd(1); //add self upon init
	mtx.unlock();

	while (true) {
		local_time = 1000 + (rand() % 30) * 100;
		std::this_thread::sleep_for(std::chrono::milliseconds(local_time));
		mtx.lock();
		if (containers.peek() && condiments.peek() && veggies.peek()) {
			std::cout << "\n>>Rob #" << i++ << " takes the ingredients\n";
			veggies.POP();
			condiments.POP();
			containers.POP();
			mtx.unlock();

			while (!line.queueDisplay())
			{
				std::this_thread::sleep_for(std::chrono::milliseconds(0));
			}
			mtx.lock();

			line.queueRemove();
			warehouse();
			line.queueAdd(1);
			mtx.unlock();

		}
	}
}




int main() {
	/* initialize random seed: */
	srand(time(NULL));
	
	std::thread cond(condiments_belt);
	std::thread cont(containers_belt);
	std::thread vegg(veggies_belt);

	std::thread robots[5];
	for (int i = 0; i < 5; i++) {
		robots[i] = std::thread(robots_queue, i);
	}
	cond.join();
	return 0;
}

