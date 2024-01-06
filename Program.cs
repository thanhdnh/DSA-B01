public class Program
{
    public static void Swap<T>(ref T a, ref T b){
        T temp = a;
        a = b;
        b = temp;
    }
    public static void Swap(ref object a, ref object b){
        object temp = a;
        a = b;
        b = temp;
    }
    public static T Add<T>(T a, T b){
        if(a is Array && b is Array){
            Array ar = (dynamic)a;
            Array br = (dynamic)b;
            Array sum = Array.CreateInstance(
                            typeof(object), 
                            ar.Length+br.Length
                        );
            for(int i=0; i<ar.Length; i++)
                sum.SetValue(ar.GetValue(i), i);
            for(int i=0; i<br.Length; i++)
                sum.SetValue(br.GetValue(i), ar.Length+i);
            return (dynamic)sum;
        }else
            return (dynamic)a + (dynamic)b;
    }
    public static void Main(string[] args)
    {
        object[] ar = {1, 2}, br = {3, 4, 5};
        Array cr = Add<object[]>(ar, br);
        for(int i=0; i<cr.Length; i++)
            Console.Write(cr.GetValue(i)+", ");

        int x = 2, y = 3;
        string s1 = "di", s2 = "hoc";
        Console.WriteLine("\n"+Add<int>(x, y));
        Console.WriteLine(Add<string>(s1, s2));

        /*int x = 2, y = 3;
        Console.WriteLine($"x={x}, y={y}");
        Swap(ref x, ref y);
        Console.WriteLine($"x={x}, y={y}");*/

        /*int x = 2, y = 3;
        Console.WriteLine($"x={x}, y={y}");
        Swap<int>(ref x, ref y);
        Console.WriteLine($"x={x}, y={y}");*/

        /*string xx = "di", yy = "hoc";
        Console.WriteLine($"x={xx}, y={yy}");
        Swap<string>(ref xx, ref yy);
        Console.WriteLine($"x={xx}, y={yy}");*/
        Console.ReadLine();
    }
}