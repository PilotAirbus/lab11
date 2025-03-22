using ToolLibrary;
using System.Collections;

namespace Lab_11
{
    internal class Program
    {
        #region Задание 1
        static void PrintList(SortedList list, ShowData data, string str = "Содержимое списка:")
        {
            int i = 1;

            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
            data.SkipString();

            // Итерация по элементам SortedList
            foreach (DictionaryEntry entry in list)
            {
                Tool key = (Tool)entry.Key;          // Ключ (тип Tool)
                ElTool value = (ElTool)entry.Value; // Значение (тип ElTool)

                // Вывод информации об элементе
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Объект {i++}: ");
                Console.ResetColor();

                Console.WriteLine($"Ключ: {key.Name}, Значение: {value.Show()}");
            }

            // Разделитель
            data.PrintLine();
        }

        #region Создание, добавление и удаление

        //Создание списка
        static SortedList ListCreate(ShowData data)
        {

            #region Изначальное заполнение списка

            data.PrintHat("Изначальное заполнение списка:");

            SortedList list = new SortedList();

            for (int i = 0; i < 10; i++) 
            {
                try
                {
                    ElTool elTool = new ElTool();
                    elTool.IRandomInit();
                    elTool.Name = elTool.Name + i.ToString();

                    Tool tool = new Tool(elTool.Name, elTool.ID.Number);

                    list.Add(tool, elTool);
                    data.PrintElement(tool, elTool, "Добавление");
                    data.SkipString();
                }
                catch (Exception ex)
                {
                    i--;
                }
            }

            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        //Добавление элементов в список
        static SortedList AddElements(SortedList list, ShowData data)
        {

            #region Добавление элементов

            data.PrintHat("Добавление элементов: ");

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ElTool elTool = new ElTool();
                    elTool.IRandomInit();
                    elTool.Name = elTool.Name + i.ToString();

                    Tool tool = new Tool(elTool.Name, elTool.ID.Number);

                    list.Add(tool, elTool);
                    data.PrintElement(tool, elTool, "Добавление");
                    data.SkipString();
                }
                catch (Exception ex)
                {
                    i--;
                    Console.WriteLine(ex);
                }
            }

            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        static SortedList DelElements(SortedList list, ShowData data)
        {
            #region Удаление элементов

            data.PrintHat("Удаление элементов: ");

            // Создаем копию ключей, чтобы избежать изменения коллекции во время итерации
            ICollection keys = list.Keys;
            Tool[] keysCopy = new Tool[keys.Count];
            keys.CopyTo(keysCopy, 0);
            int i = 0;

            foreach (Tool key in keysCopy)
            {
                // Выводим информацию об удаляемом элементе
                data.PrintElement(key, (ElTool)list[key], "Удаление");

                data.SkipString();
                // Удаляем элемент из коллекции
                list.Remove(key);

                if (++i == 5) { break; }
            }

            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        static SortedList ListShow(ShowData data)
        {
            SortedList list = ListCreate(data);
            list = AddElements(list, data);
            list = DelElements(list, data);
            return list;
        }

        #endregion

        #region Запросы

        static void NameAsk(SortedList list)
        {
            int count = 0;

            foreach (Tool item in list.Keys)
            {
                if (item.Name == "дрель") { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 1: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество найденных дрелей равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void SocketAsk(SortedList list)
        {
            int count = 0;

            foreach (ElTool item in list.Values)
            {
                if (item.Supply == "розетка") { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 2: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество инструментов, работающих от розетки, равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void AllAsk(SortedList list)
        {
            int count = 0;

            foreach (ElTool item in list.Values)
            {
                if (item.Name == "дрель" && item.Supply == "розетка") { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 3: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество дрелей, работающих от розетки, равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void Asks(SortedList list, ShowData data)
        {
            NameAsk(list);
            SocketAsk(list);
            AllAsk(list);
            data.PrintLine();
        }
        
        #endregion

        #region Перебор списка

        static void ListCheck(SortedList list, ShowData data)
        {
            int i = 1;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Просмотр списка: ");
            data.SkipString();

            foreach (Tool tool in list.Keys)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i++}: ");
                Console.ForegroundColor = ConsoleColor.White;
                data.PrintElement(tool, (ElTool)list[tool]);
                data.SkipString();
            }

            data.PrintLine();
        }

        #endregion

        #region Клонирование списка

        static SortedList ListClone(SortedList list)
        {
            SortedList clone = new SortedList();

            foreach (Tool tool in list.Keys) 
            {
                clone.Add(tool, (ElTool)list[tool]);
            }

            return clone;
        }

        #endregion

        static void ListSortAndSearch(SortedList list, ShowData data)
        {
            ElTool[] toolArray = new ElTool[list.Count];
            int i = 0;

            foreach (ElTool elTool in list.Values) 
            {
                toolArray[i++] = elTool;
            }

            Array.Sort(toolArray);

            ElTool tool = new ElTool();
            tool.IInit();

            int index = Array.BinarySearch(toolArray, tool);


            if (index >= 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Элемент ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{tool} ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("найден на позиции ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{++index} ");

                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Элемент ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{tool} ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("не найден");

                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        #endregion

        #region Задание 2

        static void PrintList(List<Tool> list, ShowData data, string str = "Полученный список:")
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            data.SkipString();

            for(int i = 0; i < list.Count; i++) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"Объект {i+1}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(list[i].Show());
            }
        }

        #region Создание, добавление и удаление

        //Создание списка
        static List<Tool> ListCreate()
        {
            ShowData data = new ShowData(); 

            #region Изначальное заполнение списка

            data.PrintHat("Изначальное заполнение коллекции:");

            List<Tool> list = new List<Tool> ();

            for (int i = 0; i < 10; i++) 
            {
                Tool item = new Tool();
                item.IRandomInit();

                list.Add(item);
            }
            PrintList(list, data);
            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        //Добавление элементов в очередь
        static List<Tool> AddElements(List<Tool> list)
        {
            ShowData data = new ShowData(); //создание объекта для работы с интерфейсом

            #region Добавление элементов

            data.PrintHat("Добавление элементов: ");

            for (int i = 0; i < 10; i++)
            {
                Tool item = new Tool();
                item.IRandomInit();

                data.PrintElement(item, "Добавление");
                list.Add(item);
            }

            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        //Удаление элементов из очереди
        static List<Tool> DelElements(List<Tool> list)
        {
            ShowData data = new ShowData(); // Создание объекта для работы с интерфейсом

            #region Удаление элементов

            data.PrintHat("Удаление элементов: ");
            

            for (int i = 0; i < 5; i ++)
            {
                list.Remove(list[i]); 
                data.PrintElement(list[i], "Удаление");
            }

            data.SkipString();
            data.PrintLength(list.Count);
            data.PrintLine();

            #endregion

            return list;
        }

        static List<Tool> QueueShow()
        {
            List<Tool> list = ListCreate();
            list = AddElements(list);
            list = DelElements(list);

            return list;
        }

        #endregion

        #region Запросы

        static void NameAsk(List<Tool> list)
        {
            int count = 0;

            foreach (Tool item in list)
            {
                if (item.Name == "дрель") { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 1: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество найденных дрелей равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void NameLengthAsk(List<Tool> list)
        {
            int count = 0;

            foreach (Tool item in list)
            {
                if (item.NameLength == 5) { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 2: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество инструментов с названием из 5 букв равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void AllAsk(List<Tool> list)
        {
            int count = 0;

            foreach (Tool item in list)
            {
                if (item.Name == "дрель" && item.NameLength == 5) { count++; }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Запрос 3: ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Количество дрелей .состоящих из 5 букв, равно ");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(count);

        }

        static void Asks(List<Tool> list, ShowData data)
        {
            NameAsk(list);
            NameLengthAsk(list);
            AllAsk(list);
            data.PrintLine();
        }

        #endregion

        #region Перебор списка

        static void ListCheck(List<Tool> list, ShowData data)
        {
            int i = 1;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Просмотр списка: ");
            data.SkipString();

            foreach (Tool item in list)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"Объект {i++}: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(item.Show());
            }

            data.PrintLine();
        }

        #endregion

        #region Клонирование списка

        static List<Tool> ListClone(List<Tool> list)
        {
            List<Tool> clone = new List<Tool>();

            for (int i = 0; i < list.Count; i++)
            {
                clone.Add(list[i]); 
            }

            return clone;
        }

        #endregion

        static void ListSortAndSearch(List<Tool> list, ShowData data)
        {
            Tool[] array = list.ToArray();
            Array.Sort(array);

            Tool tool = new Tool();
            tool.IInit();

            int index = Array.BinarySearch(array, tool);


            if (index >= 0)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Элемент ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{tool.Show()} ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("найден на позиции ");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{++index} ");

                Console.ForegroundColor = ConsoleColor.White;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Элемент ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{tool.Show()} ");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("не найден");

                Console.ForegroundColor = ConsoleColor.White;
            }
            data.PrintLine();
        }

        #endregion

        #region Задание 3

        static long[] FindElements(TestCollections testCollection, ShowData data, ref long[] times)
        {
            #region Поиск

            //поиск первого элемента
            times[0] = times[0] + testCollection.FindItemInQueue1(testCollection.first, "первый");
            times[4] = times[4] + testCollection.FindItemInQueue2(testCollection.first, "первый");
            times[8] = times[8] + testCollection.FindItemInSet1(testCollection.first, "первый");
            times[12] = times[12] + testCollection.FindItemInSet2(testCollection.first, "первый");

            data.PrintLine();
            data.SkipString();

            //поиск среднего элемента
            times[1] = times[1] + testCollection.FindItemInQueue1(testCollection.middle, "средний");
            times[5] = times[5] + testCollection.FindItemInQueue2(testCollection.middle, "средний");
            times[9] = times[9] + testCollection.FindItemInSet1(testCollection.middle, "средний");
            times[13] = times[13] + testCollection.FindItemInSet2(testCollection.middle, "средний");

            data.PrintLine();
            data.SkipString();

            //поиск последнего элемента
            times[2] = times[2] + testCollection.FindItemInQueue1(testCollection.last, "последний");
            times[6] = times[6] + testCollection.FindItemInQueue2(testCollection.last, "последний");
            times[10] = times[10] + testCollection.FindItemInSet1(testCollection.last, "последний");
            times[14] = times[14] + testCollection.FindItemInSet2(testCollection.last, "последний");

            data.PrintLine();
            data.SkipString();

            //поиск несуществующего элемента
            times[3] = times[3] + testCollection.FindItemInQueue1(testCollection.notExist, "несуществующий");
            times[7] = times[7] + testCollection.FindItemInQueue2(testCollection.notExist, "несуществующий");
            times[11] = times[11] + testCollection.FindItemInSet1(testCollection.notExist, "несуществующий");
            times[15] = times[15] + testCollection.FindItemInSet2(testCollection.notExist, "несуществующий");

            data.PrintLine();
            data.SkipString();

            #endregion

            return times;
        }

        static void ShowResults(ShowData data)
        {
            TestCollections testCollection = new TestCollections(20);
            testCollection.Print(data);
            Console.ReadLine();
            Console.Clear();

            long[] times = new long[16]; 
            Array.Fill(times, 0);

            for (int i = 0; i < 5; i++)
            {
                FindElements(testCollection, data, ref times);

                Console.ReadLine();
                Console.Clear();
            }

            for (int i = 0; i < times.Length; i++)
            {
                times[i] = times[i] / 5;
            }



            Console.Write("Значения тиков при поиске для 1 очереди: ");

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{times[i]} ");

            }

            data.SkipString();


            Console.Write("Значения тиков при поиске для 2 очереди: ");

            for (int i = 4; i < 8; i++)
            {
                Console.Write($"{times[i]} ");

            }

            data.SkipString();

            Console.Write("Значения тиков при поиске для 1 множества: ");

            for (int i = 8; i < 12; i++)
            {
                Console.Write($"{times[i]} ");

            }

            data.SkipString();

            Console.Write("Значения тиков при поиске для 2 множества: ");

            for (int i = 12; i < 16; i++)
            {
                Console.Write($"{times[i]} ");

            }

            data.SkipString();

        }

        #endregion

        static void Main(string[] args)
        {
            ShowData data = new ShowData();

            #region Задание 1

            SortedList list = ListCreate(data);
            Console.ReadLine();
            Console.Clear();

            list = AddElements(list, data);
            list = DelElements(list, data);
            Console.ReadLine();
            Console.Clear();

            Asks(list, data);
            Console.ReadLine();
            Console.Clear();

            ListCheck(list, data);
            Console.ReadLine();
            Console.Clear();

            SortedList clone = ListClone(list);
            PrintList(clone, data, "Клонированный список: ");

            ListSortAndSearch(list, data);

            #endregion

            Console.ReadLine();
            Console.Clear();

            #region Задание 2

            List<Tool> list2 = ListCreate();
            Console.ReadLine();
            Console.Clear();

            AddElements(list2);
            DelElements(list2);
            Console.ReadLine();
            Console.Clear();

            Asks(list2, data);
            Console.ReadLine();
            Console.Clear();

            ListCheck(list2, data);
            Console.ReadLine();
            Console.Clear();

            ListClone(list2);
            Console.ReadLine();
            Console.Clear();

            ListSortAndSearch(list2, data);
            Console.ReadLine();
            Console.Clear();

            #endregion

            Console.ReadLine();
            Console.Clear();

            ShowResults(data);
        }
    }
}
