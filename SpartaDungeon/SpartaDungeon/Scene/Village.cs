using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Village
    {
        public static void ShowVillage()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");

            InputText.VillageInput();
        }
    }
}
