# DataStructures
## Description
This project provides implementations of various fundamental data structures in C#. Each data structure includes basic operations and demonstrates usage with example code.
## Features
- Array
- Linked List
- Stack
- Queue
- Binary Tree
- Binary Search Tree
- Hash Table
- Graph
## Installation
1. Clone the repository:
   sh
   git clone https://github.com/HalilSar/DataStructures.git
   
2. Open the project in Visual Studio or your preferred C# IDE.


## Usage
### Array
csharp
int[] array = new int[10];
array[0] = 1;


### Linked List
```csharp
LinkedList<int> list = new LinkedList<int>();
list.AddLast(1);
list.AddLast(2);
```

### Stack
```csharp
Stack<int> stack = new Stack<int>();
stack.Push(1);
stack.Push(2);
int top = stack.Pop();
```

### Queue
```csharp
Queue<int> queue = new Queue<int>();
queue.Enqueue(1);
queue.Enqueue(2);
int front = queue.Dequeue();
```

### Binary Tree
```csharp
BinaryTree tree = new BinaryTree();
tree.Insert(5);
tree.Insert(3);
tree.Insert(7);
```

### Hash Table
```csharp
HashTable<int, string> table = new HashTable<int, string>();
table.Add(1, "One");
string value = table[1];
```
---

This README provides a clear overview of the project, its features, and how to use the various data structures implemented in C#.
