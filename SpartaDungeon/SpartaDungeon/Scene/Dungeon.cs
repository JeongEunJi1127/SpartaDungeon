using SpartaDungeon.Data;
using SpartaDungeon.Manager;
using SpartaDungeon.UI;

namespace SpartaDungeon.Scene
{
    public class Dungeon
    {
        public static void ShowDungeon()
        {
            SetColorToText.SetColorToYellow("던전입장\n");

            SetColorToText.SetColorToMagenta("1");
            Console.Write(". 쉬운 던전     |   방어력 ");
            SetColorToText.SetColorToMagenta($"{GameManager.dungeonLevels[0].RecommendedDefense}");
            Console.Write(" 이상 권장\n");

            SetColorToText.SetColorToMagenta("2");
            Console.Write(". 일반 던전     |   방어력 ");
            SetColorToText.SetColorToMagenta($"{GameManager.dungeonLevels[1].RecommendedDefense}");
            Console.Write(" 이상 권장\n");

            SetColorToText.SetColorToMagenta("3");
            Console.Write(". 어려운 던전     |   방어력 ");
            SetColorToText.SetColorToMagenta($"{GameManager.dungeonLevels[2].RecommendedDefense}");
            Console.Write(" 이상 권장\n");

            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.DungeonInput();
        }

        public static void ExploreDungeon(DungeonLevel dungeonLevel)
        {
            float playerDefense = GameManager.user.Defense;
            float playerHp = GameManager.user.HP;
            float playerGold = GameManager.user.Gold;

            Random random = new Random();
            int losePercentage = random.Next(0, 10);
            //(권장 방어력 - 내 방어력) 만큼 랜덤 값에 설정
            int lossHp = random.Next(20 + (int)dungeonLevel.RecommendedDefense - (int)playerDefense, 36 + (int)dungeonLevel.RecommendedDefense - (int)playerDefense);
            int plusGold = random.Next((int)GameManager.user.AttackPower, (int)GameManager.user.AttackPower*2 + 1);

            //권장 방어력보다 낮고 40% 확률에 걸리면 던전 실패 - 보상 없고 체력 감소 절반
            if (playerDefense < dungeonLevel.RecommendedDefense && losePercentage <= 3)
            {
                // 플레이어 hp가 1보다 작으면 감소할 체력이 없으므로 죽는다
                if(playerHp < 1)
                {
                    SetColorToText.SetColorToRed("당신은 전투 과정에서 죽었습니다...\n");
                    Console.Write($"체력 {playerHp} -> ");
                    SetColorToText.SetColorToMagenta("0\n\n");
                }
                else
                {
                    GameManager.user.HP = playerHp / 2;

                    FailDungeon(playerHp);
                }
            }
            // 권장 방어력 보다 높다면 던전 클리어
            else
            {
                // 기본 체력 감소량
                GameManager.user.HP -= lossHp;
                if (GameManager.user.Die())
                {
                    SetColorToText.SetColorToRed("당신은 전투 과정에서 죽었습니다...\n");
                    Console.Write($"체력 {playerHp} -> ");
                    SetColorToText.SetColorToMagenta("0\n\n");

                    SetColorToText.SetColorToMagenta("0");
                    Console.Write(". 게임 다시 시작하기\n\n");

                    SetColorToText.SetColorToSkyBlue("리셋중 ..\n");
                    FileManager.ResetData();
                    Thread.Sleep(600);
                    SetColorToText.SetColorToSkyBlue("3\n");
                    Thread.Sleep(600);
                    SetColorToText.SetColorToSkyBlue("2\n");
                    Thread.Sleep(600);
                    SetColorToText.SetColorToSkyBlue("1\n");
                    Thread.Sleep(600);
                    SetColorToText.SetColorToSkyBlue("리셋 완료!\n");
                }
                else
                {
                    // 기본 클리어 보상 * 공격력으로 인한 추가 보상 확률
                    GameManager.user.Gold += (int)(dungeonLevel.Reward * (1+plusGold / 100.0));

                    ClearDungeon(playerHp, playerGold);
                }
            }
        }

        // 던전 클리어시 호출
        public static void ClearDungeon(float prevHp, float prevGold)
        {
            GameManager.user.ClearCount++;
            GameManager.user.LevelUp();

            SetColorToText.SetColorToSkyBlue("[던전 클리어]\n");
            Console.WriteLine("축하합니다!!\r\n던전을 클리어 하였습니다.\n");
            SetColorToText.SetColorToYellow("[탐험 결과]\n");
            Console.WriteLine($"체력 {prevHp} -> {GameManager.user.HP}");
            Console.WriteLine($"Gold {prevGold} -> {GameManager.user.Gold}\n");
            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.BackToDungeonInput();
        }
        // 던전 실패시 호출
        public static void FailDungeon(float prevHp)
        {
            SetColorToText.SetColorToRed("[던전 실패]\n");
            Console.WriteLine("던전 정복에 실패했습니다.");
            Console.WriteLine("플레이어의 체력이 절반으로 감소합니다.\n");

            SetColorToText.SetColorToYellow("[탐험 결과]\n");
            Console.Write($"체력 {prevHp} -> "); 
            SetColorToText.SetColorToMagenta($"{GameManager.user.HP}\n\n");

            SetColorToText.SetColorToMagenta("0");
            Console.Write(". 나가기\n\n");

            InputText.BackToDungeonInput();
        }
    }
}
