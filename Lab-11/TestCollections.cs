using System.Diagnostics;
using ToolLibrary;

namespace Lab_11
{
    public class TestCollections
    {
        Queue<ElTool> queue1 = new Queue<ElTool>();
        Queue<string> queue2 = new Queue<string>();
        SortedSet<ElTool> set1 = new SortedSet<ElTool>();
        SortedSet<string> set2 = new SortedSet<string>();

        public ElTool first, middle, last, notExist;

        public TestCollections(int size)
        {
            for (int i = 0; i < size; i++)
            {
                try
                {
                    ElTool elTool = new ElTool();
                    elTool.IRandomInit();
                    elTool.Name = elTool.Name + i.ToString();

                    set1.Add(elTool);
                    set2.Add(elTool.ToString());

                    queue1.Enqueue(elTool);
                    queue2.Enqueue(elTool.ToString());

                    if (i == 0)
                    {
                        first = elTool;
                    }

                    if (i == size / 2)
                    {
                        middle = elTool;
                    }

                    if (i == size - 1)
                    {
                        last = elTool;
                    }
                }


                catch
                {
                    i--;
                }

                notExist = new ElTool("отвертка", "нет", 3, 52);
            }
        }

        public void Print(ShowData data)
        {
            int i = 0;

            foreach (ElTool item in queue1) 
            {
                data.PrintElement(item, ++i);
            }
        }

        public long FindItemInQueue1(ElTool item, string message)
        {
            Console.Write($"В коллекции Queue<ElTool> {message} элемент ");
            Stopwatch timer = Stopwatch.StartNew();


            timer.Restart();
            bool isFound = queue1.Contains(item);
            timer.Restart();
            queue1.Contains(item);
            timer.Stop();

            if (isFound)
            {
                Console.Write("найден ");
            }

            else
            {
                Console.Write("не найден ");
            }

            Console.WriteLine($"за {timer.ElapsedTicks} тиков");

            return timer.ElapsedTicks;
        }

        public long FindItemInQueue2(ElTool item, string message)
        {
            Stopwatch timer = Stopwatch.StartNew();
            string stringItem = item.ToString();

            Console.Write($"В коллекции Queue<string> {message} элемент ");

            timer.Restart();
            bool isFound = queue1.Contains(item);
            timer.Restart();
            queue1.Contains(item);
            timer.Stop();

            if (isFound)
            {
                Console.Write("найден ");
            }

            else
            {
                Console.Write("не найден ");
            }

            Console.WriteLine($"за {timer.ElapsedTicks} тиков");

            return timer.ElapsedTicks;
        }

        public long FindItemInSet1(ElTool item, string message)
        {
            Stopwatch timer = Stopwatch.StartNew();
            Console.Write($"В коллекции SortedSet<ElTool> {message} элемент ");

            timer.Restart();
            bool isFound = set1.Contains(item);
            timer.Restart();
            set1.Contains(item);
            timer.Stop();

            if (isFound)
            {
                Console.Write("найден ");
            }

            else
            {
                Console.Write("не найден ");
            }

            Console.WriteLine($"за {timer.ElapsedTicks} тиков");
            return timer.ElapsedTicks;
        }

        public long FindItemInSet2(ElTool item, string message)
        {
            string stringItem = item.ToString();
            Stopwatch timer = Stopwatch.StartNew();
            Console.Write($"В коллекции SortedDictionary<string, ElClocks> {message} элемент ");

            timer.Restart();
            bool isFound = set2.Contains(stringItem);
            timer.Restart();
            set2.Contains(stringItem);
            timer.Stop();

            if (isFound)
            {
                Console.Write("найден ");
            }

            else
            {
                Console.Write("не найден ");
            }

            Console.WriteLine($"за {timer.ElapsedTicks} тиков");
            return timer.ElapsedTicks;
        }

    }
}
