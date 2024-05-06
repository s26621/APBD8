using LinqTasks.Models;

namespace LinqTasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("======= ZAD X =======");

        IEnumerable<Emp> result = Tasks.Task1();

        foreach (Emp emp in result)
        {
            Console.WriteLine(emp);
        }
    }
}