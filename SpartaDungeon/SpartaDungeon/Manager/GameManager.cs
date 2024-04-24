using SpartaDungeon.Data;
using SpartaDungeon.Scene;

namespace SpartaDungeon.Manager
{
    internal class GameManager
    {
        // 초기 사용자 정보 초기화
        public static User user = new User("정은지", 1, "전사", 10, 5, 100, 7000);
        // 상점 아이템 배열 선언
        public static Item[] items = new Item[]
        {
            new Item("수련자 갑옷", "수련에 도움을 주는 갑옷입니다.                  ", 0, 5, 0, 1000,false,false),
            new Item("무쇠갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.              ", 0, 9, 0, 2000,false,false),
            new Item("스파르타의 갑옷 ", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 15, 0, 3500,false,false),
            new Item("낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.                 ", 2, 0, 0, 600, false,false),
            new Item("청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.            ", 5, 0, 0, 1500,false,false),
            new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다. ", 7, 0, 0, 2700,false,false),
            new Item("얇은 천 ", "손목에 두르는 붕대입니다.                         ", 0, 0, 3, 1200,false,false),
            new Item("철 허리 보호대", "허리를 튼튼하게 보호해줄 것 같습니다.             ", 0, 0, 9, 4000,false,false)
        };

        // 던전 레벨 배열 선언
        public static DungeonLevel[] dungeonLevels = new DungeonLevel[]
        {
            new DungeonLevel(1, 5, 1000 ),
            new DungeonLevel(2, 11, 1700),
            new DungeonLevel(3, 17,2500),
        };

        static void Main(string[] args)
        {
            Village.ShowVillage();
        }
    }
}
