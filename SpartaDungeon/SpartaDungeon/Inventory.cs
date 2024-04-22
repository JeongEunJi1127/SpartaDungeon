namespace SpartaDungeon
{
    public class Inventory
    {
        // 인벤토리
        public static void ShowInventory()
        {
            Console.WriteLine("\n--------------------------------------------------------------\n");
            Console.WriteLine("인벤토리\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine("1. 장착 관리");
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

