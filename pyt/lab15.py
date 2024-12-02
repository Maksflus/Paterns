# Інтерфейс команди
from abc import ABC, abstractmethod


class Command(ABC):
    @abstractmethod
    def execute(self):
        pass


# Отримувач, який виконує операції
class ReservationReceiver:
    def book_table(self):
        print("Столик заброньовано.")

    def order_dish(self):
        print("Страва замовлена.")

    def process_payment(self):
        print("Платіж оброблено.")


# Конкретна команда для бронювання столика
class BookTableCommand(Command):
    def __init__(self, receiver):
        self._receiver = receiver

    def execute(self):
        self._receiver.book_table()


# Конкретна команда для замовлення страви
class OrderDishCommand(Command):
    def __init__(self, receiver):
        self._receiver = receiver

    def execute(self):
        self._receiver.order_dish()


# Конкретна команда для обробки платежу
class ProcessPaymentCommand(Command):
    def __init__(self, receiver):
        self._receiver = receiver

    def execute(self):
        self._receiver.process_payment()


# Клас, що викликає команди
class CommandInvoker:
    def __init__(self):
        self._command = None

    def set_command(self, command):
        self._command = command

    def execute_command(self):
        self._command.execute()


# Клієнт
if __name__ == "__main__":
    # Створення отримувача
    receiver = ReservationReceiver()

    # Створення конкретних команд
    book_table_command = BookTableCommand(receiver)
    order_dish_command = OrderDishCommand(receiver)
    process_payment_command = ProcessPaymentCommand(receiver)

    # Створення інвокера
    invoker = CommandInvoker()

    # Виконання команд через інвокера
    invoker.set_command(book_table_command)
    invoker.execute_command()

    invoker.set_command(order_dish_command)
    invoker.execute_command()

    invoker.set_command(process_payment_command)
    invoker.execute_command()
