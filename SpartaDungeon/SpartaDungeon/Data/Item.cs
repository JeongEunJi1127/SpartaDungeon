using System;

public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public int AttackPower { get; private set; }
    public int Defense { get; private set; } 
    public int HP { get; private set; }
    public int Gold { get; private set; }

    public bool IsPurchased { get;  set; }
    public bool IsEquipped { get; set; }
    public Item(string name, string description, int attackPower, int defense, int hp, int gold, bool isPurchased, bool isEquipped)
	{
		Name = name;
        Description = description;
        AttackPower = attackPower;  
        Defense = defense;
        HP = hp;
        Gold = gold;
        IsPurchased = isPurchased;
        IsEquipped = isEquipped;
    }
}
