using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Card
{

    class Card
    {
        //private static Bitmap[] bitmaps;
        //private static Bitmap back;
        //static Card() // 정적 생성자(static constructor)
        //{
        //    bitmaps = new Bitmap[12];
        //    for(int i = 0; i < 24; i++)
        //    {

        //        bitmaps[i] = new Bitmap(string.Format(@"D:\Desktop\newcardgame\Card\Card\Bitmap\card%1d.bmp", i+1));
                
        //    }
        //}
        public int Type { get; set; }  // 프로퍼티(property)
        public bool open;
        public Card(int type)
        {
            open = false;
            Type = type;
        }
    }
}
