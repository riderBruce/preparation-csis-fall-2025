def append_to_log(file_name, pid, action):
    with open(file_name, mode="a") as f:
        f.write(f"P{pid} | {action}\n")


def main():
    file_path = "file_io_practice_2.txt"
    append_to_log(file_path, 1, "Loaded into memory")
    append_to_log(file_path, 2, "Swapped out")
    append_to_log(file_path, 3, "Completed execution")


if __name__ == '__main__':
    main()