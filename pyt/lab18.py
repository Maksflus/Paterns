# Хранитель
class OrderMemento:
    def __init__(self, state):
        self._state = state

    @property
    def state(self):
        return self._state

# Той, хто створює Memento
class OrderSystem:
    def __init__(self, initial_state):
        self._state = initial_state

    def create_memento(self):
        return OrderMemento(self._state)

    def restore_memento(self, memento):
        self._state = memento.state

    def print_state(self):
        print(f"Стан замовлення: {self._state}")

# Доглядач
class Caretaker:
    def __init__(self):
        self._order_history = []

    def save(self, memento):
        self._order_history.append(memento)

    def get(self, index):
        return self._order_history[index]

# Клієнт
if __name__ == "__main__":
    order_system = OrderSystem("Замовлення обробляється")
    caretaker = Caretaker()

    order_system.print_state()

    # Зберігаємо стан
    caretaker.save(order_system.create_memento())

    order_system._state = "Замовлення завершено"
    order_system.print_state()

    # Відновлюємо стан
    order_system.restore_memento(caretaker.get(0))
    order_system.print_state()
