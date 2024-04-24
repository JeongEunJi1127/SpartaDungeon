﻿using SpartaDungeon.Manager;
using SpartaDungeon.Scene;

namespace SpartaDungeon.UI
{
    public class InputText
    {
        // 마을 입력
        public static void VillageInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Status.ShowStatus();
                        break;
                    case 2:
                        Console.Clear();
                        Inventory.ShowInventory();
                        break;
                    case 3:
                        Console.Clear();
                        Store.ShowStore();
                        break;
                    case 4:
                        Console.Clear();
                        Dungeon.ShowDungeon();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }

        // 상태창 입력
        public static void StatusInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Village.ShowVillage();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }

        // 인벤토리 입력
        public static void InventoryInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Village.ShowVillage();
                        break;
                    case 1:
                        Console.Clear();
                        Inventory.ManageEquipment();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }

        // 인벤토리 - 장착 관리 입력
        public static void ManageEquipmentInput()
        {
            while (true)
            {
                Console.WriteLine("\n장착하고 싶거나 장착 해제하고 싶은 장비의 번호를 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Console.Clear();
                    Inventory.ShowInventory();
                    break;
                }
                // 현재 인벤토리에 있는 물품의 숫자를 고른다면
                else if (input <= Inventory.GetInventory().Count)
                {
                    Item nowItem = Inventory.GetInventory()[input - 1];
                    Console.Clear();
                    Inventory.CheckTypeEquipment(nowItem, nowItem.AttackPower, ref Inventory.attackEquip, "공격력");
                    Inventory.CheckTypeEquipment(nowItem, nowItem.Defense, ref Inventory.defenseEquip, "방어력");
                    Inventory.CheckTypeEquipment(nowItem, nowItem.HP, ref Inventory.hpEquip, "체력");
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n");
                }
            }
        }
        // 상점 입력
        public static void StoreInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Village.ShowVillage();
                        break;
                    case 1:
                        Console.Clear();
                        Store.BuyProduct();
                        break;
                    case 2:
                        Console.Clear();
                        Store.SellProduct();
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }
        // 상점 - 아이템 구매 입력
        public static void BuyProductInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Console.Clear();
                    Store.ShowStore();
                    break;
                }
                // 현재 상점에 있는 물품의 숫자를 고른다면
                else if (input <= GameManager.items.Length)
                {
                    // 이미 구매한 아이템이라면
                    if (GameManager.items[input - 1].IsPurchased)
                    {
                        Console.WriteLine("\n이미 구매한 아이템입니다.\n");
                    }
                    // 구매가 가능하다면
                    else
                    {
                        //보유 금액이 충분하다면
                        if (GameManager.user.Gold >= GameManager.items[input - 1].Gold)
                        {
                            Console.Clear();
                            Console.WriteLine("\n구매를 완료했습니다.");
                            // 재화 감소
                            GameManager.user.Gold -= GameManager.items[input - 1].Gold;
                            // 인벤토리에 아이템 추가 
                            Inventory.AddItemInInventory(GameManager.items[input - 1]);
                            // 상점에 구매완료 표시
                            GameManager.items[input - 1].IsPurchased = true;

                            // 아이템 창 띄우기
                            Store.BuyProduct();
                        }
                        // 보유 금액이 부족하다면
                        else
                        {
                            Console.WriteLine("\nGold 가 부족합니다.\n");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"\n 잘못된 입력입니다. 구매할 수 있는 상품의 번호는 1~{GameManager.items.Length} 입니다 \n ");
                }
            }
        }
        // 상점 - 아이템 판매 입력
        public static void sellProductInput()
        {
            // 플레이어가 현재 가지고 있는 아이템 배열 가져오기
            List<Item> items = Inventory.GetInventory();

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Console.Clear();
                    Store.ShowStore();
                    break;
                }
                // 현재 인벤토리에 있는 물품의 숫자를 고른다면
                else if (input <= items.Count)
                {
                    Console.Clear();
                    Console.Write($"{items[input - 1].Name} 을 {(int)(items[input - 1].Gold * 0.85)} G에 판매합니다.\n");
                    GameManager.user.Gold += (int)(items[input - 1].Gold * 0.85);

                    // 판매 후 판매한 아이템 다시 구매할 수 있도록 상점 업데이트
                    foreach (Item i in GameManager.items)
                    {
                        if (i.Name == items[input - 1].Name)
                        {
                            i.IsPurchased = false;
                        }
                    }
                    // 플레이어 인벤토리에서 아이템 판매
                    Inventory.RemoveInventoryItem(items[input - 1]);

                    // 함수 다시 호출
                    Store.SellProduct();
                }
                else
                {
                    Console.WriteLine("\n잘못된 입력입니다.\n");
                }
            }
        }

        // 던전 입장 입력
        public static void DungeonInput()
        {
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 0:
                        Console.Clear();
                        Village.ShowVillage();
                        break;
                    case 1:
                        break;
                    case 2:
                        break; 
                    case 3:
                        break;
                    default:
                        Console.WriteLine("\n잘못된 입력입니다.\n");
                        break;
                }
            }
        }
    }
}