import threading

class ReservationSystem:
    _instance = None
    _lock = threading.Lock()

    def __new__(cls, *args, **kwargs):
        if not cls._instance:
            with cls._lock:
                if not cls._instance:
                    cls._instance = super().__new__(cls, *args, **kwargs)
        return cls._instance

    def __init__(self):
        if not hasattr(self, "initialized"):
            self.initialized = True
            print("Ініціалізація системи бронювання...")

    def book_table(self, table_number):
        print(f"Столик №{table_number} заброньовано.")

# Демонстрація
if __name__ == "__main__":
    system1 = ReservationSystem()
    system1.book_table(5)

    system2 = ReservationSystem()
    system2.book_table(3)

    print(system1 is system2)  # True
