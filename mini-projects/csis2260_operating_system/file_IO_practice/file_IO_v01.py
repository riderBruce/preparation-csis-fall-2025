

def write_to_file(file_name, data):
    with open(file_name, mode='w',) as f:
        f.write(data)
    print(f"Data written to {file_name}")


def read_from_file(file_name):
    with open(file_name, mode='r') as f:
        content = f.read()
    print(f"Content of {file_name}")
    print(content)


def main():
    content = "Hello, this is a simulated log entry. \nLet's learn File I/O!"
    file_path = "file_io_practice.txt"
    write_to_file(file_path, content)
    read_from_file(file_path)


if __name__ == "__main__":
    main()

