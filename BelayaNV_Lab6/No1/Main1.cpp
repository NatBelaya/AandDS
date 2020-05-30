#include"Deque.h"
#include"Queue.h"
#include"Stack.h"

int main() {
	bool e = true;
	int struct_choice;

	while (e) {
		std::cout << "Select data structure (1: Stack, 2: Queue, 3: Deque) 4: Exit:";
		std::cin >> struct_choice;
		switch (struct_choice) {

			//stack
		case 1: {
			int ITEM;
			int choice;
			Stack* stack = new Stack(10);
			bool e1 = true;
			std::cout << "Stack selected\n";
			while (e1) {
				std::cout << "Choose operation (1: peek, 2: insert (PUSH), 3: remove(POP)), 4: Exit..:";
				std::cin >> choice;

				switch (choice) {
				case 1: {
					stack->peek();
					break;
				}
				case 2: {
					std::cout << "Enter Item to be inserted :";
					std::cin >> ITEM;
					stack->PUSH(ITEM);
					break;
				}
				case 3: {
					stack->POP();
					break;
				}
				case 4: {
					e1 = false;
					delete stack;
					std::cout << "Exiting stack...";
					break;
				}
				default: {
					std::cout << "\nInvalid choice.";
					break;
				}
				}
			}
			break;

			//queue
		}
		case 2: {
			Queue* queue = new Queue(10);
			int choice;
			int ITEM;
			bool e1 = true;
			std::cout << "Queue selected";

			while (e1) {
				std::cout << "Choose operation (1: view queue, 2: add, 3: remove, 4: view front), 5: Exit..:";
				std::cin >> choice;

				switch (choice) {
				case 1: {
					queue->queueDisplay();
					break;
				}
				case 2: {
					std::cout << "Enter Item to be added :";
					std::cin >> ITEM;
					queue->queueAdd(ITEM);
					break;
				}
				case 3: {
					queue->queueRemove();
					break;
				}
				case 4: {
					queue->queueFront();
					break;
				}
				case 5: {
					e1 = false;
					delete queue;
					std::cout << "Exiting queue...";
					break;
				}
				default: {
					std::cout << "\nInvalid choice.";
					break;
				}
				}
			}
			break;
		}

				  //deque
		case 3: {
			Deque* deque = new Deque(20);
			int choice;
			int ITEM;
			bool e1 = true;
			std::cout << "Deque selected";

			while (e1) {
				std::cout << "Choose operation ( 1: add front, 2: add back, 3: view front, 4: view rear, 5: remove front, 6: remove rear), 7: Exit..:";
				std::cin >> choice;

				switch (choice) {
				case 1: {
					std::cout << "Enter Item to be added (front) :";
					std::cin >> ITEM;
					deque->insertFront(ITEM);
					break;
				}
				case 2: {
					std::cout << "Enter Item to be added (rear) :";
					std::cin >> ITEM;
					deque->insertRear(ITEM);
					break;
				}
				case 3: {
					std::cout << "Deque front --> " + deque->getFront();
					break;
				}
				case 4: {
					std::cout << "Deque rear --> " + deque->getRear();
					break;
				}
				case 5: {
					deque->deleteFront();
					break;
				}
				case 6: {
					deque->deleteRear();
					break;
				}
				case 7: {
					e1 = false;
					delete deque;
					std::cout << "Exiting deque...";
					break;
				}
				default: {
					std::cout << "\nInvalid choice.";
					break;
				}
				}
			}
			break;
		}

				  //exit
		case 4: {
			e = false;
			std::cout << "Finishing program...";
			break;
		}

		default: {
			std::cout << "Invalid input\n";
			break;
		}
		}
	}
	return 0;
}
