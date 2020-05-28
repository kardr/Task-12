using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Task_12
{
    class Regular
    {
        public Regular(string pattern, string txt)
        {
            r = new Regex(pattern);
            text = txt;
        }
        private Regex r;
        private string text;

        public bool Match_patter()
        {
            MatchCollection m = r.Matches(text);
            foreach (Match x in m)
            {
                Console.WriteLine("Есть\n");
                return true;
            }
            Console.WriteLine("Нет\n");
            return false;
        }

        public void Output_on_display()
        {
            Console.Write(text);
        }

        public string Delete()
        {
            MatchCollection m = r.Matches(text);
            string s = text;
            foreach (Match x in m)
            {
                int i = s.IndexOf(x.Value);
                int l = x.Value.Length;
                s = s.Remove(i, l);
            }
            return s;
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        public Regex R
        {
            get { return r; }
            set { r = value; }
        }

        public string this[int k]
        {
            get
            {
                if (k == 0)
                {
                    return R.ToString();
                }
                else if (k == 1)
                {
                    return text;
                }
                else
                    return "Некоректный индекс";
            }
        }
        public static Regular operator -(Regular re)
        {
             MatchCollection m = re.R.Matches(re.Text);
            string s = "";
            foreach (Match x in m)
                s+=x.Value;
            re.Text = s;
            return re;

        }
        public static bool operator false(Regular re)
        {
            return re.text.Length == 0;

        }
        public static bool operator true(Regular re)
        {
            return re.text.Length != 0;

        }
        public static Regular operator +(Regular re, string s)
        {
            re.text = re.text + s;
            return re;
        }
        public override string ToString()
        {
            return "Регулярное выражение: "+ R +" текст: "+ text;
        }
        public static Regular StringToRegular(string s)
        {
            try
            {
                int a, b;
                a = s.IndexOf("[");
                b = s.IndexOf("]");
                if (a == -1 || b == -1)
                {
                    throw new Exception("Ошибка преобразования");
                }

                string s1 = s.Substring(a+1, b - a-1);
                string s2 = s.Remove(a, b - a+1);

                Regular c = new Regular(s1, s2);
                return c;
            }
            catch (Exception E)
            {
                 Console.WriteLine(E.Message);
                return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Regular myReg = new Regular("[^.В!]", "Добрый день. Как Ваше настроение? Всего доброго!");
            myReg.Output_on_display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ОБРАЩЕНИЕ К ЭКЗЕМПЛЯРУ КЛАССА:");
            if (myReg)
            {
                Console.WriteLine("Строка не пуста");
            }
            else
            {
                Console.WriteLine("Строка пуста");
            }
            Console.WriteLine();
            Console.WriteLine("ПРЕОБРАЗОВАНИЕ КЛАССА Regex В ТИП string: ");
            Regular myReg2=Regular.StringToRegular("[67]играю на аккордеоне");
            Console.WriteLine(myReg2.ToString());
            Console.WriteLine();
            Console.WriteLine("ПРЕОБРАЗОВАНИЕ ТИПА string В КЛАСС Regex:");
            Regular myReg3 = Regular.StringToRegular("падение вниз");
            Console.WriteLine();
            Console.WriteLine("ИНДЕКСАТОР, ПОЗВОЛЯЮЩИЙ ПО ИНДЕКСУ 0 ОБРАЩАТЬСЯ К ПОЛЮ r:");
            Console.WriteLine(myReg[0]);
            Console.WriteLine();
            Console.WriteLine("ИНДЕКСАТОР, ПОЗВОЛЯЮЩИЙ ПО ИНДЕКСУ 1 – К ПОЛЮ text:");
            Console.WriteLine(myReg[1]);
            Console.WriteLine();
            Console.WriteLine("ДРУГОЕ ЗНАЧЕНИЕ ИНДЕКСА:");
            Console.WriteLine(myReg[6]);
            Console.WriteLine();
            Console.WriteLine("ОПЕРАЦИЯ БИНАРНОГО +:"); 
            myReg = myReg + "12345";
            myReg.Output_on_display();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("ОПЕРАЦИЯ УНАРНОГО -: ");
            myReg =- myReg;
            myReg.Output_on_display();
            Console.ReadKey();
        }
    }
}
