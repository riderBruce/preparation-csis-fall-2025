from typing import Optional
import time
from dataclasses import dataclass
from datetime import datetime
import csv


@dataclass
class PageEntry:
    page_number: int
    frame_number: int


class PageTable:
    def __init__(self, page_size: int, mapping: dict):
        self.page_size = page_size
        self.mapping = mapping
        self.frame_occupied = [entry.frame_number for entry in self.mapping.values()]
        self.page_faults = 0
        self.page_hits = 0
        now = datetime.now().strftime('%Y%m%d_%H%M%S')
        self.log_file = f"paging_log_{now}.csv"

    def translate_address(self, logical_address: int) -> Optional[int]:
        page_number, offset = divmod(logical_address, self.page_size)
        if page_number not in self.mapping:
            print(f"Page Fault! Page {page_number} not in memory.")
            self.page_faults += 1
            free_frame = self.get_free_frame()
            if free_frame is None:
                return None
            self.mapping[page_number] = PageEntry(page_number, free_frame)
            self.frame_occupied.append(free_frame)
        entry = self.mapping[page_number]
        physical_address = entry.frame_number * self.page_size + offset
        print(
            f"Logical Address: {logical_address} -> Page Number: {page_number}, Frame Number: {entry.frame_number}, Offeset: {offset}")
        print(f" -> Physical Address : {physical_address}")
        self.page_hits += 1
        return physical_address

    def get_free_frame(self) -> Optional[int]:
        print("Get an Blank Frame...")
        time.sleep(1)
        for frame_num in range(10):
            if frame_num not in self.frame_occupied:
                return frame_num
        print("There's Not available Frames. Please wait.")
        return None

    def print_mapping(self):
        print(">> Current Memory Mapping Statues << ")
        for entry in self.mapping.values():
            print(f"Logical Page: {entry.page_number} -> Physical Frame: {entry.frame_number}")
        print("-" * 80)

    def export_memory_map(self):
        filename = self.log_file
        with open(filename, mode='w', newline='') as file:
            writer = csv.writer(file)
            writer.writerow(["logical_page", "physical_frame"])
            for entry in self.mapping.values():
                writer.writerow([entry.page_number, entry.frame_number])
        print(f"Memory mapping exported to {filename}")


def main():
    page_size = 500
    mapping = {
        0: PageEntry(0, 4),
        1: PageEntry(1, 3),
        2: PageEntry(2, 5),
        3: PageEntry(3, 6),
    }
    pt = PageTable(page_size, mapping)

    logical_addresses = [200, 800, 1100, 1700, 2500, 3000, 4000, 5000, 10000, 20000, 40000]
    for addr in logical_addresses:
        pt.translate_address(addr)
        print("-" * 80)

    pt.print_mapping()
    pt.export_memory_map()

    print(f"Page hits: {pt.page_hits}, Page Faults: {pt.page_faults}")


if __name__ == '__main__':
    main()
