using System.Collections;

namespace Week10;

public class Party : IEnumerable<Character>
{
    private List<Character> _members = new List<Character>();
    
    public void AddMember(Character c)
    {
        if (c != null)
        {
            _members.Add(c);
        }
    }
    
    public IEnumerator<Character> GetEnumerator()
    {
        foreach (var hero in _members)
        {
            yield return hero; 
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<Character> GetActiveOnly()
    {
        foreach (var hero in _members)
        {
            if (hero.Status == "Active")
            {
                yield return hero;
            }
        }
    }
    
    public IEnumerable<Character> GetWounded(float threshold)
    {
        foreach (var m in _members)
        {
            if (m.HP < threshold) yield return m;
        }
    }
}
