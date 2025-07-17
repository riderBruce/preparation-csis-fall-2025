class Process:
    def __init__(self, pid, size):
        self.pid = pid
        self.size = size

class MemoryManager:
    def __init__(self, total_frames):
        self.total_frames = total_frames
        self.frames = [None] * total_frames  # None means free
        self.history = []  # track order for optional swapping

    def allocate(self, process):
        free_indices = [i for i, f in enumerate(self.frames) if f is None]
        if len(free_indices) >= process.size:
            # First fit: find first block big enough
            start = self.find_first_fit(process.size)
            if start is not None:
                for i in range(start, start + process.size):
                    self.frames[i] = process.pid
                self.history.append(process.pid)
                print(f"✅ Allocated P{process.pid} to frames {start} to {start + process.size - 1}")
            else:
                print(f"❌ Not enough contiguous space for P{process.pid}")
        else:
            print(f"⚠️ Memory full. Swapping out P{self.history[0]}")
            self.swap_out(self.history[0])
            self.allocate(process)  # try again

    def find_first_fit(self, size):
        count = 0
        for i in range(self.total_frames):
            if self.frames[i] is None:
                count += 1
                if count == size:
                    return i - size + 1
            else:
                count = 0
        return None

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
        Process(4, 5),  # Will trigger swap
    ]

    for p in processes:
        memory.allocate(p)
        memory.print_frames()

if __name__ == '__main__':
    main()