using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Készíts programot, amely bekér öt számot 1 és 90 tartományból.
// A számok nem ismétlődhetnek.
// A program írja ki, hogy az eddigi számhúzások alapján (minden héten megjátszotta)
// hány darab kettes, hármas, négyes, vagy ötös találata lett volna.

namespace Lottoszamok
{
    class Program
    {
        static List<LotteryNumbers> lottoszamok = new List<LotteryNumbers>();
        static List<int> ownNumbers = new List<int>();


        static void Main(string[] args)
        {
            Welcome();
            FileRead();
            UserInput(1, "az első");
            UserInput(2, "a második");
            UserInput(3, "a harmadik");
            UserInput(4, "a negyedik");
            UserInput(5, "az ötödik");
            Result();

            Console.ReadKey();
        }


        static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ötöslottó számok\n");
            Console.ResetColor();

            Console.WriteLine("Add meg az öt számodat, majd láthatod,\n" +
                "hogy hány találatod lett volna az Ötöslottó sorsolások kezdete óta.\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Csak 1 és 90 közötti számok lehetnek.\n\n");
            Console.ResetColor();
        }


        static void FileRead()
        {
            StreamReader sr = new StreamReader("otos.csv", Encoding.UTF8);

            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] temp = sor.Split(';');
                LotteryNumbers lottery = new LotteryNumbers(Convert.ToInt32(temp[11]), Convert.ToInt32(temp[12]),
                    Convert.ToInt32(temp[13]), Convert.ToInt32(temp[14]), Convert.ToInt32(temp[15]));

                lottoszamok.Add(lottery);
            }

            sr.Close();
        }


        static void UserInput(int OwnNbr, string which)
        {
            bool included = false;

            do
            {
                Console.Write("Melyik " + which + " szám? ");
                OwnNbr = Convert.ToInt32(Console.ReadLine());

                if (ownNumbers.Contains(OwnNbr))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A " + OwnNbr + " számot egyszer már megadad!\n");
                    Console.ResetColor();
                    included = true;
                }

                else
                {
                    included = false;
                }

            } while (!(OwnNbr > 0 && OwnNbr < 91 && included == false)); // OwnNumber2 <= 0 || OwnNumber2 >= 91 || !(included == false)

            ownNumbers.Add(OwnNbr);

            ownNumbers.Sort(); // Tömbnél: Array.Sort(ownNumbers);
        }


        static void Result() {

            List<int> ResultLista = new List<int>();

            foreach (var egyHuzas in lottoszamok)
            {
                int talalat = 0;
                foreach (var tippeltSzam in ownNumbers)
                {
                    if (egyHuzas.Number1 == tippeltSzam)
                    {
                        talalat++;
                    }

                    else if (egyHuzas.Number2 == tippeltSzam)
                    {
                        talalat++;
                    }

                    else if (egyHuzas.Number3 == tippeltSzam)
                    {
                        talalat++;
                    }

                    else if (egyHuzas.Number4 == tippeltSzam)
                    {
                        talalat++;
                    }

                    else if (egyHuzas.Number5 == tippeltSzam)
                    {
                        talalat++;
                    }
                }

                ResultLista.Add(talalat);
            }


            int kettes = 0;
            int harmas = 0;
            int negyes = 0;
            int otos = 0;

            for (int i = 0; i < ResultLista.Count; i++)
            {
                if (ResultLista[i] == 2)
                {
                    kettes++;
                }

                else if (ResultLista[i] == 3)
                {
                    harmas++;
                }

                else if (ResultLista[i] == 4)
                {
                    negyes++;
                }

                else if (ResultLista[i] == 5)
                {
                    otos++;
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\nA kettes találatok száma: " + kettes);
            Console.WriteLine("A hármas találatok száma: " + harmas);
            Console.WriteLine("A négyes találatok száma: " + negyes);
            Console.WriteLine("A ötös találatok száma: " + otos);
            Console.ResetColor();
        }
    }
}
