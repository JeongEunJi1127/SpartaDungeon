using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Inventory
    {
        // 사용자의 아이템 리스트 선언 (가변적이어야 하므로 리스트 사용)
        private static List<Item> InventoryItems = new List<Item>();

        public static bool attackEquip = false;
        public static bool defenseEquip = false;
        public static bool hpEquip = false;

        public static void ShowInventory()
        {
            Console.WriteLine("인벤토리\n");
            Console.WriteLine("[아이템 목록]\n");

            ShowInventoryItem(false);

            Console.WriteLine("\n1. 장착 관리");
            Console.WriteLine("0. 나가기\n");

            InputText.InventoryInput();
        }

        // 장착 관리
        public static void ManageEquipment()
        {
            Console.WriteLine("인벤토리 - 장착관리\n");
            Console.WriteLine("[아이템 목록]\n");

            ShowInventoryItem(false);
            Console.WriteLine("\n0. 나가기\n");

            InputText.ManageEquipmentInput();
        }
        public static void ShowInventoryItem(bool showGold)
        {
            // 인벤토리에 아이템이 없으면
            if (InventoryItems.Count == 0) { Console.WriteLine("인벤토리에 아이템이 없습니다. \n"); }
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                // 아이템의 속성 값이 0 이 아닌 것 뽑기
                string itemProperty = "";
                if (InventoryItems[i].AttackPower != 0)
                {
                    itemProperty = $"공격력 +{InventoryItems[i].AttackPower}";
                }
                else if (InventoryItems[i].Defense != 0)
                {
                    itemProperty = $"방어력 +{InventoryItems[i].Defense} ";
                }
                else if (InventoryItems[i].HP != 0)
                {
                    itemProperty = $"체력 +{InventoryItems[i].HP}";
                }

                Console.Write($" -  {i + 1} ");
                // 장착 중인 아이템 앞에는 [E] 표시
                if (InventoryItems[i].IsEquipped)
                {
                    Console.Write("[E] ");
                }
                Console.Write($"{InventoryItems[i].Name}  |   ");
                // 아이템 속성 
                Console.Write($"{itemProperty}  |   ");

                // store 스크립트에서 아이템 판매 시 보여주는 화면일 때 골드도 보여주기
                if (showGold)
                {
                    Console.WriteLine($"{InventoryItems[i].Description}  |  {InventoryItems[i].Gold}G");
                }
                else { Console.WriteLine(InventoryItems[i].Description); }
            }
        }

        // 장비가 장착되어있는지 아닌지 확인하는 메서드
        public static void CheckTypeEquipment(Item item, int property, ref bool b, string str)
        {
            // 속성값이 존재할 때
            if (property != 0)
            {
                // 아이템이 장착되어 있지 않고
                if (!item.IsEquipped)
                {
                    // 속성 장비가 이미 장착되어 있으면
                    if (b)
                    {
                        Console.WriteLine($"\n{str} 장비는 이미 장착되어 있습니다.\n");
                        Console.WriteLine("다른 장비를 선택해주세요.\n");
                        ManageEquipment();
                    }
                    // 속성 장비가 장착되어 있지 않으면
                    else
                    {
                        Console.WriteLine($"\n{str} 장비를 장착합니다.\n");
                        item.IsEquipped = true;
                        b = true;
                        ManageEquipment();
                    }
                }
                // 아이템이 장착되어 있다면 장착 해제
                else
                {
                    Console.WriteLine($"\n{str} 장비의 장착을 해제합니다.\n");
                    item.IsEquipped = false;
                    b = false;
                    ManageEquipment();
                }
            }
        }

        // 인벤토리 아이템 추가 메서드
        public static void AddItemInInventory(Item item)
        {
            InventoryItems.Add(item);
        }

        // 인벤토리 아이템 get 메서드
        public static List<Item> GetInventory()
        {
            return InventoryItems;
        }

        // 인벤토리 아이템 제거 메서드
        public static void RemoveInventoryItem(Item item)
        {
            InventoryItems.Remove(item);
        }
    }
}

