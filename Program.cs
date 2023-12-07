
using System;

namespace ProgramNameSpace
{

    public class MyException : Exception
    {
        public MyException(string MyMessage) : base(MyMessage) {}
    }

    class SortType
    {
        public delegate void MyDelegate(int sortType);
        public event MyDelegate? SortEvent;

        public void MySort()
        {
            Console.WriteLine("Как хотите сортировать?");
            Console.WriteLine("1 = от А до Я");
            Console.WriteLine("2 = от Я до А");
            string readChoice = Console.ReadLine();
            if (readChoice != "1" && readChoice != "2") throw new FormatException();
            SortEvent?.Invoke(Convert.ToInt32(readChoice));
        }
    }

    static class DisplayArray
    {
        public static void Display(int sortType)
        {
            List<string> listWords = MyList.CreateList();
            switch (sortType)
            {
                case 1:
                    {
                        listWords.Sort();
                        foreach (string lname in listWords)
                        {
                            Console.WriteLine(lname);
                        }
                    }
                    break;
                case 2:
                    {
                        listWords.Sort();
                        listWords.Reverse();
                        foreach (string lname in listWords)
                            Console.WriteLine(lname);
                    }
                    break;
                default:
                    {
                        break;
                    }
            }

        }
    }

    class MyList
    {
        public static List<string> CreateList()
        {
            List<string> listWords = new List<string>();
            Console.WriteLine("Введите 5 слов");
            for (int i = 0; i <= 4; i++)
            {
                listWords.Add(Console.ReadLine());
                if (listWords[i].IndexOf('Ы') == 0)
                {
                    throw new MyException("Не бывает слов на 'Ы'");
                }

            }
            Console.WriteLine();
            return listWords;
        }
    }

    class Programm
    {
        public static void Main(string[] args)
        {
            My5Exceptions.MakeExceptions();  // Для задания 1
            Console.WriteLine();


            SortType sortLnames = new SortType();
            sortLnames.SortEvent += DisplayArray.Display;
            try
            {
                sortLnames.MySort();
            }
            catch (MyException e) // моё
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

    }

    static class My5Exceptions
    {
        public static void MakeExceptions()
        {
            Exception[] eArray = new Exception[5];
            eArray[0] = new MyException("Моё исключение! Так нельзя!");
            eArray[1] = new FileNotFoundException("Файл не найден");
            eArray[2] = new IndexOutOfRangeException("IndexOutOfRangeException");
            eArray[3] = new DivideByZeroException("На ноль делить нельзя");
            eArray[4] = new ArgumentNullException("null нельзя");


            for (int i = 0; i < eArray.Length; i++)
            {
                try
                {
                    throw eArray[i];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}