using System.Linq;
using Week10;

class Program
{
    static void Main()
    {
        
        Party party = new Party();
        party.AddMember(new Character("Barbie Malibu", "Mage", 18, 95, 1000, "Active"));
        party.AddMember(new Character("Bratz Jade", "Ranger", 15, 120, 450, "Active"));
        party.AddMember(new Character("Monster High Draculaura", "Vampire", 14, 80, 200, "Wounded"));
        party.AddMember(new Character("Bratz Sasha", "Archer", 14, 100, 320, "Active"));

        
        EventLog log = new EventLog();
        log.AddEvent(new Event(1, "Шоппінг", "Loot", 500));
        log.AddEvent(new Event(2, "Зламався каблук", "Battle", -50));
        log.AddEvent(new Event(3, "Нова колекція", "Loot", 1000));
        
        Console.WriteLine("аналіз");
        
        Console.WriteLine("\nАктивні ляльки:");
        foreach (var active in party.GetActiveOnly())
        {
            Console.WriteLine($"{active.Name}");
        }

        var topTier = party
            .Where(h =>
            {
                return h.Level >= 12;
            })
            .OrderByDescending(h =>
            {
                return h.Gold;
            });

        Console.WriteLine("\nПреміум-сегмент (Top Gold):");
        foreach (var h in topTier) 
            Console.WriteLine($"{h.Name}, бюджет: {h.Gold}");
        
        
        Console.WriteLine("\nТерміновий рестайлінг (HP < 50):");
        foreach (var d in party.GetWounded(50))
            Console.WriteLine($"{d.Name}, points: {d.HP}");
        
        
        var avgBudget = party.Average(c =>
        {
            return c.Gold;
        });
        var icon = party.OrderByDescending(c =>
        {
            return c.Level;
        }).First();

        Console.WriteLine($"\nСередній чек: {avgBudget:F2}");
        Console.WriteLine($"Ікона стилю: {icon.Name} ({icon.Level} lvl)");
        
        
        Console.WriteLine("\nСтатистика за станом:");
        var status = party.GroupBy(c =>
        {
            return c.Status;
        });
        foreach (var group in status)
        {
            Console.WriteLine($"{group.Key}: {group.Count()} шт.");
        }
        Console.WriteLine("\nОстанні події  (Loot)");
        foreach (var ev in log.GetByTypeName("Loot"))
        {
            Console.WriteLine(ev.ToString());
        }
    
    }
}