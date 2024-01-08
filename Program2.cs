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
    public static T Add<T, Q>(T a, T b){
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
            Q[] sumr = new Q[sum.Length];
            for(int i=0; i<sum.Length; i++)
                sumr[i] = (Q)sum.GetValue(i);
            return (dynamic)sumr;
        }else
            return (dynamic)a + (dynamic)b;
    }
    public static void Main(string[] args)
    {
        int x = 2, y = 3;
        string s1="di", s2="hoc";
        string[] ar = {"1", "2"}, br = {"3", "4", "5"};
        //Console.WriteLine($"{x}+{y}={Add<int, int>(x, y)}");
        //Console.WriteLine($"{s1}+{s2}={Add<string, string>(s1, s2)}");
        
        Timing timer = new Timing();
        timer.startTime();
        Array cr = Add<string[], string>(ar, br);
        timer.StopTime();
        Console.WriteLine("\nTime: " + timer.Result().Milliseconds);
        
        foreach(string v in cr)
            Console.Write(v + " ");
        /*object c = 2.3f;
        Console.WriteLine(c.GetType());*/
        /*int x = 2, y = 3;
        Console.WriteLine($"x={x}, y={y}");
        Swap(ref x, ref y);
        Console.WriteLine($"x={x}, y={y}");*/

        /*int x = 2, y = 3;
        Console.WriteLine($"x={x}, y={y}");
        Swap<int>(ref x, ref y);
        Console.WriteLine($"x={x}, y={y}");

        string xx = "di", yy = "hoc";
        Console.WriteLine($"x={xx}, y={yy}");
        Swap<string>(ref xx, ref yy);
        Console.WriteLine($"x={xx}, y={yy}");*/
        Console.ReadLine();
    }
}