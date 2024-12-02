from abc import ABC, abstractmethod

# Стратегія
class PaymentStrategy(ABC):
    @abstractmethod
    def pay(self, amount: int):
        pass

# Контекст
class OrderContext:
    def __init__(self, payment_strategy: PaymentStrategy):
        self._payment_strategy = payment_strategy

    def set_payment_strategy(self, payment_strategy: PaymentStrategy):
        self._payment_strategy = payment_strategy

    def process_payment(self, amount: int):
        self._payment_strategy.pay(amount)

# Конкретна стратегія: Оплата кредитною карткою
class CreditCardPayment(PaymentStrategy):
    def pay(self, amount: int):
        print(f"Оплата {amount} через кредитну картку.")

# Конкретна стратегія: Оплата через PayPal
class PayPalPayment(PaymentStrategy):
    def pay(self, amount: int):
        print(f"Оплата {amount} через PayPal.")

# Конкретна стратегія: Оплата готівкою
class CashPayment(PaymentStrategy):
    def pay(self, amount: int):
        print(f"Оплата {amount} готівкою.")

# Клієнт
if __name__ == "__main__":
    order = OrderContext(CreditCardPayment())
    order.process_payment(100)

    order.set_payment_strategy(PayPalPayment())
    order.process_payment(200)

    order.set_payment_strategy(CashPayment())
    order.process_payment(150)
