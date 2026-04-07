namespace Week10;

public class Event
{
    public int TurnNumber { get; set; }
    public string Description { get; set; }
    public string EventType { get; set; }
    public float StatusChange { get; set; }
    
    public Event(int turn, string desc, string type, float change)
    {
        TurnNumber = turn;
        Description = desc;
        EventType = type;
        StatusChange = change;
    }
    public override string ToString()
    {
        return $"Хід {TurnNumber}, {EventType}: {Description} , Зміна: {StatusChange}";
    }
}