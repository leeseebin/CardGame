using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Card
{

    class Board
    {
        public const int N = 3;
        public int Width { get; set; }
        public int Height { get; set; }
        public int HSlotSize { get; set; }
        public int WSlotSize { get; set; }
        public const int HN = 4;//카드 세로줄 갯수
        public const int WN = 6;//카드 가로줄 갯수
        public Board(int width, int height)
        {
            Width = width;//보드 전체 가로,세로 길이
            Height = height;
            HSlotSize = height / HN; //카드간의 가로 길이
            WSlotSize = width / WN; //카드칸의 가로 길이
        }

        public void Darw(Graphics g)//기본 보드에 선 그려주기
        {
            Pen pen = Pens.Black;
            float size = WSlotSize * WN;
            for (int i = 0; i <= HN; i++)
                g.DrawLine(pen, 0, i * HSlotSize, size, i * HSlotSize);
            size = HSlotSize * HN;
            for (int i = 0; i <= WN; i++)
                g.DrawLine(pen, i * WSlotSize, 0, i * WSlotSize, size);

        }

    }
}
