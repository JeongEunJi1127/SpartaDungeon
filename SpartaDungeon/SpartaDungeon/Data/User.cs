using SpartaDungeon.Scene;
using SpartaDungeon.UI;
using System;

public class User
{
    public int Level { get; private set; }
    public int Gold { get;  set; }
    public float AttackPower { get; set; }
    public float Defense { get; set; }
    public float HP { get; set; }

    public string Name { get; private set; }
    public string Job { get; private set; }


    public User(string name, int level, string job, float attackPower, float defense, float hp, int gold)
	{
        Name = name;    
        Level = level;
        Job = job;
        AttackPower = attackPower;
        Defense = defense;
        HP = hp;
        Gold = gold;
    }

    public void LevelUp()
    {
        if(Dungeon.clearCount == Level)
        {
            Dungeon.clearCount = 0;
            Level++;
            SetColorToText.SetColorToSkyBlue($"[레벨업!]");
            Console.Write("현재 플레이어 레벨 : ");
            SetColorToText.SetColorToMagenta($"{Level}\n\n");

            AttackPower += 0.5f;
            Defense ++;
        }
    }

    public bool Die()
    {
        if (HP <= 0) { return true; }
        return false;
    }
}
