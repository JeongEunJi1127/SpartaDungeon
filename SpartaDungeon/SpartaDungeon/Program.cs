namespace SpartaDungeon
{
    internal class Program
    {
        static User user = new User("정은지", 1, "전사", 10, 5, 100, 1500);
        static void Main(string[] args)
        {
            Village();
        }

        // 시작 마을
        public static void Village()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");
           
            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());
                // 상태창 보기
                if (input == 1)
                {
                    ViewStatus();
                    break;
                }
                // 인벤토리
                else if (input == 2)
                {
                    Inventory();
                    break;
                }
                // 상점
                else if (input == 3)
                {
                    Store();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        // 상태창
        public static void ViewStatus()
        {
            Console.WriteLine("LV. " + user.Level);
            Console.WriteLine("Chad ( " + user.Job+ " )");
            Console.WriteLine("공격력 : " + user.AttackPower);
            Console.WriteLine("방어력 : " + user.Defense);
            Console.WriteLine("체 력 : " + user.HP);
            Console.WriteLine("Gold : " + user.Gold + " G\n");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Village();
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

        // 인벤토리
        public static void Inventory()
        {
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
                    Village();
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

        // 상점
        public static void Store()
        {
            Console.WriteLine("[보유 골드]\n" + user.Gold  + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0)
                {
                    Village();
                    break;
                }
                // 아이템 구매
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
