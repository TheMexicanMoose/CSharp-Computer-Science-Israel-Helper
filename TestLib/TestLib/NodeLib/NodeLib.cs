namespace TestLib.NodeLib;
using Unit4.CollectionsLib;

public class NodeLib
{
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
            current = current.GetNext();
            if (index == -1 && current.GetNext() == null)
            {
                current.SetValue(newValue);
                return;
            }
        }
    }
    
    public static T Get_By_Index_Node<T>(Node<T> chain, int index)
    {
        Node<T> current = chain;
        int count = 0;

        while (current != null)
        {
            if (count == index)
            {
                return current.GetValue();
            }
            count++;
            current = current.GetNext();
            if (index == -1 && current.GetNext() == null)
            {
                return current.GetValue();
            }
        }
        if (index >= count)
        {
            return default(T)!;
        }
        return current!.GetValue();
    }
    
    public static Node<int> CreateList(params int[] values)// O(n) 
    {
        if (values.Length == 0) return null!;// O(1)
        Node<int> head = new Node<int>(values[0]);// O(1)
        Node<int> current = head;// O(1)
        for (int i = 1; i < values.Length; i++)// O(n)
        {
            current.SetNext(new Node<int>(values[i]));// O(1)
            current = current.GetNext();// O(1)
        }
        return head;// O(1)
    }
    
    public static void PrintList<TT>(Node<TT>? q)// O(n) הדפסת רשימה מקושרת
    {
        if (q == null)// O(1)
        {
            Console.WriteLine("רשימה רקה");// O(1)
            return;// O(1)
        }
        while (q != null)// O(n)
        {
            Console.Write(q.GetValue() + " ");// O(1)
            q = q.GetNext();// O(1)
        }
        Console.WriteLine();// O(1)
    }
    
    public static int LengthLst<T>(Node<T> q)// O(n) אורך רשימה מקושרת
    {
        int count = 0;// O(1)
        while (q != null)// O(n)
        {
            count++;// O(1)
            q = q.GetNext();// O(1)
        }
        return count;// O(1)
    }
    
    public static Node<TT> Revers<TT>(Node<TT> root)// O(n) הפיכת רשימה מקושרת
    {
        Node<TT> prev = null!;// שמירת הקודם
        Node<TT> current = root;// שמירת הנוכחי

        while (current != null)// O(n)
        {
            Node<TT> next = current.GetNext();// שמירת הבא
            current.SetNext(prev);// הפיכת הכיוון
            prev = current;// שמירת הקודם
            current = next;// התקדמות
        }

        return prev;   //  הראש החדש של הרשימה
    }
    
    public static bool IsExistNode<TT>(Node<TT> head, TT value)// o(n) חיפוש ערך ברשימה מקושרת
    {
        Node<TT> current = head;// o(1) שמירת הנוכחי
        while (current != null)// o(n) כל עוד הנוכחי לא ריק
        {
            if (current.GetValue()!.Equals(value))// o(1) אם הערך שווה לערך המבוקש
                return true;// o(1) מחזיר אמת
            current = current.GetNext();// o(1) התקדמות לנוכחי הבא
        }
        return false;// o(1) מחזיר שקר
    }
    
    public static bool IsEqualLists<TT>(Node<TT> head1, Node<TT> head2)// o(n) השוואת שתי רשימות מקושרות
    {
        Node<TT> current1 = head1;// o(1) שמירת הנוכחי של הרשימה הראשונה
        Node<TT> current2 = head2;// o(1) שמירת הנוכחי של הרשימה השנייה
        while (current1 != null && current2 != null)// o(n) כל עוד הנוכחי של שתיהן לא ריק
        {
            if (!current1.GetValue()!.Equals(current2.GetValue()))// o(1) אם הערכים לא שווים
                return false;// o(1) מחזיר שקר
            current1 = current1.GetNext();// o(1) התקדמות לנוכחי הבא ברשימה הראשונה
            current2 = current2.GetNext();// o(1) התקדמות לנוכחי הבא ברשימה השנייה
        }
        return current1 == null && current2 == null;// o(1) מחזיר אמת אם שתיהן ריקות, אחרת שקר
    }
}
