namespace ToolLibrary
{
    public class ShowData
    {
        //Методы
        public void Print(string data) 
        {
            Console.WriteLine(data);
        }

        public string GetString(string message = "") 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(message);


            Console.ForegroundColor = ConsoleColor.White;
            string data = Console.ReadLine();
            return data;
        }

        public int GetTime(string message = "Введите время работы аккумулятора: ") 
        {
            int time;
            string data;
            bool isConverted;

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message);

                Console.ForegroundColor = ConsoleColor.White;
                data = Console.ReadLine();

                isConverted = int.TryParse(data, out time);

                if (!isConverted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода");
                    Console.WriteLine();
                }

                if ((isConverted) && (time < 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Время работы аккумулятора должно быть не меньше 0");
                    Console.WriteLine();
                }

            } while ((!isConverted) || (time < 0));

            return time;
        }

        public double GetAccuracy(string message = "Введите точность измерения инструмента: ") 
        {
            double accuracy;
            string data;
            bool isConverted;

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(message);

                Console.ForegroundColor = ConsoleColor.White;
                data = Console.ReadLine();

                isConverted = double.TryParse(data, out accuracy);

                if (!isConverted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода");
                    Console.WriteLine();
                }

                if ((isConverted) && (accuracy < 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Точность измерений должна быть не меньше 0");
                    Console.WriteLine();
                }

            } while ((!isConverted) || (accuracy < 0));

            return accuracy;
        }

        public void PrintLine()
        {
            Console.WriteLine("-------------------------------------");
        }
        public void PrintHat(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            this.SkipString();
        }

        public void SkipString() { Console.WriteLine(); }
        public void PrintLength(int Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Количество элементов в коллекции: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Count);
        }

        public void PrintElement(Tool tool, ElTool elTool, string str = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{str} элемента: ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ключ элемента: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tool.Show());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Значение элемента: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(elTool.Show());
        }

        public void PrintElement(Tool tool, string str = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{str} элемента: ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(tool.Show());
        }

        public void PrintElement(Tool tool, ElTool elTool)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Ключ: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{tool.ToString()}, ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Значение: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{elTool.ToString()}");


        }

        public void PrintElement(ElTool tool, int i)
        {
            Console.WriteLine($"Элемент {i}: {tool.Show()}");
        }
    }
}
