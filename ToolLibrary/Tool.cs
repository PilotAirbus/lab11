namespace ToolLibrary
{
    public class Tool: IInit, IComparable<Tool>, ICloneable, IComparable
    {
        protected string name;
        protected int nameLength;
        public IdNumber ID { get; set; }

        public ShowData showData = new ShowData();
        protected Random rand = new Random();

        //Свойства
        public string Name 
        {
            get 
            { 
                return name; 
            }

            set 
            { 
                name = value; 
            }
        }

        public int NameLength { get { return name.Length; } }

        //Конструкторы
        public Tool() 
        {
            Name = "перфоратор";
            ID = new IdNumber(0);
        }

        public Tool(string name, int number)
        {
            Name = name;
            ID = new IdNumber(number);
        }

        public Tool(Tool tool) 
        {
            Name = tool.Name;
            ID = tool.ID;
        }

        public string Show() 
        {
            return $"Название инструмента - {Name}, ID объекта: {ID.Number}";
        }

        public virtual string VirtualShow()
        {
            return $"Название инструмента - {Name}";
        }

        //IInit и IRandomInit
        public virtual void IInit()
        {
            Name = showData.GetString("Введите название инструмента: ");
        }

        public virtual void IRandomInit()
        {
            string[] tools = { "дрель", "отбойный молоток", "бензопила", "газонокосилка", "шуруповерт" };

            Name = tools[rand.Next(tools.Length)];
        }

        //Сравнение объектов
        public virtual bool Equals(object obj)
        {
            Tool tool = obj as Tool;
            if (tool == null) return false;
            return (Name == tool.Name && ID.Number == tool.ID.Number);
        }

        public int CompareTo(Tool? other)
        {
            if (other == null) return -1;
            return Name.CompareTo(other.Name);
        }

        public virtual object Clone()
        {
            return new Tool(this.Name, this.ID.Number);
        }

        public virtual object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object? obj)
        {
            
            if (obj == null)
                return -1; 

            
            if (obj is Tool otherTool)
            {
                return this.CompareTo(otherTool);
            }
            throw new ArgumentException("Объект должен быть типа Tool");
        }
    }
}
