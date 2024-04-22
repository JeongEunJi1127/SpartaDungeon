namespace SpartaDungeon
{
    internal class Program
    {
        // 초기 사용자 정보 초기화
        static User user = new User("정은지", 1, "전사", 10, 5, 100, 1500);
        // 상점 아이템 배열 선언
        static Item[] items = new Item[] 
        {
            new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 0, 5, 0, 1000,false),
            new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, 0, 2000,false),
            new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 0, 3500,false),
            new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 2, 0, 0, 600,false),
            new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 5, 0, 0, 1500,false),
            new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 7, 0, 0, 2700,false)
        };
        // 사용자의 아이템 배열 선언
        static Item[] userItems = new Item[] {};
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
                if (input == 1)  { ViewStatus();  break; }
                // 인벤토리
                else if (input == 2)  { Inventory();  break;  }
                // 상점
                else if (input == 3) { Store(); break;  }
                else  { Console.WriteLine("잘못된 입력입니다.");  }
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
                if (input == 0)   { Village();  break; }
                else  { Console.WriteLine("잘못된 입력입니다.");   }
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
                if (input == 0) { Village(); break;  }
                // 장착 관리
                else if (input == 1) { break;}
                else  {  Console.WriteLine("잘못된 입력입니다.");  }
            }
        }

        // 상점
        public static void Store()
        {
            Console.WriteLine("[보유 골드]\n" + user.Gold  + " G\n");
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
                if (input == 0)  { Village(); break;   }
                // 아이템 구매
                else if (input == 1) { BuyProduct(); break; }
                else  { Console.WriteLine("잘못된 입력입니다."); }
            }
        }

        // 상점 물품 보여주는 함수
        public static void ShowStoreProduct(bool showNum)
        {
            // items에 있는 아이템 목록 
            for (int i = 0; i < items.Length; i++)
            {
                // 아이템의 속성 값이 0 이 아닌 것 모두 뽑기
                List<string> itemProperty = new List<string>();
                if (items[i].AttackPower != 0) { itemProperty.Add(("공격력 +"+ items[i].AttackPower)); }
                else if (items[i].Defense != 0) { itemProperty.Add(("방어력 +" + items[i].Defense)); }
                else if (items[i].HP != 0) { itemProperty.Add(("체력 +" + items[i].HP)); }

                // 아이템이 구매 완료 되었는지 확인
                string purchased;
                if (items[i].IsPurchased) { purchased = "구매완료"; }
                // 구매되지 않았다면 현재 가지고 있는 골드 양 나타내기
                else { purchased = items[i].Gold.ToString() + " G"; }

                // 출력
                // 아이템 구매 창 -> 숫자를 나타내야 할 때
                if (showNum) { Console.Write("- " + (i+1) + " " + items[i].Name + "  |  "); }
                // 그냥 상점 창일 때
                else { Console.Write("- " + items[i].Name + "  |  "); }
                // 아이템 속성 
                foreach (string property in itemProperty) { Console.Write(property); }
                // 아이템 설명 + 골드나 구매완료 
                Console.Write( "  |  " + items[i].Description + "  |  " + purchased + "\n");
            }
            Console.WriteLine();
        }

        // 아이템 구매 
        public static void BuyProduct()
        {
            Console.WriteLine("[보유 골드]\n" + user.Gold + " G\n");
            Console.WriteLine("[아이템 목록]\n");
            // 현재 상점 물품 보여주기
            ShowStoreProduct(true);
            Console.WriteLine("0. 나가기\n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int input = int.Parse(Console.ReadLine());

                // 나가기
                if (input == 0){  Store(); break; }
                else { Console.WriteLine("잘못된 입력입니다.");  }
            }
        }
    }
}
