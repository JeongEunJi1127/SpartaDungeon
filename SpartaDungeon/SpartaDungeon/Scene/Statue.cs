using SpartaDungeon.Manager;
using SpartaDungeon.UI;
using System;
namespace SpartaDungeon.Scene
{
    public class Status
    {
        private static string attackPower = "";
        private static string defense = "";
        private static string hp = "";

        public static void ShowStatus()
        {
            // 초기화
            attackPower = "";
            defense = "";
            hp = "";

            Console.WriteLine("상태 보기\n");

            UpdateStatus();

            Console.WriteLine($"LV. {GameManager.user.Level}");
            Console.WriteLine($"Chad ( {GameManager.user.Job} )");
            Console.WriteLine($"공격력 : {GameManager.user.AttackPower} {attackPower}");
            Console.WriteLine($"방어력 : {GameManager.user.Defense} {defense}");
            Console.WriteLine($"체 력 : {GameManager.user.HP} {hp}");
            Console.WriteLine($"Gold : {GameManager.user.Gold} G\n");
            Console.WriteLine("0. 나가기\n");

            InputText.StatusInput();
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

            if (aP > 0) { attackPower = $"(+{aP})"; }
            if (dP > 0) { defense = $"(+{dP})"; }
            if (hP > 0) { hp = $"(+{hP})"; }
        }
    }
}

