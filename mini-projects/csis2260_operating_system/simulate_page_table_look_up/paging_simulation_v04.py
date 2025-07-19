class PageTable:
    def __init__(self, page_size):
        self.page_size = page_size
        self.table = {}  # page_number: frame_number

    def map_page(self, page_number, frame_number):
        self.table[page_number] = frame_number

    def translate(self, virtual_address):
        page_number = virtual_address // self.page_size
        offset = virtual_address % self.page_size

        if page_number not in self.table:
            print(f"❌ Page fault! Page {page_number} not in memory.")
            return None

        frame_number = self.table[page_number]
        physical_address = frame_number * self.page_size + offset
        print(f"✅ VA {virtual_address} → Page {page_number}, Offset {offset}")
        print(f"→ Mapped to Frame {frame_number} → PA {physical_address}")
        return physical_address


def main():
    page_size = 100
    pt = PageTable(page_size)

    # Simulate page table mappings
    pt.map_page(0, 5)
    pt.map_page(1, 9)
    pt.map_page(2, 3)

    # Simulate address translation
    pt.translate(150)  # Page 1, Offset 50
    pt.translate(230)  # Page 2, Offset 30
    pt.translate(350)  # Page 3 → ❌ Page Fault


if __name__ == '__main__':
    main()