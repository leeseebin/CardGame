using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Card
{
    class Pic
    {
        public int FistType;
        public int SecondType;
        public int n = 0;
        public int fn, sn;
        public bool PicCool = false;
        public Pic()
        {
        }

        public void PicCard(int ChoiceType, int num)//마우스로 카드 클릭시 선택
        {
            if (n == 0)//첫번째 카드 선택중
            {
                FistType = ChoiceType;
                fn = num;
            }
            if (n == 1)//두번째 카드 선택중
            {
                SecondType = ChoiceType;
                sn = num;
            }
            n++;
        }

        public void reset()//2장의 카드를 선택한후 일정시간뒤 호출해 리셋시켜준다.
        {
            FistType = -1;
            SecondType = -2;
            n = 0;
        }
    }
}
