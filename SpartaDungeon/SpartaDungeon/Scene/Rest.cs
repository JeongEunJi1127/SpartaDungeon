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
            Console.WriteLine("휴식하기");
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {GameManager.user.Gold} G)\n");

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기\n");

            InputText.RestInput();
        }

        public static void Resting()
        {
            Console.Clear();
            if (GameManager.user.Gold >= 500)
            {
                Console.WriteLine("휴식중 ..");
                Thread.Sleep(600);
                Console.WriteLine("3");
                Thread.Sleep(600);
                Console.WriteLine("2");
                Thread.Sleep(600);
                Console.WriteLine("1");
                Thread.Sleep(600);
                Console.WriteLine("휴식 완료!\n");

                // 기존의 hp를 넘으면 안되므로 미리 저장
                int maxHp = GameManager.user.HP;
                GameManager.user.HP += 20;
                if (maxHp < GameManager.user.HP) { GameManager.user.HP = maxHp; }   

                GameManager.user.Gold -= 500;
            }
            else
            {
                Console.WriteLine("\n골드가 부족합니다.\n");     
            }

            Console.WriteLine($"현재 HP : {GameManager.user.HP}");
            Console.WriteLine($"현재 Gold : {GameManager.user.Gold}\n");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기\n");
        }
    }
}
