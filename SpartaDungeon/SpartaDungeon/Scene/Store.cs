using SpartaDungeon.Manager;
using SpartaDungeon.UI;
using System;
namespace SpartaDungeon.Scene
{
    public class Store
    {
        public static void ShowStore()
        {
            Console.WriteLine("상점\n");
            Console.WriteLine($"[보유 골드]\n{GameManager.user.Gold} G\n");
            Console.WriteLine("[아이템 목록]\n");
            // 현재 상점 물품 보여주기
            ShowStoreProduct(false);

            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기\n");

            InputText.StoreInput();
        }

        // 아이템 구매 
        public static void BuyProduct()
        {
            Console.WriteLine("상점 - 아이템 구매\n");
            Console.WriteLine("[보유 골드]\n" + GameManager.user.Gold + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            // 현재 상점 물품 보여주기
            ShowStoreProduct(true);
            Console.WriteLine("0. 나가기\n");

            InputText.BuyProductInput();
        }

        // 아이템 판매
        public static void SellProduct()
        {
            Console.WriteLine("상점 - 아이템 판매\n");
            Console.WriteLine($"[보유 골드]\n {GameManager.user.Gold} G\n");
            Console.WriteLine("[아이템 목록]\n");

            Inventory.ShowInventoryItem(true);

            Console.WriteLine("\n0. 나가기\n");
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");

            InputText.sellProductInput();
        }

        // 상점 물품 보여주는 함수
        public static void ShowStoreProduct(bool showNum)
        {
            // items에 있는 아이템 목록 
            for (int i = 0; i < GameManager.items.Length; i++)
            {
                // 아이템의 속성 값이 0 이 아닌 것 모두 뽑기
                List<string> itemProperty = new List<string>();
                if (GameManager.items[i].AttackPower != 0) { itemProperty.Add($"공격력 + {GameManager.items[i].AttackPower} "); }
                if (GameManager.items[i].Defense != 0) { itemProperty.Add($"방어력 + {GameManager.items[i].Defense} "); }
                if (GameManager.items[i].HP != 0) { itemProperty.Add($"체력 + {GameManager.items[i].HP} "); }

                // 아이템이 구매 완료 되었는지 확인
                string purchased;
                if (GameManager.items[i].IsPurchased) { purchased = "구매완료"; }
                // 구매되지 않았다면 현재 가지고 있는 골드 양 나타내기
                else { purchased = GameManager.items[i].Gold.ToString() + " G"; }

                // 출력
                // 아이템 구매 창 -> 숫자를 나타내야 할 때
                if (showNum) { Console.Write($"- {i + 1} {GameManager.items[i].Name}   |  "); }
                // 그냥 상점 창일 때
                else { Console.Write($"- {GameManager.items[i].Name}   |  "); }
                // 아이템 속성 
                foreach (string property in itemProperty) { Console.Write(property); }
                // 아이템 설명 + 골드나 구매완료 
                Console.Write($"  |   {GameManager.items[i].Description}   |  {purchased} \n");
            }
            Console.WriteLine();
        }
    }
}
