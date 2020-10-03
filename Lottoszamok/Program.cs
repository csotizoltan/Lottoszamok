﻿using System;
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

        //static int[] ownNumbers = new int[5];

        static void Main(string[] args)
        {
            FileRead();
            UserInput();
            Result();

            Console.ReadKey();
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


        static void UserInput()
        {
            int OwnNbr1, OwnNbr2, OwnNbr3, OwnNbr4, OwnNbr5;

            bool included = false;


            do
            {
                Console.WriteLine("Mi az első szám?");
                OwnNbr1 = Convert.ToInt32(Console.ReadLine());

            } while (!(OwnNbr1 > 0 && OwnNbr1 < 91));

            ownNumbers.Add(OwnNbr1);


            do
            {
                Console.WriteLine("Mi a második szám?");
                OwnNbr2 = Convert.ToInt32(Console.ReadLine());

                if (ownNumbers.Contains(OwnNbr2))
                {
                    Console.WriteLine("A " + OwnNbr2 + " számot egyszer már megadad!");
                    included = true;
                }

                else
                {
                    included = false;
                }

            } while (!(OwnNbr2 > 0 && OwnNbr2 < 91 && included == false)); // OwnNumber2 <= 0 || OwnNumber2 >= 91 || !(included == false)

            ownNumbers.Add(OwnNbr2);


            do
            {
                Console.WriteLine("Mi a hamradik szám?");
                OwnNbr3 = Convert.ToInt32(Console.ReadLine());

                if (ownNumbers.Contains(OwnNbr3))
                {
                    Console.WriteLine("A " + OwnNbr3 + " számot egyszer már megadad!");
                    included = true;
                }

                else
                {
                    included = false;
                }

            } while (!(OwnNbr3 > 0 && OwnNbr3 < 91 && included == false));

            ownNumbers.Add(OwnNbr3);


            do
            {
                Console.WriteLine("Mi a negyedik szám?");
                OwnNbr4 = Convert.ToInt32(Console.ReadLine());

                if (ownNumbers.Contains(OwnNbr4))
                {
                    Console.WriteLine("A " + OwnNbr4 + " számot egyszer már megadad!");
                    included = true;
                }

                else
                {
                    included = false;
                }

            } while (!(OwnNbr4 > 0 && OwnNbr4 < 91 && included == false));

            ownNumbers.Add(OwnNbr4);


            do
            {
                Console.WriteLine("Mi a ötödik szám?");
                OwnNbr5 = Convert.ToInt32(Console.ReadLine());

                if (ownNumbers.Contains(OwnNbr5))
                {
                    Console.WriteLine("A " + OwnNbr5 + " számot egyszer már megadad!");
                    included = true;
                }

                else
                {
                    included = false;
                }

            } while (!(OwnNbr5 > 0 && OwnNbr5 < 91 && included == false));

            ownNumbers.Add(OwnNbr5);

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

            Console.WriteLine("A kettes találatok száma: " + kettes);
            Console.WriteLine("A hármas találatok száma: " + harmas);
            Console.WriteLine("A négyes találatok száma: " + negyes);
            Console.WriteLine("A ötös találatok száma: " + otos);
        }
    }
}
