using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Card
{
    class CardMgr
    {
        //public const int H = 4;
        //public const int V = 3;
        private const int num = 24;
        public Card[] card;
        string sPath;
        public CardMgr()
        {
            PathNameReset();
            card = new Card[num];
            for (int i = 0; i < num / 2; i++)
            {
                card[i] = new Card(i);
                card[num / 2 + i] = new Card(i);
            }
        }

        public void suffle()//카드 섞어주기
        {
            Random rand = new Random();
            int first, second, temp;
            for (int i = 0; i < 100; i++)
            {
                first = rand.Next(24);
                second = rand.Next(24);
                if (first != second)
                {
                    temp = card[first].Type;
                    card[first].Type = card[second].Type;
                    card[second].Type = temp;
                }
            }
        }

        public bool end()//승리판정
        {
            bool win = true;
            for (int i = 0; i < num; i++)
            {
                if (card[i].open != true)
                    win = false;
            }
            return win;
        }

        void PathNameReset()
        {
            sPath = Directory.GetCurrentDirectory();
            sPath = Path.Combine(sPath + "\\Bitmap");
        }

        public Bitmap PicImageChange(int num,Size size)//선택된 카드의 이미지 변경
        {
            Bitmap b = null;
            card[num].open = true;
            PathNameReset();
            switch (card[num].Type)
            {
                
                case 0:
                    sPath = Path.Combine(sPath + "\\card1.bmp");
                    break;
                case 1:
                    sPath = Path.Combine(sPath + "\\card2.bmp");
                    break;
                case 2:
                    sPath = Path.Combine(sPath + "\\card3.bmp");
                    break;
                case 3:
                    sPath = Path.Combine(sPath + "\\card4.bmp");
                    break;
                case 4:
                    sPath = Path.Combine(sPath + "\\card5.bmp");
                    break;
                case 5:
                    sPath = Path.Combine(sPath + "\\card6.bmp");
                    break;
                case 6:
                    sPath = Path.Combine(sPath + "\\card7.bmp");
                    break;
                case 7:
                    sPath = Path.Combine(sPath + "\\card8.bmp");
                    break;
                case 8:
                    sPath = Path.Combine(sPath + "\\card9.bmp");
                    break;
                case 9:
                    sPath = Path.Combine(sPath + "\\card10.bmp");
                    break;
                case 10:
                    sPath = Path.Combine(sPath + "\\card11.bmp");
                    break;
                case 11:
                    sPath = Path.Combine(sPath + "\\card12.bmp");
                    break;
            }
            Console.WriteLine(sPath);

            b = new Bitmap(sPath);
            b = new Bitmap(b, size);

            return b;
        }
    }
}
