using System;
namespace SpartaDungeon
{
	public class Store
	{
        // 상점
        public static void ShowStore()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("상점\n");
            Console.WriteLine("[보유 골드]\n" + GameManager.user.Gold + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            // 현재 상점 물품 보여주기
            ShowStoreProduct(false);
            Console.WriteLine("1. 아이템 구매");
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
                // 아이템 구매
                else if (input == 1) 
                { 
                    BuyProduct(); 
                    break; 
                }
                else 
                { 
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        // 상점 물품 보여주는 함수
        public static void ShowStoreProduct(bool showNum)
        {
            // items에 있는 아이템 목록 
            for (int i = 0; i < GameManager.items.Length; i++)
            {
                // 아이템의 속성 값이 0 이 아닌 것 모두 뽑기
                List<string> itemProperty = new List<string>();
                if (GameManager.items[i].AttackPower != 0) { itemProperty.Add(("공격력 +" + GameManager.items[i].AttackPower) + " "); }
                if (GameManager.items[i].Defense != 0) { itemProperty.Add(("방어력 +" + GameManager.items[i].Defense) + " "); }
                if (GameManager.items[i].HP != 0) { itemProperty.Add(("체력 +" + GameManager.items[i].HP) + " "); }

                // 아이템이 구매 완료 되었는지 확인
                string purchased;
                if (GameManager.items[i].IsPurchased) { purchased = "구매완료"; }
                // 구매되지 않았다면 현재 가지고 있는 골드 양 나타내기
                else { purchased = GameManager.items[i].Gold.ToString() + " G"; }

                // 출력
                // 아이템 구매 창 -> 숫자를 나타내야 할 때
                if (showNum) { Console.Write("- " + (i + 1) + " " + GameManager.items[i].Name + "  |  "); }
                // 그냥 상점 창일 때
                else { Console.Write("- " + GameManager.items[i].Name + "  |  "); }
                // 아이템 속성 
                foreach (string property in itemProperty) { Console.Write(property); }
                // 아이템 설명 + 골드나 구매완료 
                Console.Write("  |  " + GameManager.items[i].Description + "  |  " + purchased + "\n");
            }
            Console.WriteLine();
        }

        // 아이템 구매 
        public static void BuyProduct()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("상점 - 아이템 구매\n");
            Console.WriteLine("[보유 골드]\n" + GameManager.user.Gold + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            // 현재 상점 물품 보여주기
            ShowStoreProduct(true);
            Console.WriteLine("0. 나가기\n");


            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0) 
                { 
                    ShowStore(); 
                    break; 
                }
                // 현재 상점에 있는 물품의 숫자를 고른다면
                else if (input <= GameManager.items.Length)
                {
                    // 이미 구매한 아이템이라면
                    if (GameManager.items[input-1].IsPurchased) 
                    { 
                        Console.WriteLine("이미 구매한 아이템입니다."); 
                    }
                    // 구매가 가능하다면
                    else
                    {
                        //보유 금액이 충분하다면
                        if (GameManager.user.Gold >= GameManager.items[input-1].Gold)
                        {
                            Console.WriteLine("구매를 완료했습니다.");
                            // 재화 감소
                            GameManager.user.Gold -= GameManager.items[input - 1].Gold;
                            // 인벤토리에 아이템 추가 
                            Inventory.AddItemInInventory(GameManager.items[input-1]);
                            // 상점에 구매완료 표시
                            GameManager.items[input-1].IsPurchased = true;

                            // 아이템 창 띄우기
                            BuyProduct();
                        }
                        // 보유 금액이 부족하다면
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.\n");
                        }
                    }
                }
                else 
                { 
                    Console.WriteLine("잘못된 입력입니다. 구매할 수 있는 상품의 번호는 1~" + GameManager.items.Length + " 입니다"); 
                }
            }
        }
    }
}