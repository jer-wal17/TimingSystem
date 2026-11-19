using System.Reflection;
using TimingSystem.Library;
using TimingSystem.Library.Tables;

namespace TimingSystem.Runtime
{
    public class Program(ITimingProvider timingProvider)
    {
        readonly ITimingProvider timingProvider = timingProvider ?? throw new ArgumentNullException(nameof(timingProvider));

        static async Task Main(string[] args)
        {
            Queue<Time> ongoingTimes = new();

            ongoingTimes.Append(await timingProvider.Start(17));
        }

        public static void PrintProperties<T>(T obj)
        {
            if (obj is null)
            {
                return;
            }

            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(obj);
                Console.WriteLine($"{property.Name}: {value}");
            }
        }
    }
}
