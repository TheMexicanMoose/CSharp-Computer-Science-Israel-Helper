namespace Test.QueueLib;
using Unit4.CollectionsLib;

/// <summary>
/// Utility functions for working with Queue&lt;T&gt;.
/// All methods preserve the original queue content.
/// </summary>
public class QueueFuncs
{
    /// <summary>
    /// Returns the element at the given index in the queue.
    /// Special case: index == -1 returns the last element in the queue.
    /// </summary>
    /// <typeparam name="T">Type of elements in the queue</typeparam>
    /// <param name="q">The queue</param>
    /// <param name="index">Index to retrieve</param>
    /// <returns>The element at the given index, or default if not found</returns>
    public static T Get_By_Index_Queue<T>(Queue<T> q, int index)
    {
        if (q.IsEmpty())
            return default(T) ?? throw new InvalidOperationException();

        Queue<T> temp = new Queue<T>();   // Auxiliary queue
        T result = default(T)!;           // Result element
        T lastItem = default(T)!;         // Stores the last element in the queue
        int count = 0;                    // Index counter
        bool found = false;               // Flag to track index match

        // Step 1: Empty the queue into a temporary queue while searching
        while (!q.IsEmpty())
        {
            T current = q.Remove();

            // Check for requested index
            if (count == index)
            {
                result = current;
                found = true;
            }

            // Keep track of the last element
            lastItem = current;

            temp.Insert(current);
            count++;
        }

        // Step 2: Restore elements back to the original queue
        while (!temp.IsEmpty())
        {
            q.Insert(temp.Remove());
        }

        // Special logic: index -1 returns the last element
        if (index == -1)
        {
            return lastItem;
        }

        // If index was not found
        if (!found)
        {
            return default(T)!;
        }

        return result;
    }

    /// <summary>
    /// Replaces the element at the given index in the queue with a new value.
    /// </summary>
    /// <typeparam name="T">Type of elements in the queue</typeparam>
    /// <param name="q">The queue</param>
    /// <param name="index">Index to replace</param>
    /// <param name="newValue">New value to insert</param>
    public static void Set_By_Index_Queue<T>(Queue<T> q, int index, T newValue)
    {
        if (q.IsEmpty())
        {
        }

        Queue<T> temp = new Queue<T>();   // Auxiliary queue
        int count = 0;                    // Index counter
        bool found = false;               // Flag to track index match

        // Step 1: Empty queue and replace value at given index
        while (!q.IsEmpty())
        {
            T current = q.Remove();

            if (count == index)
            {
                temp.Insert(newValue);    // Insert new value instead of old one
                found = true;
            }
            else
            {
                temp.Insert(current);     // Keep original value
            }

            count++;
        }

        // Step 2: Restore elements back to the original queue
        while (!temp.IsEmpty())
        {
            q.Insert(temp.Remove());
        }

        // If index was not found, nothing happens
        if (!found)
        {
        }
    }

    /// <summary>
    /// Calculates the length of the queue.
    /// Time complexity: O(n)
    /// </summary>
    /// <typeparam name="T">Type of elements in the queue</typeparam>
    /// <param name="q">The queue</param>
    /// <returns>Number of elements in the queue</returns>
    public static int LenghtQ<T>(Queue<T> q)
    {
        Queue<T> temp = new Queue<T>();   // Auxiliary queue
        int count = 0;                    // Counter

        // Move all elements to temp queue and count them
        while (!q.IsEmpty())
        {
            temp.Insert(q.Remove());
            count++;
        }

        // Restore original queue
        while (!temp.IsEmpty())
            q.Insert(temp.Remove());

        return count;
    }

    /// <summary>
    /// Creates and returns a copy of the given queue.
    /// Time complexity: O(n)
    /// </summary>
    /// <typeparam name="T">Type of elements in the queue</typeparam>
    /// <param name="q">The queue to copy</param>
    /// <returns>A new queue containing the same elements</returns>
    public static Queue<T> CopyQ<T>(Queue<T> q)
    {
        Queue<T> newQ = new Queue<T>();   // New queue (copy)
        Queue<T> temp = new Queue<T>();   // Auxiliary queue

        // Empty original queue while copying elements
        while (!q.IsEmpty())
        {
            T item = q.Remove();
            newQ.Insert(item);
            temp.Insert(item);
        }

        // Restore original queue
        while (!temp.IsEmpty())
        {
            q.Insert(temp.Remove());
        }

        return newQ;
    }

    /// <summary>
    /// Checks whether a given value exists in the queue.
    /// Time complexity: O(n)
    /// </summary>
    /// <typeparam name="TT">Type of elements in the queue</typeparam>
    /// <param name="q">The queue</param>
    /// <param name="value">Value to search for</param>
    /// <returns>True if value exists, otherwise false</returns>
    public static bool DoesExistQ<TT>(Queue<TT> q, TT value)
    {
        Queue<TT> temp = new Queue<TT>(); // Auxiliary queue
        bool found = false;               // Found flag

        // Search while preserving queue
        while (!q.IsEmpty())
        {
            TT item = q.Remove();
            if (item!.Equals(value))
                found = true;

            temp.Insert(item);
        }

        // Restore original queue
        while (!temp.IsEmpty())
        {
            q.Insert(temp.Remove());
        }

        return found;
    }

    /// <summary>
    /// Checks whether two queues are identical in size and order.
    /// Time complexity: O(n)
    /// </summary>
    /// <typeparam name="TT">Type of elements in the queues</typeparam>
    /// <param name="q1">First queue</param>
    /// <param name="q2">Second queue</param>
    /// <returns>True if queues are identical, otherwise false</returns>
    public static bool IsIdentical<TT>(Queue<TT> q1, Queue<TT> q2)
    {
        Queue<TT> temp1 = new Queue<TT>(); // Auxiliary queue for q1
        Queue<TT> temp2 = new Queue<TT>(); // Auxiliary queue for q2
        bool identical = true;             // Identity flag

        // Compare elements while preserving order
        while (identical && !(q1.IsEmpty() && q2.IsEmpty()))
        {
            // If one queue is empty and the other is not
            if (q1.IsEmpty() || q2.IsEmpty())
            {
                identical = false;
            }
            else
            {
                TT item1 = q1.Remove();
                TT item2 = q2.Remove();

                if (!item1!.Equals(item2))
                    identical = false;

                temp1.Insert(item1);
                temp2.Insert(item2);
            }
        }

        // Restore both queues
        while (!temp1.IsEmpty())
            q1.Insert(temp1.Remove());

        while (!temp2.IsEmpty())
            q2.Insert(temp2.Remove());

        return identical;
    }
}
