using System;
namespace SpartaDungeon
{
    public class Status
    {
        // 상태창
        public static void ViewStatus()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("상태 보기\n");
            Console.WriteLine("LV. " + GameManager.user.Level);
            Console.WriteLine("Chad ( " + GameManager.user.Job + " )");
            Console.WriteLine("공격력 : " + GameManager.user.AttackPower);
            Console.WriteLine("방어력 : " + GameManager.user.Defense);
            Console.WriteLine("체 력 : " + GameManager.user.HP);
            Console.WriteLine("Gold : " + GameManager.user.Gold + " G\n");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0) 
                { 
                    GameManager.Village(); 
                    break; 
                }
                else 
                {
                    Console.WriteLine("잘못된 입력입니다."); 
                }
            }
        }
    }
}

