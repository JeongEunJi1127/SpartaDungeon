using System;

public class User
{
    public int Level;
    public int Gold;

    public string Name;
    public string Job;

    public float AttackPower;
    public float Defense;
    public float HP;

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
