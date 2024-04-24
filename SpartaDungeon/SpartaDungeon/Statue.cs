using System;
namespace SpartaDungeon
{
    public class Status
    {
        private static string attackPower = "";
        private static string defense = "";
        private static string hp = "";

        // 상태창
        public static void ViewStatus()
        {
            // 초기화
            attackPower = "";
            defense = "";
            hp = "";

            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("상태 보기\n");

            UpdateStatus();

            Console.WriteLine("LV. " + GameManager.user.Level);
            Console.WriteLine("Chad ( " + GameManager.user.Job + " )");
            Console.WriteLine("공격력 : " + GameManager.user.AttackPower + attackPower);
            Console.WriteLine("방어력 : " + GameManager.user.Defense + defense);
            Console.WriteLine("체 력 : " + GameManager.user.HP + hp);
            Console.WriteLine("Gold : " + GameManager.user.Gold + " G\n");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Console.Clear();
                    GameManager.Village();
                    break;
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n");
                }
            }
        }

        // 상태창 업데이트
        public static void UpdateStatus()
        {
            int aP = 0;
            int dP = 0;
            int hP = 0;
            foreach (Item item in Inventory.GetInventory())
            {
                if (item.IsEquipped)
                {
                    aP += item.AttackPower;
                    dP += item.Defense;
                    hP += item.HP;
                }
            }

            if (aP > 0) { attackPower = "(+" + aP.ToString() +")"; }
            if (dP > 0) { defense = "(+" + dP.ToString() + ")"; }
            if (hP > 0) { hp = "(+" + hP.ToString() + ")"; }
        }
    }
}

