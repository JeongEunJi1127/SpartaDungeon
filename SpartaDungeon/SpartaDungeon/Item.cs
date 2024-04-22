using System;

public class Item
{
    public string Name;
    public string Description;

    public int AttackPower;
    public int Defense;
    public int HP;

    public int Gold;
    public Item(string name, string description, int attackPower, int defense, int hp, int gold)
	{
		Name = name;
        Description = description;
        AttackPower = attackPower;  
        Defense = defense;
        HP = hp;
        Gold = gold;
	}
}
