class Table:
    def __init__(self, table_id):
        self.table_id = table_id
        self.is_reserved = False

    def __str__(self):
        return f"Столик #{self.table_id} (Зарезервовано: {self.is_reserved})"

class TablePool:
    def __init__(self, count):
        self.available_tables = [Table(i) for i in range(1, count + 1)]
        self.reserved_tables = []

    def get_table(self):
        if self.available_tables:
            table = self.available_tables.pop(0)
            table.is_reserved = True
            self.reserved_tables.append(table)
            return table
        else:
            print("Немає доступних столиків!")
            return None

    def release_table(self, table):
        if table in self.reserved_tables:
            self.reserved_tables.remove(table)
            table.is_reserved = False
            self.available_tables.append(table)
            print(f"Столик #{table.table_id} звільнено.")

    def display_status(self):
        print("Доступні столики:")
        for table in self.available_tables:
            print(table)
        print("Зарезервовані столики:")
        for table in self.reserved_tables:
            print(table)

# Демонстрація
if __name__ == "__main__":
    table_pool = TablePool(5)
    print("Бронювання столиків в ресторані:")

    table1 = table_pool.get_table()
    table2 = table_pool.get_table()

    table_pool.display_status()

    table_pool.release_table(table1)

    table_pool.display_status()
