// See https://aka.ms/new-console-template for more information

public class ProgramEvents
{
    public string Title { get; set; }
    public List<Event> Events { get; private set; }

    public ProgramEvents(string title)
    {
        Title = title;
        Events = new List<Event>();
    }

    public void AddEvent(Event tempEvent)
    {
        Events.Add(tempEvent);
    }

    public static string GetEventsList(List<Event> list)
    {
        string events = "";
        if (list.Count >= 0)
        {
            events += "****Ecco tutti gli eventi: ****\n";
            int count = 0;
            foreach (Event e in list)
            {
                ++count;
                events += $"Event n.{count}: {e.ToString()}; \n";
            }
        }
        else
        {
            events = "Nessun evento programmato";
        }
        return events;

    }

}
