using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Dungeon
    {
        public static void ShowDungeon()
        {
            Console.WriteLine("던전입장\n");
            Console.WriteLine("1. 쉬운 던전     |   방어력 5 이상 권장");
            Console.WriteLine("2. 일반 던전     |   방어력 11 이상 권장");
            Console.WriteLine("3. 어려운 던전   |   방어력 17 이상 권장");
            Console.WriteLine("0. 나가기\n");

            InputText.DungeonInput();
        }
    }
}
