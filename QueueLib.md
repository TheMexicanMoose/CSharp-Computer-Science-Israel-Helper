# **QueueLib Functions Explaining**
in here I will explain all the functions in of queueLib and how 
to use it

## Implementation In Code
in the code, make sure you have these 2 lines so you can
use the functions

```csharp
using Unit4.collectionLib;
using TestLib.QueueLib;
````

make sure before every function you write
`QueueLib.`

you can also initialise the library as followed to not 
have to write this

```csharp
using static TestLib.QueueLib.QueueLib;
````


## ``Get_By_Index_Queue``
Retrieve an element from a queue by its **index**. Use `-1` to get the **last element**. The original queue remains intact.

### **Syntax**
```csharp
Get_By_Index_Queue<T>(Queue<T> q, int index)
````

#### parameters:

- `q` → The queue to retrieve the element from (`Queue<T>`).

- `index` → The index of the element. Use `-1` to get the last element.

#### Returns:

- Element at the specified index if it exists

- `default(T)` if the index is out of bounds (except `-1`).

- Throws `InvalidOperationException` if the queue is empty.

#### Complexity:

- **O(n)** – iterates through the queue once.

#### Example:

```csharp
var queue = new Queue<int>();
queue.Insert(10);
queue.Insert(20);
queue.Insert(30);

// Get element at index 1
int value = QueueLib.Get_By_Index_Queue(queue, 1); // 20

// Get last element
int last = QueueLib.Get_By_Index_Queue(queue, -1); // 30
````

## ``Set_By_Index_Queue``
Replaces an element in a queue by its **index**.  
If the index does not exist, the queue remains **unchanged**.

### **Syntax**
```csharp
Set_By_Index_Queue<T>(Queue<T> q, int index, T newValue)
````
#### parameters:

- `q` → The queue in which the element will be replaced (`Queue<T>`).
- `index` → The index of the element to replace.
- `newValue` → The new value to insert at the given index.

#### Returns:

- This function does not return a value.
- If the queue is empty or the index is out of bounds, no changes are made.

#### Complexity:

- **O(n)** – iterates through the queue once.

#### Example:

```csharp
var queue = new Queue<int>();
queue.Insert(10);
queue.Insert(20);
queue.Insert(30);

// Replace element at index 1
QueueLib.Set_By_Index_Queue(queue, 1, 99);

// Queue now contains: 10, 99, 30

```

## ``Insert_To_Index_Queue``
Inserts a value into a queue at a **specific index**.  
If the index is `-1`, the value is inserted at the **end of the queue**.

### **Syntax**
```csharp
Insert_To_Index_Queue<T>(Queue<T> q, int index, T newValue)
```
#### parameters:

- `q` → The queue to insert the value into (`Queue<T>`).
- `index` → The index at which to insert the new value. Use `-1` to insert at the end.
- `newValue` → The value to insert into the queue.

#### Returns:

- This function does not return a value.
- If the queue is empty and `index` is not `0`, no changes are made.

#### Complexity:

- **O(n)** – iterates through the queue once.

#### Example:
```csharp
var queue = new Queue<int>();
queue.Insert(10);
queue.Insert(20);
queue.Insert(30);

// Insert at index 1
QueueLib.Insert_To_Index_Queue(queue, 1, 99);
// Queue now contains: 10, 99, 20, 30

// Insert at the end
QueueLib.Insert_To_Index_Queue(queue, -1, 50);
// Queue now contains: 10, 99, 20, 30, 50
````

## ``CopyQ``
Returns a **copy of a queue**.  
The original queue remains **unchanged**.

### **Syntax**
```csharp
CopyQ<T>(Queue<T> q)
```
#### parameters:

- `q` → The queue to copy (`Queue<T>`).

#### Returns:

- A new queue containing the same elements as the original queue.
- The original queue remains unchanged.

#### Complexity:

- **O(n)** – iterates through the queue once.

#### Example:
```csharp
var queue = new Queue<int>();
queue.Insert(10);
queue.Insert(20);
queue.Insert(30);

// Create a copy of the queue
Queue<int> copy = QueueLib.CopyQ(queue);

// Original queue remains unchanged
// copy contains: 10, 20, 30
````

## ``DoesExistQ``
Checks whether a **value exists in a queue**.  
The original queue remains **unchanged**.

### **Syntax**
```csharp
DoesExistQ<T>(Queue<T> q, T value)
```
#### parameters:

- `q` → The queue to search in (`Queue<T>`).
- `value` → The value to search for in the queue.

#### Returns:

- `true` if the value exists in the queue.
- `false` if the value does not exist.

#### Complexity:

- **O(n)** – iterates through the queue once.

#### Example:
```csharp
var queue = new Queue<int>();
queue.Insert(10);
queue.Insert(20);
queue.Insert(30);

bool exists = QueueLib.DoesExistQ(queue, 20); // true
bool notExists = QueueLib.DoesExistQ(queue, 99); // false
````

## IsIdentical
Checks whether **two queues are identical** in both **size and order**.  
Returns `false` if the number of elements or their order differs.

### **Syntax**
```csharp
IsIdentical<T>(Queue<T> q1, Queue<T> q2)
```
#### parameters:

- `q1` → The first queue to compare (`Queue<T>`).
- `q2` → The second queue to compare (`Queue<T>`).

#### Returns:

- `true` if both queues contain the same elements in the same order.
- `false` if the queues differ in size or order.

#### Complexity:

- **O(n)** – iterates through both queues once.

#### Example:
```csharp
var q1 = new Queue<int>();
q1.Insert(10);
q1.Insert(20);
q1.Insert(30);

var q2 = new Queue<int>();
q2.Insert(10);
q2.Insert(20);
q2.Insert(30);

var q3 = new Queue<int>();
q3.Insert(10);
q3.Insert(30);
q3.Insert(20);

bool same1 = QueueLib.IsIdentical(q1, q2); // true
bool same2 = QueueLib.IsIdentical(q1, q3); // false
```
