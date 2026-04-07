namespace Week10;

public class Character
{
    public string Name { get; set; }
    public string CharacterClass { get; set; } 
    public int Level { get; set; }
    public float HP { get; set; }
    public float Gold { get; set; }
    public string Status { get; set; }

    public Character(string name, string role, int level, float hp, float gold, string status)
    {
        Name = name;
        CharacterClass = role;
        Level = level;
        HP = hp;
        Gold = gold;
        Status = status;
    }

    public override string ToString()
    {
        string info = $"{Name}, Клас: {CharacterClass}, Рівень: {Level}, HP: {HP}, Золото: {Gold}, Стан: {Status}";
        return info;
    }
}