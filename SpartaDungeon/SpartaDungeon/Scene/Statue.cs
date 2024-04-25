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

            SetColorToText.SetColorToYellow("상태창");
            UpdateStatus();

            Console.Write("\nLV ");
            SetColorToText.SetColorToMagenta(GameManager.user.Level.ToString());
            Console.Write("\nClass ");
            SetColorToText.SetColorToMagenta(GameManager.user.Job.ToString());
            Console.Write("\n공격력 ");
            SetColorToText.SetColorToMagenta(GameManager.user.AttackPower.ToString());
            Console.Write(attackPower);
            Console.Write("\n방어력 ");
            SetColorToText.SetColorToMagenta(GameManager.user.Defense.ToString());
            Console.Write(defense);
            Console.Write("\n체 력 ");
            SetColorToText.SetColorToMagenta(GameManager.user.HP.ToString());
            Console.Write(hp);
            Console.Write("\nGold ");
            SetColorToText.SetColorToMagenta(GameManager.user.Gold.ToString());
            Console.Write(" G");

            Console.WriteLine("\n");
            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

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

