page_table = {}
page_size = 4  # KB
process_pages = [6, 3, 4]  # Number of pages needed for 3 processes

for pid, num_pages in enumerate(process_pages, start=1):
    page_table[f"P{pid}"] = [f"Frame{frame}" for frame in range(num_pages)]

for process, frames in page_table.items():
    print(f"{process}: {frames}")

