using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottoszamok
{
    class LotteryNumbers
    {
        private int number1;
        private int number2;
        private int number3;
        private int number4;
        private int number5;

        public LotteryNumbers(int number1, int number2, int number3, int number4, int number5)
        {
            this.number1 = number1;
            this.number2 = number2;
            this.number3 = number3;
            this.number4 = number4;
            this.number5 = number5;
        }

        public int Number1 { get => number1; set => number1 = value; }
        public int Number2 { get => number2; set => number2 = value; }
        public int Number3 { get => number3; set => number3 = value; }
        public int Number4 { get => number4; set => number4 = value; }
        public int Number5 { get => number5; set => number5 = value; }


        public string Kiir()
        {
            return Number1 + ", " + Number2 + ", " + Number3 + ", " + Number4 + ", " + Number5;
        }
    }
}
