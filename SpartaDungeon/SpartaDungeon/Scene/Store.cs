using SpartaDungeon.Manager;
using SpartaDungeon.UI;
using System;
namespace SpartaDungeon.Scene
{
    public class Store
    {
        public static void ShowStore()
        {
            SetColorToText.SetColorToYellow("상점");
            Console.WriteLine($"\n[보유 골드]\n");
            SetColorToText.SetColorToMagenta($"{ GameManager.user.Gold} ");
            Console.Write("G\n");
            Console.WriteLine("\n[아이템 목록]\n");
            
            ShowStoreProduct(false);

            SetColorToText.SetColorToMagenta("1");
            Console.Write(". 아이템 구매\n");
            SetColorToText.SetColorToMagenta("2");
            Console.Write(". 아이템 판매\n");
            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.StoreInput();
        }

        // 아이템 구매 
        public static void BuyProduct()
        {
            SetColorToText.SetColorToYellow("상점 - 아이템 구매\n");
            Console.WriteLine($"[보유 골드]\n");
            SetColorToText.SetColorToMagenta($"{GameManager.user.Gold} ");
            Console.Write("G\n\n");
            Console.WriteLine("[아이템 목록]\n");
            
            ShowStoreProduct(true);

            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.BuyProductInput();
        }

        // 아이템 판매
        public static void SellProduct()
        {
            SetColorToText.SetColorToYellow("상점 - 아이템 판매\n");
            Console.WriteLine($"[보유 골드]\n");
            SetColorToText.SetColorToMagenta($"{GameManager.user.Gold} ");
            Console.Write("G\n\n");
            Console.WriteLine("[아이템 목록]\n");

            Inventory.ShowInventoryItem(true);

            SetColorToText.SetColorToMagenta("\n0");
            Console.Write(". 나가기\n\n");

            InputText.sellProductInput();
        }

        // 상점 물품 보여주는 함수
        public static void ShowStoreProduct(bool showNum)
        {
            // items에 있는 아이템 목록 
            for (int i = 0; i < GameManager.items.Count; i++)
            {
                // 아이템의 속성 값이 0이 아닌 것 모두 뽑기
                List<string> itemProperty = new List<string>();
                if (GameManager.items[i].AttackPower != 0) { itemProperty.Add($"공격력 + {GameManager.items[i].AttackPower} "); }
                if (GameManager.items[i].Defense != 0) { itemProperty.Add($"방어력 + {GameManager.items[i].Defense} "); }
                if (GameManager.items[i].HP != 0) { itemProperty.Add($"체력 + {GameManager.items[i].HP} "); }

                // 아이템이 구매 완료 되었는지 확인
                string purchased;
                if (GameManager.items[i].IsPurchased) { purchased = "구매완료"; }
                // 구매되지 않았다면 현재 가지고 있는 골드 양 나타내기
                else { purchased = GameManager.items[i].Gold.ToString(); }

                // 출력
                // 아이템 구매 창 -> 숫자를 나타내야 할 때
                if (showNum) 
                {
                    Console.Write(" - ");
                    SetColorToText.SetColorToMagenta($"{i + 1} ");
                    Console.Write($"{GameManager.items[i].Name}   |  "); 
                }
                // 그냥 상점 창일 때
                else { Console.Write($"- {GameManager.items[i].Name}   |  "); }
                // 아이템 속성 
                foreach (string property in itemProperty)
                {
                    string[] prop = property.Split();
                    Console.Write(prop[0] + " ");
                    SetColorToText.SetColorToMagenta(prop[1] + prop[2]); 
                }
                // 아이템 설명 + 골드나 구매완료 
                Console.Write($"  |   {GameManager.items[i].Description}   |  ");
                SetColorToText.SetColorToMagenta($"{purchased}");
                Console.Write(" G\n");

            }
            Console.WriteLine();
        }
    }
}
