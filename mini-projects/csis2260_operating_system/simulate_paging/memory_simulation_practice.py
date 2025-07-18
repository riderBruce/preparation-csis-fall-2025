

class Process:
    def __init__(self, pid: int, size: int):
        self.pid = pid
        self.size = size


class MemoryManagement:
    def __init__(self, max_frames: int):
        self.max_frames = max_frames
        self.frames = [None] * max_frames
        self.history = []

    def allocate(self, process):
        while True:
            if self.frames.count(None) < process.size:
                print(f"not enough memory. swapped out {self.history[0]}")
                self.swap_out(self.history[0])
                continue

            start_idx = self.select_first_section(process.size)
            if start_idx is None:
                print(f"not enough contiguous memory. swapped out {self.history[0]}")
                self.swap_out(self.history[0])
                continue

            for n in range(process.size):
                self.frames[start_idx + n] = process.pid
            print(f"allocated P{process.pid} from frame {start_idx} to {start_idx + process.size - 1}.")
            self.history.append(process.pid)
            return

    def select_first_section(self, size):
        for i in range(self.max_frames - size + 1):
            if self.is_contiguous_memory(i, size):
                return i
        return None

    def is_contiguous_memory(self, start_idx, size):
        for i in range(start_idx, start_idx + size):
            if self.frames[i] is not None:
                return False
        return True

    def swap_out(self, pid):
        for i, frame in enumerate(self.frames):
            if frame == pid:
                self.frames[i] = None
        self.history.remove(pid)

    def print_current_statues(self):
        for i, frame in enumerate(self.frames):
            print(f"Frame{i}: {'__' if frame is None else 'P' + str(frame)}", end='  ')
        print("\n")


def main():
    processes = [
        Process(1, 2),
        Process(2, 3),
        Process(3, 3),
        Process(4, 4),
        Process(5, 2),
        Process(6, 2),

    ]

    mm = MemoryManagement(10)
    for p in processes:
        mm.allocate(p)
        mm.print_current_statues()


if __name__ == '__main__':
    main()