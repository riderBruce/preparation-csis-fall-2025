# ✅ Day 5 Preview: Topics

1. Virtual Memory and Address Translation

   - Logical Address → Physical Address
   - Page Number, Page Offset
   - Frame Number

2. Page Table

   - Maps virtual pages to physical frames
   - Simple page table structure
   - Basic translation steps

3. Page Faults

   - When page is not in RAM, needs to be loaded from disk (simulated)

## ✍️ Let’s Start with an Explanation

Here’s a simple example of logical → physical address translation:

- Page size = 4 KB (4096 bytes)
- Logical address = 11,430
- ➤ Page Number = 11430 // 4096 = 2
- ➤ Offset = 11430 % 4096 = 2238
- ➤ Suppose page 2 is mapped to frame 5 → Physical address = 5 \* 4096 + 2238 = 22518

## 🧪 Code Simulation: Page Table Lookup

Here’s a simple simulation code to translate logical addresses:

```python
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
```

You can try this in your environment and tweak the PAGE_TABLE or logical_addresses.

Let’s build a simple paging simulation where:

- A process has a virtual address like 0x1F4 (which we’ll treat as decimal 500)
- The OS divides memory into pages (e.g., 100 bytes per page)
- A page table maps virtual pages to physical frames
- We simulate translating a virtual address to a physical address

## 🧮 Step-by-Step Plan: Paging Simulation

We’ll simulate:

1. A page table like { page_number: frame_number }
2. Address translation logic:

   - virtual_address = page_number \* page_size + offset
   - physical_address = frame_number \* page_size + offset

3. Memory access: Print the result of translating virtual address

## ✅ Python Simulation Code

```python
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
```

## 🔍 Try this

You can test it by:

- Changing page size (e.g., 256)
- Mapping different pages
- Trying to access unmapped pages to trigger a page fault

Would you like to:

- Add page fault handling (load from disk)?
- Or simulate TLB (Translation Lookaside Buffer)?
- Or log access in a file (tie in File I/O)?
