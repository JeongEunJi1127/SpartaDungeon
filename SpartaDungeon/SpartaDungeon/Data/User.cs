using System;

public class User
{
    public int Level { get; private set; }
    public int Gold { get;  set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public int HP { get; set; }

    public string Name { get; private set; }
    public string Job { get; private set; }


    public User(string name, int level, string job, int attackPower, int defense, int hp, int gold)
	{
        Name = name;    
        Level = level;
        Job = job;
        AttackPower = attackPower;
        Defense = defense;
        HP = hp;
        Gold = gold;
    }
}
