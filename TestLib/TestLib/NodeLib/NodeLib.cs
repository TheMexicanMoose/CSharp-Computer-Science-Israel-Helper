namespace TestLib.NodeLib;
using Unit4.CollectionsLib;

public class NodeLib
{
    /// <summary>
    /// מחליף ערך לפי אינדקס. -1 מחליף את האחרון
    /// סיבוכיות: O(n)
    /// </summary>
    public static void Set_By_Index_Node<T>(Node<T> chain, int index, T newValue)
    {
        Node<T> current = chain;
        int count = 0;
        while (current != null)
        {
            if (count == index)
            {
                current.SetValue(newValue);
                return;
            }
            count++;
            // בדיקה מיוחדת אם רוצים את האיבר האחרון
            if (index == -1 && current.GetNext() != null && current.GetNext().GetNext() == null)
            {
                current.GetNext().SetValue(newValue);
                return;
            }
            current = current.GetNext();
        }
    }

    /// <summary>
    /// מחזיר ערך לפי אינדקס. -1 מחזיר את האחרון
    /// סיבוכיות: O(n)
    /// </summary>
    public static T Get_By_Index_Node<T>(Node<T> chain, int index)
    {
        Node<T> current = chain;
        int count = 0;

        while (current != null)
        {
            if (count == index)
                return current.GetValue();

            // בדיקה מיוחדת עבור -1
            if (index == -1 && current.GetNext() != null && current.GetNext().GetNext() == null)
                return current.GetNext().GetValue();

            current = current.GetNext();
            count++;
        }

        // אם האינדקס גדול מהאורך
        return default(T)!;
    }

    /// <summary>
    /// יוצר רשימה מקושרת ממערך ערכים
    /// סיבוכיות: O(n)
    /// </summary>
    public static Node<int> CreateList(params int[] values)
    {
        if (values.Length == 0) return null!;

        Node<int> head = new Node<int>(values[0]);
        Node<int> current = head;

        for (int i = 1; i < values.Length; i++)
        {
            current.SetNext(new Node<int>(values[i]));
            current = current.GetNext();
        }

        return head;
    }

    /// <summary>
    /// מדפיס רשימה מקושרת
    /// סיבוכיות: O(n)
    /// </summary>
    public static void PrintList<TT>(Node<TT>? q)
    {
        if (q == null)
        {
            Console.WriteLine("רשימה ריקה");
            return;
        }
        while (q != null)
        {
            Console.Write(q.GetValue() + " ");
            q = q.GetNext();
        }
        Console.WriteLine();
    }

    /// <summary>
    /// מחזיר אורך הרשימה
    /// סיבוכיות: O(n)
    /// </summary>
    public static int LengthLst<T>(Node<T> q)
    {
        int count = 0;
        while (q != null)
        {
            count++;
            q = q.GetNext();
        }
        return count;
    }

    /// <summary>
    /// הופך את כיוון הרשימה
    /// סיבוכיות: O(n)
    /// </summary>
    public static Node<TT> Revers<TT>(Node<TT> root)
    {
        Node<TT> prev = null!;
        Node<TT> current = root;

        while (current != null)
        {
            Node<TT> next = current.GetNext();
            current.SetNext(prev); // הפוך כיוון
            prev = current;
            current = next;
        }

        return prev; // ראש חדש
    }

    /// <summary>
    /// בודק אם ערך קיים ברשימה
    /// סיבוכיות: O(n)
    /// </summary>
    public static bool IsExistNode<TT>(Node<TT> head, TT value)
    {
        Node<TT> current = head;
        while (current != null)
        {
            if (current.GetValue()!.Equals(value))
                return true;
            current = current.GetNext();
        }
        return false;
    }

    /// <summary>
    /// בודק אם שתי רשימות זהות בגודל ובערכים
    /// סיבוכיות: O(n)
    /// </summary>
    public static bool IsEqualLists<TT>(Node<TT> head1, Node<TT> head2)
    {
        Node<TT> current1 = head1;
        Node<TT> current2 = head2;

        while (current1 != null && current2 != null)
        {
            if (!current1.GetValue()!.Equals(current2.GetValue()))
                return false;

            current1 = current1.GetNext();
            current2 = current2.GetNext();
        }

        // אמת אם שתיהן נגמרו יחד
        return current1 == null && current2 == null;
    }
}
