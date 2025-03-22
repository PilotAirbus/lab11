namespace ToolLibrary
{
    public class HandTool: Tool
    {
        string material;

        //Свойства
        public string Material 
        {
            get
            {
                return material; 
            }

            set 
            {
                material = value; 
            }
        }

        //Конструкторы
        public HandTool() : base() 
        {
            Material = "железо";
        }

        public HandTool(string name, string material, int number) : base(name, number) 
        {
            Material = material;
        }

        public HandTool(HandTool tool) :base(tool)
        {
            Material= tool.Material;
        }

        //Методы
        public new string Show()
        {
            return $"Название инструмента - {Name}, материал инструмента - {Material}";
        }

        public override string VirtualShow()
        {
            return $"{base.VirtualShow()}, материал инструмента - {Material}";
        }

        //IInit и IRandomInit

        public override void IInit()
        {
            base.IInit();
            Material = showData.GetString("Введите материал инструмента: ");
        }

        public override void IRandomInit()
        {
            base.IRandomInit();

            string[] materials = { "камень", "дерево", "железо", "резина", "пластик" };

            Material = materials[rand.Next(materials.Length)];
        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            HandTool tool = obj as HandTool;
            if (tool == null) return false;
            return (Name == tool.Name && Material == tool.Material);
        }

        //Клонирование

        public override object Clone()
        {
            return new HandTool(this.Name, this.Material, this.ID.Number);
        }

        public override object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}

