using System;

[Serializable]
class ConsumableItem : Item
{
    public int Heal { get; set; }
    public ConsumableItem(string name, int heal, int lfI, int pmI, int daI, int deI, 
        int spI, int luI, int rarity)
        : base(name, lfI,pmI, daI, deI, spI, luI, rarity)
    {
        Heal = heal;
    }

    public override bool Use()
    {
        bool used = base.Use();
        if (Oneiric.g.Mcharacter.ActualLife != Oneiric.g.Mcharacter.MaxiumLife)
        {
            Oneiric.g.Mcharacter.Heal(Heal);
            used = true;
        }

        return used;
    }
}
