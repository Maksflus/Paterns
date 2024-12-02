# Абстрактний обробник
class ReservationHandler:
    def __init__(self):
        self._next_handler = None

    def set_next_handler(self, next_handler):
        self._next_handler = next_handler

    def handle_request(self, request):
        raise NotImplementedError("Subclasses must implement this method")


# Конкретний обробник для перевірки вільних місць
class AvailableSeatsHandler(ReservationHandler):
    def handle_request(self, request):
        if request == "check seats":
            print("Перевірка наявності вільних місць...")
        elif self._next_handler:
            self._next_handler.handle_request(request)  # Передача запиту наступному обробнику


# Конкретний обробник для оплати
class PaymentHandler(ReservationHandler):
    def handle_request(self, request):
        if request == "payment":
            print("Обробка платежу...")
        elif self._next_handler:
            self._next_handler.handle_request(request)  # Передача запиту наступному обробнику


# Конкретний обробник для замовлення страв
class OrderDishHandler(ReservationHandler):
    def handle_request(self, request):
        if request == "order dish":
            print("Замовлення страви...")
        elif self._next_handler:
            self._next_handler.handle_request(request)  # Передача запиту наступному обробнику


# Клієнт, який створює ланцюг обробників і ініціює запит
if __name__ == "__main__":
    # Створення обробників
    available_seats = AvailableSeatsHandler()
    payment = PaymentHandler()
    order_dish = OrderDishHandler()

    # Формування ланцюга обробників
    available_seats.set_next_handler(payment)
    payment.set_next_handler(order_dish)

    # Ініціалізація запиту
    available_seats.handle_request("check seats")  # Початок з перевірки місць
    available_seats.handle_request("payment")      # Перевірка оплати
    available_seats.handle_request("order dish")   # Замовлення страви
