using System.Collections;

namespace Week10;

public class EventLog : IEnumerable<Event>
{
    private List<Event> _events = new List<Event>();

    public void AddEvent(Event ev)
    {
        _events.Add(ev);
    }

    public IEnumerator<Event> GetEnumerator()
    {
        foreach (var ev in _events)
        {
            yield return ev;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    public IEnumerable<Event> GetByTypeName(string typeName)
    {
        foreach (var ev in _events)
        {
            if (ev.EventType == typeName)
            {
                yield return ev;
            }
        }
    }
}