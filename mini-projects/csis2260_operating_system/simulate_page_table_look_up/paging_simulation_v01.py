PAGE_SIZE = 4096  # 4KB
PAGE_TABLE = {
    0: 3,  # Page 0 → Frame 3
    1: 7,  # Page 1 → Frame 7
    2: 5,  # Page 2 → Frame 5
    3: 1   # Page 3 → Frame 1
}

def translate_address(logical_address):
    page_number = logical_address // PAGE_SIZE
    offset = logical_address % PAGE_SIZE

    if page_number not in PAGE_TABLE:
        print(f"Page fault! Page {page_number} not in memory.")
        return None

    frame_number = PAGE_TABLE[page_number]
    physical_address = frame_number * PAGE_SIZE + offset
    print(f"Logical: {logical_address} → Page: {page_number}, Offset: {offset}")
    print(f"Physical Address: {physical_address}")
    return physical_address

def main():
    logical_addresses = [1024, 5000, 11430, 16385, 20000]  # Try different values
    for addr in logical_addresses:
        translate_address(addr)
        print("-" * 40)

if __name__ == '__main__':
    main()