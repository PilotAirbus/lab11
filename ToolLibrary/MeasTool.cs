namespace ToolLibrary
{
    public class MeasTool: Tool
    {
        string units;
        double accuracy;

        //Свойства
        public string Units 
        {
            get 
            { 
                return units; 
            }
            set 
            { 
                units = value;
            }
        }
        public double Accuracy
        {
            get => accuracy;
            set
            {
                if (value < 0)  throw new ArgumentException("Точность измерения не может быть меньше 0"); 

                accuracy = value;
            }
        }

        //Кострукторы

        public MeasTool()
        {
            Units = "мм";
            Accuracy = 0.01;
        }

        public MeasTool(string name, string units, double accuracy, int number) : base(name, number)
        {
            Units = units;
            Accuracy = accuracy;
        }

        public MeasTool(MeasTool tool) : base(tool)
        {
            Units = tool.Units;
            Accuracy = tool.Accuracy;
        }

        //Методы

        public new string Show()
        {
            return $"Название инструмента - {Name}, единицы измерения - {Units}, точность измерения - {Accuracy}";
        }

        public override string VirtualShow()
        {
            return $"{base.VirtualShow()}, единицы измерения - {Units}, точность измерения - {Accuracy}";
        }

        //IInit и IRandomInit
        public override void IInit()
        {
            double acc;
            string data;
            bool isConverted;

            base.IInit();

            Units = showData.GetString("Введите единицы измерения инструмента: ");

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Введите точность измерения инструмента: ");

                Console.ForegroundColor = ConsoleColor.White;
                data = Console.ReadLine();

                isConverted = double.TryParse(data, out acc);

                if (!isConverted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка ввода");
                    Console.WriteLine();
                }

                if ((isConverted) && (acc < 0))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Точность измерений должна быть не меньше 0");
                    Console.WriteLine();
                }

            } while ((!isConverted) || (acc < 0));

            Accuracy = acc;

        }

        public override void IRandomInit()
        {
            base.IRandomInit();

            string[] units = { "мм", "см", "кг", "фунт", "фут" };
            double[] accuracies = { 0, 0.1, 0.01, 0.001, 0.0001 };

            Units = units[rand.Next(units.Length)];
            Accuracy = accuracies[rand.Next(accuracies.Length)];

        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            MeasTool tool = obj as MeasTool;
            if (tool == null) return false;
            return (Name == tool.Name && Units == tool.Units && Accuracy == tool.Accuracy);
        }

        //Клонирование

        public override object Clone()
        {
            return new MeasTool(this.Name, this.Units, this.Accuracy, this.ID.Number);
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

    }
}
