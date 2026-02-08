
namespace Test;
using Unit4.CollectionsLib;
class Test
{
   

    
    


    
    public static BinNode<T> CreateTree<T>(T[] arr, int index = 0)
    {
        if (index >= arr.Length)
            return null;
        BinNode<T> root = new BinNode<T>(arr[index]);
        root.SetLeft(CreateTree(arr, 2 * index + 1));
        root.SetRight(CreateTree(arr, 2 * index + 2));
        return root;
    }
    public static void scan1<t>(BinNode<t> root, Action<t> action)// o(n) סריקה לפי סדר
    {
        if (root == null) return;// o(1) בדיקה אם הצומת ריקה
        action(root.GetValue());// o(1) ביצוע הפעולה על הצומת הנוכחית
        scan1(root.GetLeft(), action);// o(n) סריקה של תת העץ השמאלי
        scan1(root.GetRight(), action);// o(n) סריקה של תת העץ הימני
    }
    public static void scan2<t>(BinNode<t> root, Action<t> action)// o(n) סריקה לפי סדר
    {
        if (root == null) return;// o(1) בדיקה אם הצומת ריקה
        scan2(root.GetLeft(), action);// o(n) סריקה של תת העץ השמאלי
        action(root.GetValue());// o(1) ביצוע הפעולה על הצומת הנוכחית
        scan2(root.GetRight(), action);// o(n) סריקה של תת העץ הימני
    }
    public static void scan3<t>(BinNode<t> root, Action<t> action)// o(n) סריקה לפי סדר
    {
        if (root == null) return;// o(1) בדיקה אם הצומת ריקה
        scan3(root.GetLeft(), action);// o(n) סריקה של תת העץ השמאלי
        scan3(root.GetRight(), action);// o(n) סריקה של תת העץ הימני
        action(root.GetValue());// o(1) ביצוע הפעולה על הצומת הנוכחית
    }


    

    
    public static int lengthBT<t>(BinNode<t> root)// O(n) אורך עץ בינארי
    {
        if (root == null)// O(1)
            return 0;// O(1)
        return 1 + lengthBT(root.GetLeft()) + lengthBT(root.GetRight());// O(n)
    }

   
    public static int sumBT(BinNode<int> root)// O(n) סכום ערכי עץ בינארי
    {
        if (root == null)// O(1)
            return 0;// O(1)
        return root.GetValue() + sumBT(root.GetLeft()) + sumBT(root.GetRight());// O(n)
    }
    
   
   
    public static bool isExistBT<t>(BinNode<t> root, t value)// o(n) חיפוש ערך בעץ בינארי
    {
        if (root == null)// o(1) אם הצומת ריקה
            return false;// o(1) מחזיר שקר
        if (root.GetValue().Equals(value))// o(1) אם הערך שווה לערך המבוקש
            return true;// o(1) מחזיר אמת
        return isExistBT(root.GetLeft(), value) || isExistBT(root.GetRight(), value);// o(n) מחפש בתת העץ השמאלי או הימני
    }
   
    
    public static bool isEqualBTs<t>(BinNode<t> root1, BinNode<t> root2)// o(n) השוואת שני עצים בינאריים
    {
        if (root1 == null && root2 == null)// o(1) אם שתיהן ריקות
            return true;// o(1) מחזיר אמת
        if (root1 == null || root2 == null)// o(1) אם אחת ריקה והשנייה לא
            return false;// o(1) מחזיר שקר
        if (!root1.GetValue().Equals(root2.GetValue()))// o(1) אם הערכים לא שווים
            return false;// o(1) מחזיר שקר
        return isEqualBTs(root1.GetLeft(), root2.GetLeft()) && isEqualBTs(root1.GetRight(), root2.GetRight());// o(n) משווה את תתי העצים השמאליים והימניים
    }
    
    public static int Height<t>(BinNode<t> root)// סופר כמה רמות יש בעץ o(n)
    {
        if (root == null) return -1;// אם ריק מחזיר -1
        return 1 + Math.Max(Height(root.GetLeft()), Height(root.GetRight()));// ממשיך לספור
    }
    public static int CountLeaves<t>(BinNode<t> root)// סופר כמה עלים יש בעץ
    {
        if (root == null) return 0;// מחזיר 0 אם העץ ריק
        if (root.GetLeft() == null && root.GetRight() == null) return 1;// מחזיר 1 אם הצומת היא עלה
        return CountLeaves(root.GetLeft()) + CountLeaves(root.GetRight());// ממשיך לספור בעלים בתתי העצים
    }
}

public class Program
{
    
}