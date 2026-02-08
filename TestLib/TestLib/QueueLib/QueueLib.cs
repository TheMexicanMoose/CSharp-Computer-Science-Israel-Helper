namespace TestLib.QueueLib;
using Unit4.CollectionsLib;

public class QueueLib
{
    /// <summary>
    /// מחזיר את האיבר לפי אינדקס. -1 מחזיר את האחרון
    /// סיבוכיות: O(n)
    /// הערות: מתעדכן לתור המקורי לאחר קריאה
    /// </summary>
    public static T Get_By_Index_Queue<T>(Queue<T> q, int index)
    {
        if (q.IsEmpty())
            return default(T) ?? throw new InvalidOperationException();

        Queue<T> temp = new Queue<T>(); // תור זמני לשחזור
        T result = default(T)!;         // התוצאה
        T lastItem = default(T)!;       // האיבר האחרון
        int count = 0;                  
        bool found = false;

        while (!q.IsEmpty())
        {
            T current = q.Remove();

            // בדיקה אם זה האינדקס המבוקש
            if (count == index)
            {
                result = current;
                found = true;
            }

            lastItem = current;       // תמיד שומרים את האחרון
            temp.Insert(current);
            count++;
        }

        // שחזור התור המקורי
        while (!temp.IsEmpty())
            q.Insert(temp.Remove());

        if (index == -1) return lastItem;
        if (!found) return default(T)!;

        return result;
    }

    /// <summary>
    /// מחליף איבר בתור לפי אינדקס
    /// סיבוכיות: O(n)
    /// הערות: אם האינדקס לא קיים, התור נשאר ללא שינוי
    /// </summary>
    public static void Set_By_Index_Queue<T>(Queue<T> q, int index, T newValue)
    {
        if (q.IsEmpty()) return;

        Queue<T> temp = new Queue<T>();
        int count = 0;
        bool found = false;

        while (!q.IsEmpty())
        {
            T current = q.Remove();
            if (count == index)
            {
                temp.Insert(newValue); // מחליפים את האיבר
                found = true;
            }
            else temp.Insert(current);

            count++;
        }

        // שחזור התור המקורי
        while (!temp.IsEmpty())
            q.Insert(temp.Remove());
    }

    /// <summary>
    /// מחזיר את אורך התור
    /// סיבוכיות: O(n)
    /// הערות: מתעדכן לתור המקורי לאחר ספירה
    /// </summary>
    public static int LenghtQ<T>(Queue<T> q)
    {
        Queue<T> temp = new Queue<T>();
        int count = 0;

        while (!q.IsEmpty())
        {
            temp.Insert(q.Remove());
            count++;
        }

        while (!temp.IsEmpty())
            q.Insert(temp.Remove());

        return count;
    }

    /// <summary>
    /// מחזיר עותק של התור
    /// סיבוכיות: O(n)
    /// הערות: התור המקורי נשאר ללא שינוי
    /// </summary>
    public static Queue<T> CopyQ<T>(Queue<T> q)
    {
        Queue<T> newQ = new Queue<T>();
        Queue<T> temp = new Queue<T>();

        while (!q.IsEmpty())
        {
            T item = q.Remove();
            newQ.Insert(item);
            temp.Insert(item); // לשחזור התור המקורי
        }

        while (!temp.IsEmpty())
            q.Insert(temp.Remove());

        return newQ;
    }

    /// <summary>
    /// בודק אם איבר קיים בתור
    /// סיבוכיות: O(n)
    /// הערות: התור נשאר ללא שינוי
    /// </summary>
    public static bool DoesExistQ<TT>(Queue<TT> q, TT value)
    {
        Queue<TT> temp = new Queue<TT>();
        bool found = false;

        while (!q.IsEmpty())
        {
            TT item = q.Remove();
            if (item!.Equals(value)) found = true; // בדיקה שווה
            temp.Insert(item);
        }

        while (!temp.IsEmpty())
            q.Insert(temp.Remove());

        return found;
    }

    /// <summary>
    /// בודק אם שני תורים זהים בגודל ובסדר
    /// סיבוכיות: O(n)
    /// הערות: מחזיר false אם מספר האיברים שונה
    /// </summary>
    public static bool IsIdentical<TT>(Queue<TT> q1, Queue<TT> q2)
    {
        Queue<TT> temp1 = new Queue<TT>();
        Queue<TT> temp2 = new Queue<TT>();
        bool identical = true;

        while (identical && !(q1.IsEmpty() && q2.IsEmpty()))
        {
            if (q1.IsEmpty() || q2.IsEmpty())
            {
                identical = false; // מספר שונה של איברים
            }
            else
            {
                TT item1 = q1.Remove();
                TT item2 = q2.Remove();
                if (!item1!.Equals(item2)) identical = false;

                temp1.Insert(item1);
                temp2.Insert(item2);
            }
        }

        while (!temp1.IsEmpty())
            q1.Insert(temp1.Remove());
        while (!temp2.IsEmpty())
            q2.Insert(temp2.Remove());

        return identical;
    }
}
