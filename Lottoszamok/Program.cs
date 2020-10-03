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
        static List<LotteryNumbers> ownNumbers2 = new List<LotteryNumbers>();

        static List<int> ownNumbers = new List<int>();
        static List<int> ownNumbers3 = new List<int>();
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

            ownNumbers2.Add(new LotteryNumbers(OwnNbr1, OwnNbr2, OwnNbr3, OwnNbr4, OwnNbr5));
        }


        static void Result() {

            int kettestalalat = 0;

            for (int i = 0; i < lottoszamok.Count; i++)
            {
                if (lottoszamok[i].Number1 == ownNumbers[1] && lottoszamok[i].Number2 == ownNumbers[2])
                {
                    kettestalalat++;
                }
            }

            Console.WriteLine("Kettes találatok száma: " + kettestalalat);


            int harmastalalat = 0;

            for (int i = 0; i < lottoszamok.Count; i++)
            {
                if (lottoszamok[i].Number1 == ownNumbers[1] && lottoszamok[i].Number2 == ownNumbers[2] &&
                    lottoszamok[i].Number3 == ownNumbers[3])
                {
                    harmastalalat++;
                }
            }

            Console.WriteLine("Hármas találatok száma: " + harmastalalat);


            int negyestalalat = 0;

            for (int i = 0; i < lottoszamok.Count; i++)
            {
                if (lottoszamok[i].Number1 == ownNumbers[1] && lottoszamok[i].Number2 == ownNumbers[2] &&
                    lottoszamok[i].Number3 == ownNumbers[3] && lottoszamok[i].Number4 == ownNumbers[4])
                {
                    negyestalalat++;
                }
            }

            Console.WriteLine("Négyes találatok száma: " + negyestalalat);


            int otostalalat = 0;

            for (int i = 0; i < lottoszamok.Count; i++)
            {
                if (lottoszamok[i].Number1 == ownNumbers[1] && lottoszamok[i].Number2 == ownNumbers[2] &&
                    lottoszamok[i].Number3 == ownNumbers[3] && lottoszamok[i].Number4 == ownNumbers[4] &&
                    lottoszamok[i].Number5 == ownNumbers[5])
                {
                    otostalalat++;
                }
            }

            Console.WriteLine("Ötös találatok száma: " + otostalalat);



            //Enumerable.SequenceEqual(lottoszamok[0].Number1, ownNumbers[1]);

            //int result = lottoszamok[0].SelectMany(list => list).Distinct().Count();

            //int hitsTwo = 0;

            //if (lottoszamok.Any(item => ownNumbers.Contains(item.Number1)))
            //{
            //    hitsTwo++;
            ////}

            //for (int i = 0; i < lottoszamok.Count; i++)
            //{
            //    if (lottoszamok.Any(item => ownNumbers.Contains(item.Number1)))
            //    {
            //        hitsTwo++;
            //    }
            ////}

            //for (int i = 0; i < lottoszamok.Count; i++)
            //{
            //    if (lottoszamok[i].Number1.)
            //    {

            //    }
            ////}

            //int a = 0;

            //foreach (var item in lottoszamok)
            //{
            //    if (lottoszamok.Any(aa => ownNumbers.Contains(aa.Number1)))
            //    {
            //        a++;
            //    }
            //}

            //Console.WriteLine("Kettes találatok száma: " + a);

            //var firstNotSecond = lottoszamok.Except(ownNumbers). ();
            //var secondNotFirst = list2.Except(list1).ToList();

            //var aadd = lottoszamok.Except();

            //bool equal = ownNumbers.SequenceEqual(lottoszamok[0].Number1);

            //Console.WriteLine(
            //    "The lists {0} equal.",
            //    equal ? "are" : "are not");

            //var dad = ownNumbers.SequenceEqual(lottoszamok);

            //lottoszamok. collection = (lottoszamok)myObject;


            //Console.WriteLine(ownNumbers2.Count);

            //Console.WriteLine(ownNumbers2[0].Number1);

            ////Console.WriteLine("\n mia " + ownNumbers2[0]);

            //bool sss = lottoszamok.Contains(ownNumbers2[0]);

            //Console.WriteLine("ssssss" + sss);

            //var firstNotSecond = lottoszamok.Union(ownNumbers2).ToList().Count;
            ////var secondNotFirst = list2.Except(list1).ToList();

            //Console.WriteLine("\naaaaaaaaaaaa: " + firstNotSecond);

            ////var ssss = lottoszamok.Contains(ownNumbers2[4]);

            //Console.WriteLine(ownNumbers2[0].Kiir());
            //Console.WriteLine(lottoszamok[0].Kiir());

            //int db = 0;

            //for (int i = 0; i < lottoszamok.Count; i++)
            //{
            //    if (ownNumbers2[0].Number1 == lottoszamok[i].Number1)
            //    {
            //         db++;
            //    }

            //}

            //var aaaas = lottoszamok[1].Number1.Find(11);

            //var aaaaas = lottoszamok.Where(item => item.Number1 == 23).Count();

            //Console.WriteLine(aaaaas);

            //Console.WriteLine(db);

            //if (lottoszamok.Contains(new LotteryNumbers(16, 61, 71, 77, 89)))
            //{
            //    Console.WriteLine("KKKKKKK");
            //}

            //else
            //{
            //    Console.WriteLine("nem");
            //}



            ////lottoszamok.Add(new LotteryNumbers(16, 61, 71, 77, 89));

            ////var awww = lottoszamok.Contains(new LotteryNumbers(16, 61, 71, 77, 89));

            ////var aaa = lottoszamok.FindIndex(x => x.Number1 == 16 && x.Number2 == 61);
            //var aaa = lottoszamok.Exists(x => x.Number1 == 16 && x.Number2 == 61);

            ////Console.WriteLine("Cont: " + awww);
            //Console.WriteLine("Find: " + aaa);

            //Console.WriteLine("kiir");
            //Console.WriteLine(lottoszamok[3315].Kiir());

            List<int> talalatokLista = new List<int>();


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

                //Console.WriteLine("A.. " + talalat);
                talalatokLista.Add(talalat);



            }


            int kettes = 0;
            int harmas = 0;
            int negyes = 0;
            int otos = 0;


            for (int i = 0; i < talalatokLista.Count; i++)
            {
                if (talalatokLista[i] == 2)
                {
                    kettes++;
                }

                else if (talalatokLista[i] == 3)
                {
                    harmas++;
                }

                else if (talalatokLista[i] == 4)
                {
                    negyes++;
                }

                else if (talalatokLista[i] == 5)
                {
                    otos++;
                }
            }
            Console.WriteLine("A kettes találatk száma: " + kettes);



            Console.WriteLine();

            ////var matches = lottoszamok.Where(p => p.Number1 == 16).ToList();

            ////Console.WriteLine("új"  + matches);

            //List<LotteryNumbers> results = lottoszamok.FindAll(x => x.Number1 == 1);

            //for (int i = 0; i < results.Count; i++)
            //{
            //    Console.WriteLine(i + ",");
            //}

        }
    }
}
