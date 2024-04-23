namespace SpartaDungeon
{
    public class Inventory
    {
        // 사용자의 아이템 리스트 선언 (가변적이어야 하므로 리스트 사용)
        private static List<Item> InventoryItems = new List<Item>();

        // 인벤토리
        public static void ShowInventory()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("인벤토리\n");
            Console.WriteLine("[아이템 목록]\n");

            ShowInventoryItem(false);

            Console.WriteLine("\n1. 장착 관리");
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
                // 장착 관리
                else if (input == 1)
                {
                    ManageEquipment();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        public static void AddItemInInventory(Item item)
        {
            InventoryItems.Add(item);
        }

        public static List<Item> GetInventory()
        {
            return InventoryItems;
        }

        public static void RemoveInventoryItem(Item item)
        {
            InventoryItems.Remove(item);
        }

        public static void ShowInventoryItem(bool showGold)
        {
            // 인벤토리에 아이템이 없으면
            if (InventoryItems.Count == 0) { Console.WriteLine("인벤토리에 아이템이 없습니다. \n"); }
            for (int i = 0; i < InventoryItems.Count; i++)
            {
                // 아이템의 속성 값이 0 이 아닌 것 모두 뽑기
                List<string> itemProperty = new List<string>();
                if (InventoryItems[i].AttackPower != 0) { itemProperty.Add(("공격력 +" + InventoryItems[i].AttackPower) + " "); }
                if (InventoryItems[i].Defense != 0) { itemProperty.Add(("방어력 +" + InventoryItems[i].Defense) + " "); }
                if (InventoryItems[i].HP != 0) { itemProperty.Add(("체력 +" + InventoryItems[i].HP) + " "); }

                Console.Write( " - " + (i+1) + " ");
                // 장착 중인 아이템 앞에는 [E] 표시
                if (InventoryItems[i].IsEquipped)
                {
                    Console.Write("[E] ");
                }
                Console.Write(InventoryItems[i].Name + "  |   ");
                // 아이템 속성 
                foreach (string property in itemProperty) { Console.Write(property + "  |   "); }

                // store 스크립트에서 아이템 판매 시 보여주는 화면일 때 골드도 보여주기
                if (showGold)
                {
                    Console.WriteLine(InventoryItems[i].Description +" | " + InventoryItems[i].Gold + "G");
                }
                else { Console.WriteLine(InventoryItems[i].Description); }
            }
        }

        public static void ManageEquipment()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("인벤토리 - 장착관리\n");
            Console.WriteLine("[아이템 목록]\n");

            ShowInventoryItem(false);
            Console.WriteLine("\n0. 나가기\n");

            while (true)
            {
                Console.WriteLine("장착하고 싶거나 장착 해제하고 싶은 장비의 번호를 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    ShowInventory();
                    break;
                }
                // 현재 인벤토리에 있는 물품의 숫자를 고른다면
                else if (input <= InventoryItems.Count)
                {
                    if (InventoryItems[input - 1].IsEquipped) 
                    {
                        Console.WriteLine("장비의 장착을 해제합니다.");
                        InventoryItems[input-1].IsEquipped = false;
                        ManageEquipment();
                    }
                    else
                    {
                        Console.WriteLine("장비를 장착합니다.");
                        InventoryItems[input - 1].IsEquipped = true;
                        ManageEquipment();
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}

