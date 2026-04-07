using System.Linq;
using Week10;

class Program
{
    static void Main()
    {

        Party party = new Party();
        party.AddMember(new Character("Barbie Malibu", "Mage", 18, 95, 1000, "Active"));
        party.AddMember(new Character("Bratz Jade", "Ranger", 15, 120, 450, "Active"));
        party.AddMember(new Character("Monster High Draculaura", "Vampire", 14, 40, 200, "Wounded"));
        party.AddMember(new Character("Bratz Sasha", "Archer", 10, 100, 320, "Active"));


        EventLog log = new EventLog();
        log.AddEvent(new Event(1, "Шоппінг", "Loot", 500));
        log.AddEvent(new Event(2, "Зламався каблук", "Battle", -50));
        log.AddEvent(new Event(3, "Нова колекція", "Loot", 1000));

        while (true)
        {
            Console.WriteLine("\nаналіз");
            Console.WriteLine("1 - Преміум-сегмент (Top Gold)");
            Console.WriteLine("2 - Терміновий рестайлінг (HP < 50)");
            Console.WriteLine("3 - Статистика (Середній чек та Ікона стилю)");
            Console.WriteLine("4 - Групування за станом");
            Console.WriteLine("5 - Останні події (Loot)");
            Console.WriteLine("6 - Повна хронологія подій");
            Console.WriteLine("7 - Фільтрація за рівнем (FilterLevel)");
            Console.WriteLine("8 - Список лише імен (SelectNames)");
            Console.WriteLine("9 - Найбагатша лялька (MaxCountOgGold)");
            Console.WriteLine("10 - Критична відсутність стилю (HP < 10)");
            Console.WriteLine("0 - Вихід");

            Console.Write("\nТвій вибір: ");

            string input = Console.ReadLine();

            if (input == "0") break;

            if (input == "1")
            {
                var topTier = party
                    .Where(h => { return h.Level >= 12; })
                    .OrderByDescending(h => { return h.Gold; });

                Console.WriteLine("\nПреміум-сегмент (Top Gold):");
                foreach (var h in topTier)
                {
                    Console.WriteLine($"{h.Name}, бюджет: {h.Gold}");
                }

            }

            if (input == "2")
            {
                Console.WriteLine("\nТерміновий рестайлінг (HP < 50):");
                foreach (var d in party.GetWounded(50))
                    Console.WriteLine($"{d.Name}, points: {d.HP}");
            }

            if (input == "3")
            {
                var avgBudget = party.Average(c => { return c.Gold; });
                var icon = party.OrderByDescending(c => { return c.Level; }).First();

                Console.WriteLine($"\nСередній чек: {avgBudget:F2}");
                Console.WriteLine($"Ікона стилю: {icon.Name} ({icon.Level} lvl)");
            }

            if (input == "4")
            {
                Console.WriteLine("\nСтатистика за станом:");
                var statusGroups = party.GroupBy(c => { return c.Status; });
                foreach (var group in statusGroups)
                {
                    Console.WriteLine($"{group.Key}: {group.Count()} шт.");
                }
            }

            if (input == "5")
            {
                Console.WriteLine("\nОстанні події (Loot):");
                foreach (var ev in log.GetByTypeName("Loot"))
                {
                    Console.WriteLine(ev.ToString());
                }
            }
            
            if (input == "6")
            {
                Console.WriteLine("\nПовна хронологія подій:");
                foreach (var ev in log.GetChronology())
                {
                    Console.WriteLine(ev.ToString());
                }
            }
            if (input == "7")
            {
                Console.Write("Введіть мінімальний рівень: ");
                if (int.TryParse(Console.ReadLine(), out int lvl))
                {
                    Console.WriteLine($"\nЛяльки вище {lvl} рівня:");
                    foreach (var p in party.FilterLevel(lvl)) Console.WriteLine(p);
                }
            }

            if (input == "8")
            {
                Console.WriteLine("\nІмена всіх учасниць:");
                var names = party.SelectNames();
                Console.WriteLine(string.Join(", ", names));
            }

            if (input == "9")
            {
                float maxGold = party.MaxCountOgGold();
                Console.WriteLine($"\nМаксимальний бюджет: {maxGold}");
            }

            if (input == "10")
            {
                int injuredCount = party.CountByInjured();
                Console.WriteLine($"\nКількість ляльок у критичному стані (HP < 10): {injuredCount}");
            }
        }
        
        Console.WriteLine("\nАктивні ляльки:");
        foreach (var active in party.GetActiveOnly())
        {
            Console.WriteLine($"{active.Name}");
        }
    
    }
}