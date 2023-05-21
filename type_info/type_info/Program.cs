using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace type_info
{
    class Program
    {
        // Изменение цвета шрифта
        public static void ChangeForegroundColor()
    {
        Console.Clear();
        Console.WriteLine("Выберете цвет:");
        Console.WriteLine("1 - Красный");
        Console.WriteLine("2 - Оранжевый");
        Console.WriteLine("3 - Жёлтый");
        Console.WriteLine("4 - Зелёный");
        Console.WriteLine("5 - Голубой");
        Console.WriteLine("6 - Синий");
        Console.WriteLine("7 - Фиолетовый");
        Console.WriteLine("8 - Белый");
        Console.WriteLine("9 - Черный");
        Console.WriteLine("0 - Выход в главное меню");
        Console.WriteLine("");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Clear();
                    break;
                case '2':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    break;
                case '3':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    break;
                case '4':
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    break;
                case '5':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    break;
                case '6':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    break;
                case '7':
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Clear();
                    break;
                case '8':
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    break;
                case '9':
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    break;
                case '0':
                    Main();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод: ");
                    break;
            }
            if (Console.BackgroundColor == Console.ForegroundColor)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Были выбраны одинаковые цвета, настройки установлены по-умолчанию");
                Console.WriteLine("Нажмите любую кнопку для выхода в главное меню");
                Console.ReadKey(true);
            }
            Main();
        }
    }

    //Изменение цвета фона
    public static void ChangeBackgroundColor()
    {
        Console.Clear();
        Console.WriteLine("Выберете цвет:");
        Console.WriteLine("1 - Красный");
        Console.WriteLine("2 - Оранжевый");
        Console.WriteLine("3 - Жёлтый");
        Console.WriteLine("4 - Зелёный");
        Console.WriteLine("5 - Голубой");
        Console.WriteLine("6 - Синий");
        Console.WriteLine("7 - Фиолетовый");
        Console.WriteLine("8 - Белый");
        Console.WriteLine("9 - Черный");
        Console.WriteLine("0 - Выход в главное меню");
        Console.WriteLine("");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    break;
                case '2':
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.Clear();
                    break;
                case '3':
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    break;
                case '4':
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    break;
                case '5':
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.Clear();
                    break;
                case '6':
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    break;
                case '7':
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.Clear();
                    break;
                case '8':
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Clear();
                    break;
                case '9':
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    break;
                case '0':
                    Main();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод: ");
                    break;
            }
            if (Console.BackgroundColor == Console.ForegroundColor)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.WriteLine("Были выбраны одинаковые цвета, настройки установлены по-умолчанию");
                Console.WriteLine("Нажмите любую кнопку для выхода в главное меню");
                Console.ReadKey(true);
            }
            Main();
        }
    }

    // Показать информацию по всем типам
    public static void ShowAllTypeInfo()
    {
        int nRefTypes = 0; // Количество классов
        int nValueTypes = 0; // Количество значимых типов
        int NotReturn = 0; // Количество метод, которые не возвращают значение
        int MaxConstr = -1; // Тип с наибольшим числом конструкторов (количество конструкторов)
        string sMaxConstr = ""; // Тип с наибольшим числом конструкторов
        int countShortMet = 0; // Доп: количество методов с коротким названием

        Assembly myAsm = Assembly.GetExecutingAssembly(); // Моя сборка
        Type[] thisAssemblyTypes = myAsm.GetTypes(); // Типы сборки
        Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies(); // Сборки
        List<Type> types = new List<Type>(); // Список типов всех сборок
        List<string> nameMethods = new List<string>(); // Список методов с коротким названием
        List<string> nameShortMethods = new List<string>(); // Доп: первые методы с коротким названием

        foreach (Assembly asm in refAssemblies)
            types.AddRange(asm.GetTypes());

        foreach (var t in types)
        {
            if (t.IsClass)
                nRefTypes++;
            else if (t.IsValueType)
                nValueTypes++;

            foreach (var met in t.GetMethods())
            {
                if (met.GetParameters().IsReadOnly)
                    NotReturn++;
                if (met.GetParameters().Length == 0)
                    NotReturn++;

                if (met.GetParameters().IsReadOnly && (met.Name.Length >= 5 && met.Name.Length <= 10))
                    countShortMet++;
                if (met.GetParameters().Length == 0 && (met.Name.Length >= 5 && met.Name.Length <= 10))
                    countShortMet++;

                if (!nameMethods.Contains(met.Name) && (met.Name.Length >= 5 && met.Name.Length <= 10))
                    nameMethods.Add(met.Name); //Доп: создаём список методов с коротким названием
            }

            if (t.GetConstructors().Length > MaxConstr)
            {
                MaxConstr = t.GetConstructors().Length; // Доп: количество конструкторов, для типа с наибольшим числом конструкторов
                sMaxConstr = t.FullName;
            }
        }


        // Доп: Сортируем список методов и добавляем в другой список первые 20 методов
        nameMethods.Sort();
        for (int i = 0; i < 20; i++)
            nameShortMethods.Add(nameMethods[i]);

        Console.Clear();
        Console.WriteLine("Общая информация по типам");
        Console.WriteLine("Подключенные сборки: " + thisAssemblyTypes.Length);
        Console.WriteLine("Всего типов по всем подключенным сборкам: " + types.Count);
        Console.WriteLine("Ссылочные типы (только классы): " + nRefTypes);
        Console.WriteLine("Значимые типы: " + nValueTypes);
        Console.WriteLine("Количество методов, не возвращающих значение: " + NotReturn);
        Console.WriteLine("Тип с наибольшим числом конструкторов: " + sMaxConstr);
        Console.WriteLine("     Количество конструкторов: " + MaxConstr); // Доп задание: количество конструкторов
        Console.WriteLine("Количество методов длины от 5 до 10: " + countShortMet); // Доп задание: находим количество методов длина названия которых от 5 до 10
        Console.WriteLine("     20 первых методов:"); // Доп: выводим методы с коротким названием
        Console.WriteLine("     " + String.Join(", ", nameShortMethods));

        Console.WriteLine("");
        Console.WriteLine("Нажмите любую кнопку для выхода в главное меню");
        Console.ReadKey(true);
        Main();
    }

    // Выбор типа
    public static Type SelectType()
    {
        Console.Clear();
        Console.WriteLine("Выберите тип:");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1 - uint");
        Console.WriteLine("2 - int");
        Console.WriteLine("3 - long");
        Console.WriteLine("4 - float");
        Console.WriteLine("5 - double");
        Console.WriteLine("6 - char");
        Console.WriteLine("7 - string");
        Console.WriteLine("8 - Vector");
        Console.WriteLine("9 - Matrix");
        Console.WriteLine("0 - Выход в главное меню");
        Console.WriteLine("");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    WriteInfoType((typeof(uint)));
                    break;
                case '2':
                    WriteInfoType((typeof(int)));
                    break;
                case '3':
                    WriteInfoType((typeof(long)));
                    break;
                case '4':
                    WriteInfoType((typeof(float)));
                    break;
                case '5':
                    WriteInfoType((typeof(double)));
                    break;
                case '6':
                    WriteInfoType((typeof(char)));
                    break;
                case '7':
                    WriteInfoType((typeof(string)));
                    break;
                case '8':
                    WriteInfoType((typeof(Vector)));
                    break;
                case '9':
                    WriteInfoType((typeof(Matrix4x4)));
                    break;
                case '0':
                    Main();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод: ");
                    break;
            }
        }
    }

    // Вывод дополнительной информации о выбранном типе
    public static void WriteAddInfo(Type t)
    {
        var overloads = new Dictionary<string, int>(); // Словарь для числа перегрузок
        List<string> metodsName = new List<string>(); // Имена методов
        var parameters = new Dictionary<string, string>(); // Словарь для параметров
        string outputs; // Представление вывода информации о параметрахв требуемом виде
        double sum = 0; // Доп: сумма параметров
        double count = 0; // Доп: количество параметров
        double avg; // Доп: среднее арифметическое

        foreach (var m in t.GetMethods())
        {
            if (overloads.ContainsKey(m.Name))
                overloads[m.Name]++;
            else
                overloads.Add(m.Name, 1);
        }

        foreach (var keys in overloads.Keys)
            metodsName.Add(keys);

        foreach (var met in t.GetMethods())
        {
            int countNotOptionalParameters = 0;
            int countOptionalParameters = 0;
            int countNotOptionalParameters1 = 0;
            int countOptionalParameters1 = 0;
            if (parameters.ContainsKey(met.Name))
            {
                foreach (var par in met.GetParameters())
                {
                    if (!par.IsOptional)
                        countNotOptionalParameters1++;
                    else
                        countOptionalParameters1++;

                    if (countOptionalParameters1 > countOptionalParameters && (countOptionalParameters1 + countNotOptionalParameters1) <= (countOptionalParameters + countNotOptionalParameters))
                        parameters[met.Name] = Convert.ToString(countOptionalParameters1) + ".." + Convert.ToString(countOptionalParameters + countNotOptionalParameters);

                    if (countOptionalParameters1 > countOptionalParameters && (countOptionalParameters1 + countNotOptionalParameters1) > (countOptionalParameters + countNotOptionalParameters))
                        parameters[met.Name] = Convert.ToString(countOptionalParameters1) + ".." + Convert.ToString(countOptionalParameters1 + countNotOptionalParameters1);

                    if (countOptionalParameters1 <= countOptionalParameters && (countOptionalParameters1 + countNotOptionalParameters1) > (countOptionalParameters + countNotOptionalParameters))
                        parameters[met.Name] = Convert.ToString(countOptionalParameters) + ".." + Convert.ToString(countOptionalParameters1 + countNotOptionalParameters1);
                }
            }
            else
            {
                foreach (var par in met.GetParameters())
                {
                    if (!par.IsOptional)
                        countNotOptionalParameters++;
                    else
                        countOptionalParameters++;
                }
                if (countOptionalParameters == countOptionalParameters + countNotOptionalParameters)
                    outputs = Convert.ToString(countOptionalParameters);
                else
                    outputs = Convert.ToString(countOptionalParameters) + ".." + Convert.ToString(countOptionalParameters + countNotOptionalParameters);

                parameters.Add(met.Name, outputs);
            }
        }

        //Доп: находим сумму и число параметров
        foreach (var met in t.GetMethods())
        {
            count++;
            if (parameters[met.Name].Length > 1)
                sum += Convert.ToInt32(parameters[met.Name].Substring(3));
            else
                sum += Convert.ToInt32(parameters[met.Name]);
        }

        Console.Clear();
        Console.WriteLine("Методы типа " + t.FullName);
        Console.WriteLine("Название                    Число перегрузок                    Число параметров");
        for (int i = 0; i < metodsName.Count; i++)
        {
            Console.Write(metodsName[i]);
            Console.SetCursorPosition(28, i + 2);
            Console.Write(overloads[metodsName[i]]);
            Console.SetCursorPosition(64, i + 2);
            Console.WriteLine(parameters[metodsName[i]]);
        }

        // Доп: когда тип вектор добавляем возможность показать среднее число параметров
        if (t == typeof(Vector))
        {
            Console.WriteLine("1 - вывод среднего числа параметров методов");
            Console.WriteLine("0 - выход в данное меню");

            while (true)
            {
                switch (char.ToLower(Console.ReadKey(true).KeyChar))
                {
                    case '1':
                        avg = sum / count; // Доп: среднее число параметров
                        Console.WriteLine("Среднее количество параметров:");
                        Console.WriteLine(Math.Round(avg, 2));
                        Console.WriteLine("Нажите любую кнопку чтобы продолжить");
                        Console.ReadKey(true);
                        Main();
                        break;
                    case '0':
                        Main();
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        Console.WriteLine("Повторите ввод: ");
                        break;
                }
            }
        }
    }

    // Вывод информации о выбранном типе
    public static void WriteInfoType(Type t)
    {
        string[] fieldNames = new string[t.GetFields().Length]; // Список имён полей
        for (int i = 0; i < t.GetFields().Length; i++)
            fieldNames[i] = t.GetFields()[i].Name;

        string sFieldNames = String.Join(", ", fieldNames);

        string[] propertiesNames = new string[t.GetProperties().Length]; // Список имён свойств
        for (int i = 0; i < t.GetProperties().Length; i++)
            propertiesNames[i] = t.GetProperties()[i].Name;

        string sPropertiesNames = String.Join(", ", propertiesNames);

        Console.Clear();
        Console.WriteLine("Информация по типу: " + t.FullName);

        if (t.IsValueType)
            Console.WriteLine("     Значимый тип: +");
        else
            Console.WriteLine("     Значимый тип: -");

        Console.WriteLine("     Пространство имён: " + t.Namespace);
        Console.WriteLine("     Сборка: " + t.Assembly.GetName().Name);
        Console.WriteLine("     Общее число элементов: " + t.GetMembers().Length);
        Console.WriteLine("     Общее число методов: " + t.GetMethods().Length);
        Console.WriteLine("     Общее число свойств: " + t.GetProperties().Length);
        Console.WriteLine("     Общее число полей: " + t.GetFields().Length);
        if (t.GetFields().Length > 0)
            Console.WriteLine("     Список полей: " + sFieldNames);
        else
            Console.WriteLine("     Список полей: -");

        if (t.GetProperties().Length > 0)
            Console.WriteLine("     Список свойств: " + sPropertiesNames);
        else
            Console.WriteLine("     Список свойств: - ");

        Console.WriteLine("");
        Console.WriteLine("Нажмите 'M' для вывода дополнительной инфорамации по методам");
        Console.WriteLine("Нажмите '0' для выхода в главное меню");
        Console.WriteLine("");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case 'm':
                    WriteAddInfo(t);
                    break;
                case '0':
                    Main();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод: ");
                    break;
            }
        }
    }

    // Выбор настроек консоли
    public static void ChangeConsoleView()
    {
        Console.Clear();
        Console.WriteLine("1 - Изменить цвет шрифта");
        Console.WriteLine("2 - Изменить цвет фона");
        Console.WriteLine("0 - Выход в главное меню");
        Console.WriteLine("");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    ChangeForegroundColor();
                    break;
                case '2':
                    ChangeBackgroundColor();
                    break;
                case '0':
                    Main();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод: ");
                    break;
            }
        }
    }

    // Выход из программы
    public static void Exit()
    {
        Environment.Exit(0);
    }

    // Основная часть
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Информация по типам:");
        Console.WriteLine("1 - Общая информация по типам");
        Console.WriteLine("2 - Выбрать тип из списка");
        Console.WriteLine("3 - Параметры консоли");
        Console.WriteLine("0 - Выход из программы");

        while (true)
        {
            switch (char.ToLower(Console.ReadKey(true).KeyChar))
            {
                case '1':
                    ShowAllTypeInfo();
                    break;
                case '2':
                    WriteInfoType(SelectType());
                    break;
                case '3':
                    ChangeConsoleView();
                    break;
                case '0':
                    Exit();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Неправильный ввод");
                    Console.WriteLine("Повторите ввод:");
                    break;
            }
        }
    }
}
}
