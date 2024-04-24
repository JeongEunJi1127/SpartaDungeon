using SpartaDungeon.Data;
using SpartaDungeon.Manager;
using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Dungeon
    {
        public static int clearCount = 0;
        public static void ShowDungeon()
        {
            Console.WriteLine("던전입장");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine($"1. 쉬운 던전     |   방어력 {GameManager.dungeonLevels[0].Defense} 이상 권장");
            Console.WriteLine($"2. 일반 던전     |   방어력 {GameManager.dungeonLevels[1].Defense} 이상 권장");
            Console.WriteLine($"3. 어려운 던전   |   방어력 {GameManager.dungeonLevels[2].Defense} 이상 권장");
            Console.WriteLine("0. 나가기\n");

            InputText.DungeonInput();
        }

        public static void ExploreDungeon(DungeonLevel dungeonLevel)
        {
            int playerDefense = GameManager.user.Defense;
            int playerHp = GameManager.user.HP;
            int playerGold = GameManager.user.Gold;

            Random random = new Random();
            int percentage = random.Next(0, 10);
            //(권장 방어력 - 내 방어력) 만큼 랜덤 값에 설정
            int lossHp = random.Next(20+dungeonLevel.RecommendedDefense-playerDefense , 36 + dungeonLevel.RecommendedDefense - playerDefense);
            int plusGold = random.Next(GameManager.user.AttackPower, GameManager.user.AttackPower*2 + 1);

            //권장 방어력보다 낮고 40% 확률에 걸리면 던전 실패 - 보상 없고 체력 감소 절반
            if (playerDefense < dungeonLevel.RecommendedDefense && percentage <= 3)
            {
                GameManager.user.HP = playerHp / 2;

                FailDungeon(playerHp); 
            }
            // 권장 방어력 보다 높다면 던전 클리어
            else
            {
                // 기본 체력 감소량
                GameManager.user.HP -= lossHp;
                // 기본 클리어 보상 * 공격력으로 인한 추가 보상 확률
                GameManager.user.Gold += (int)(dungeonLevel.Reward * (plusGold / 100.0));

                ClearDungeon(playerHp, playerGold);
            }
        }

        // 던전 클리어시 호출
        public static void ClearDungeon(int prevHp, int prevGold)
        {
            clearCount++;

            Console.WriteLine("던전 클리어");
            Console.WriteLine("축하합니다!!\r\n 던전을 클리어 하였습니다.\n");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {prevHp} -> {GameManager.user.HP}");
            Console.WriteLine($"Gold {prevGold} -> {GameManager.user.Gold}\n");
            Console.WriteLine("0. 나가기\n");

            InputText.BackToDungeonInput();
        }
        // 던전 실패시 호출
        public static void FailDungeon(int prevHp)
        {
            Console.WriteLine("던전 실패");
            Console.WriteLine("던전 정복에 실패했습니다\r\n플레이어의 체력이 절반으로 감소합니다.\n");
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"체력 {prevHp} -> {GameManager.user.HP}");
            Console.WriteLine("0. 나가기\n");

            InputText.BackToDungeonInput();
        }
    }
}
