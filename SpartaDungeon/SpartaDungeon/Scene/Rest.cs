using SpartaDungeon.Manager;
using SpartaDungeon.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon.Scene
{
    public class Rest
    {
        public static void ShowRestPlace()
        {
            SetColorToText.SetColorToYellow("휴식하기\n");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다.");
            Console.WriteLine($"\n[보유 골드]\n");
            SetColorToText.SetColorToMagenta($"{GameManager.user.Gold} ");
            Console.Write("G\n\n");

            SetColorToText.SetColorToMagenta("1");
            Console.Write(". 휴식하기\n");
            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.RestInput();
        }

        public static void Resting()
        {
            Console.Clear();
            if (GameManager.user.Gold >= 500)
            {
                SetColorToText.SetColorToSkyBlue("휴식중 ..\n");
                Thread.Sleep(600);
                SetColorToText.SetColorToSkyBlue("3\n");
                Thread.Sleep(600);
                SetColorToText.SetColorToSkyBlue("2\n");
                Thread.Sleep(600);
                SetColorToText.SetColorToSkyBlue("1\n");
                Thread.Sleep(600);
                SetColorToText.SetColorToSkyBlue("휴식 완료!\n");


                GameManager.user.HP += 20;
                if (GameManager.maxHp < GameManager.user.HP) { GameManager.user.HP = GameManager.maxHp; }   

                GameManager.user.Gold -= 500;
            }
            else
            {
                SetColorToText.SetColorToRed("\n골드가 부족합니다.");
            }

            Console.Write($"현재 HP : ");
            SetColorToText.SetColorToMagenta($"{ GameManager.user.HP}\n");
            Console.Write($"현재 Gold : ");
            SetColorToText.SetColorToMagenta($"{GameManager.user.Gold}\n\n");

            SetColorToText.SetColorToMagenta("1");
            Console.Write(". 휴식하기\n");
            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");
        }
    }
}
