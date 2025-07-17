class Process:
    def __init__(self, pid, size):
        self.pid = pid
        self.size = size


class MemoryManager:
    def __init__(self, total_frames):
        self.total_frames: int = total_frames
        self.frames: list = [None] * total_frames  # None means free
        self.history: list = []  # track order for optional swapping

    def allocate(self, process):
        while True:
            # not enough free indices
            free_indices_count = self.frames.count(None)
            if free_indices_count < process.size:
                print(f"⚠️ Memory full. Swapping out P{self.history[0]}")
                self.swap_out(self.history[0])
                continue

            start_idx = self.find_first_fit(process.size)

            # not enough big block
            if start_idx is None:
                print(f"❌ Not enough contiguous space for P{process.pid}. Swapping out P{self.history[0]}")
                self.swap_out(self.history[0])
                continue

            # allocate
            for i in range(start_idx, start_idx + process.size):
                self.frames[i] = process.pid
            self.history.append(process.pid)
            print(f"✅ Allocated P{process.pid} to frames {start_idx} to {start_idx + process.size - 1}")
            break

    def find_first_fit(self, size: int):
        for i in range(self.total_frames - size + 1):
            if self.is_contiguous_free_block(i, size):
                return i
        return None

    def is_contiguous_free_block(self, start_idx, size):
        for i in range(size):
            if self.frames[start_idx + i] is not None:
                return False
        return True

    def swap_out(self, pid):
        for i in range(self.total_frames):
            if self.frames[i] == pid:
                self.frames[i] = None
        self.history.remove(pid)

    def print_frames(self):
        print("Memory Frames:")
        for i, f in enumerate(self.frames):
            print(f"{i}: {'_' if f is None else 'P' + str(f)}", end='  ')
        print("\n")


# 🧪 Example usage
def main():
    memory = MemoryManager(total_frames=10)

    processes = [
        Process(1, 3),
        Process(2, 4),
        Process(3, 2),
        Process(4, 5),
        Process(5, 3),
        Process(6, 2), # Will trigger swap
    ]

    for p in processes:
        memory.allocate(p)
        memory.print_frames()


if __name__ == '__main__':
    main()