using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Card
{
    public partial class Form1 : Form
    {
        private Board board;
        private CardMgr cardMgr;
        Pic pic = new Pic();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Bitmap[] bitmap = new Bitmap[24];
        Size size;
        int bitmapx, bitmapy;//비트맵 파일의 넓이와 높이
        string sPath;


        public Form1()
        {
            InitializeComponent();
            sPath = Directory.GetCurrentDirectory();
            sPath = Path.Combine(sPath + "\\Bitmap\\card.bmp");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board = new Board(boardPanel.Width, boardPanel.Height);

            cardMgr = new CardMgr();
            cardMgr.suffle();//카드매니저안의 카드들의 타입 섞기

            timer.Interval = 1000;//2번째 클릭 딜레이관련
            timer.Tick += new EventHandler(time_tick);

            OpenFileDialog openFile = new OpenFileDialog();

            size = new Size(80, 120);

            for (int i = 0; i < 24; i++)
            {
                bitmap[i] = new Bitmap(sPath);//비트맵에 카드뒷면 그려주기
                bitmap[i] = new Bitmap(bitmap[i], size);
            }
            bitmapx = bitmap[0].Width;
            bitmapy = bitmap[0].Height;//비트맵 높이 넓이 값 가져오기
        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            board.Darw(e.Graphics);
            for(int i=0;i<24;i++)
            {
                if(bitmap[i]!=null)
                    e.Graphics.DrawImage(bitmap[i], (i%6)*board.WSlotSize + (board.WSlotSize - bitmap[i].Width) / 2, (i/6)*board.HSlotSize + (board.HSlotSize - bitmap[i].Height)/2);
            }

        }

        private void time_tick(object sender, EventArgs e)//2번째 카드고르고 1초 지날경우 이벤트
        {
            if (pic.FistType != pic.SecondType)//선택한 두 카드가 다를경우
            {
                bitmap[pic.fn] = new Bitmap(sPath);//카드 뒷면으로 이미지 전환
                bitmap[pic.sn] = new Bitmap(sPath);
                bitmap[pic.fn] = new Bitmap(bitmap[pic.fn], size);
                bitmap[pic.sn] = new Bitmap(bitmap[pic.sn], size);
                cardMgr.card[pic.fn].open = false;//선택한 카드의 펼쳐진 bool값을 false 로변경 = 카드 덮어주기
                cardMgr.card[pic.sn].open = false;
            }
            else//같은 카드를 뽑았을경우
            {
                bitmap[pic.fn] = null;
                bitmap[pic.sn] = null;
            }
            pic.PicCool = false;
            boardPanel.Invalidate();
            pic.reset();
            timer.Enabled = false;//끝내기
            
        }

        private void boardPanel_MouseDown(object sender, MouseEventArgs e)//판넬에 클릭 감지될경우
        {
            int n = e.Location.X;
            int num = e.Location.X / board.WSlotSize + (e.Location.Y / board.HSlotSize) * 6; //몇번 카드를 골랐는지 번호값
            if (cardMgr.card[num].open == false && pic.PicCool == false)//뒷면인 카드를 골랐을경우
            {
                if (MousePostion(e.Location, num))
                {
                    pic.PicCard(cardMgr.card[num].Type, num);
                    bitmap[num] = cardMgr.PicImageChange(num,size);
                    if (pic.n >= 2)//2번째 선택햇을경우
                    {
                        pic.PicCool = true;//일정시간 카드 선택불가능하게 만들기
                        timer.Start();//일정시간 타이머 작동
                        if (cardMgr.end() == true)//승리체크
                                MessageBox.Show("WIN");
                    }

                    boardPanel.Invalidate();
                }
            }
        }


        public bool MousePostion(Point p,int num)//정확히 카드그림를 눌렀는지 체크
        {
            bool a = false;
            if(p.X %board.WSlotSize > (board.WSlotSize - bitmapx) / 2
                    && p.X % board.WSlotSize < board.WSlotSize - ((board.WSlotSize - bitmapx) / 2)
                    && p.Y % board.HSlotSize > (board.HSlotSize-bitmapy) / 2
                    && p.Y % board.HSlotSize < board.HSlotSize-((board.HSlotSize-bitmapy)/2))
            {
                    a = true;
            }
            return a;
        }
    }
}


// picturebox 제거하고 form에 직접 그릴것
// 맞춘 그림은 사라지게 할 것
// 그림을 여러장 준비하여 6x4 까지 가능하게 할 것