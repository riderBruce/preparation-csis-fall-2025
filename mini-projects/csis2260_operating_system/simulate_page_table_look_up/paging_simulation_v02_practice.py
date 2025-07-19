from typing import Optional

PAGE_SIZE = 1024 * 4
PAGE_TABLE = {
    0: 4,
    1: 3,
    2: 2,
    3: 6,
}


def translate_address(logical_address: int) -> Optional[int]:
    page_number, offset = divmod(logical_address, PAGE_SIZE)
    if page_number not in PAGE_TABLE:
        print(f"Page Fault! Page {page_number} not in memory.")
        return None
    physical_address = PAGE_TABLE[page_number] * PAGE_SIZE + offset
    print(f"Logical Address: {logical_address} -> Page Number: {page_number}, Frame Number: {PAGE_TABLE[page_number]}, Offeset: {offset}")
    print(f" -> Physical Address : {physical_address}")
    return physical_address


def main():
    logical_addresses = [3000, 4000, 5000, 10000, 20000]
    for l_address in logical_addresses:
        translate_address(l_address)
        print("-" * 60)


if __name__ == '__main__':
    main()