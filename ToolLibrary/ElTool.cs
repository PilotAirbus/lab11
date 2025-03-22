namespace ToolLibrary
{
    public class ElTool: Tool
    {
        private string supply;
        private int supplyTime;
        
        //Свойства
        public string Supply
        {
            get 
            {
                return supply; 
            }

            set 
            {
                supply = value;
            }
        }

        public int SupplyTime 
        {
            get 
            { 
                return  supplyTime; 
            }

            set 
            {
                if (value < 0) 
                {
                    throw new ArgumentException("Время работы аккумулятора не может быть меньше 0");
                }

                else 
                {
                    supplyTime = value;
                }
            }
        }

        //Конструкторы

        public ElTool() : base() 
        {
            Supply = "аккумулятор";
            SupplyTime = 60;
        }

        public ElTool(string name, string supply, int supplyTime, int number) : base(name, number) 
        {
            Supply = supply;
            SupplyTime = supplyTime;
        }

        public ElTool(ElTool tool) : base(tool)
        {
            Supply = tool.Supply;
            SupplyTime = tool.SupplyTime;
        }

        //Методы

        public new string Show() 
        {
            return $"Название инструмента - {Name}, тип питания - {Supply}, время работы аккумулятора - {SupplyTime}";
        }

        public override string VirtualShow()
        {
            return $"{base.VirtualShow()}, тип питания - {Supply}, время работы аккумулятора - {SupplyTime}";
        }

        //IInit и IRandomInit
        public override void IInit()
        {

            base.IInit();

            Supply = showData.GetString("Введите тип питания инструмента: ");
            SupplyTime = showData.GetTime();

        }

        public override void IRandomInit()
        {
            base.IRandomInit();

            string[] supplies = { "аккумулятор", "розетка", "не требует питания" };
            int[] times = { 0, 30, 60, 90, 120 };

            Supply = supplies[rand.Next(supplies.Length)];
            SupplyTime = times[rand.Next(times.Length)];

        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            ElTool tool = obj as ElTool;
            if (tool == null) return false;
            return (Name == tool.Name && Supply == tool.Supply && SupplyTime == tool.SupplyTime);
        }

        //Клонирование

        public override object Clone()
        {
            return new ElTool(this.Name, this.Supply, this.SupplyTime, this.ID.Number);
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
