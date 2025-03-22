namespace ToolLibrary
{
    public class IdNumber
    {
        public int number;

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (number >= 0)
                {
                    number = value;
                }

                else
                {
                    throw new Exception("ID не может быть меньше 0");
                }

            }
        }

        public IdNumber()
        {
            Number = 0;
        }

        public IdNumber(int number)
        {
            Number = number;
        }

        //Сравнение объектов
        public override bool Equals(object obj)
        {
            IdNumber number = obj as IdNumber;

            if (number == null)
            {
                return false;
            }
            return (Number == number.Number);
        }

        public override string ToString()
        {
            return $"ID объекта: {Number}";
        }
    }
}