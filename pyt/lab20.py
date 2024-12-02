from abc import ABC, abstractmethod

# Абстракція: Стан
class OrderState(ABC):
    @abstractmethod
    def handle_request(self, context):
        pass

# Контекст: Замовлення
class OrderContext:
    def __init__(self, state: OrderState):
        self._state = state

    def set_state(self, state: OrderState):
        self._state = state

    def request(self):
        self._state.handle_request(self)

# Конкретний стан: Замовлення чекає на підтвердження
class PendingState(OrderState):
    def handle_request(self, context):
        print("Замовлення чекає на підтвердження.")
        context.set_state(ConfirmedState())

# Конкретний стан: Замовлення підтверджено
class ConfirmedState(OrderState):
    def handle_request(self, context):
        print("Замовлення підтверджено. Починається обробка.")
        context.set_state(ProcessingState())

# Конкретний стан: Замовлення обробляється
class ProcessingState(OrderState):
    def handle_request(self, context):
        print("Замовлення обробляється.")
        context.set_state(CompletedState())

# Конкретний стан: Замовлення завершене
class CompletedState(OrderState):
    def handle_request(self, context):
        print("Замовлення завершено.")

# Клієнт
if __name__ == "__main__":
    order = OrderContext(PendingState())

    order.request()  # Замовлення чекає на підтвердження
    order.request()  # Замовлення підтверджено
    order.request()  # Замовлення обробляється
    order.request()  # Замовлення завершено
