
def main():
    # constants
    burst_times = [5, 3, 1, 2]
    bursts = [5, 3, 1, 2]
    arrival_times = [0, 1, 2, 3]
    completion_times = [0, 0, 0, 0]
    turnaround_times = [0, 0, 0, 0]
    waiting_times = [0, 0, 0, 0]
    quantum = 2
    # variables
    time = 0
    results = []

    def is_arrived(idx: int) -> bool:
        return time >= arrival_times[idx]

    while True:
        if all(burst == 0 for burst in bursts):
            results.append((time, "finished"))
            break
        for i, burst in enumerate(bursts):
            if not is_arrived(i):
                continue
            if burst == 0:
                continue
            label = f"P{i + 1}"
            results.append((time, label))
            if burst > quantum:
                bursts[i] -= quantum
                time += quantum
            elif burst < quantum:
                bursts[i] = 0
                time += burst
                completion_times[i] = time
            elif burst == quantum:
                bursts[i] -= quantum
                time += quantum
                completion_times[i] = time
            else:
                print("error")
                break

    for t, label in results:
        print(f"{t}  {label}  ", end='')
    print("\n")

    for i, completion_time in enumerate(completion_times):
        print(f"P{i + 1}  {completion_time}  ", end='')
    print("\n")

    for i in range(0, len(arrival_times)):
        turnaround_times[i] = completion_times[i] - arrival_times[i]
        waiting_times[i] = turnaround_times[i] - burst_times[i]

    for i, turnaround_time in enumerate(turnaround_times):
        print(f"P{i + 1}  {turnaround_time}  ", end='')
    print(f"Average : {sum(turnaround_times) / len(turnaround_times)}")
    print("\n")

    for i, waiting_time in enumerate(waiting_times):
        print(f"P{i + 1}  {waiting_time}  ", end='')
    print(f"Average : {sum(waiting_times) / len(waiting_times)}")
    print("\n")


if __name__ == '__main__':
    main()