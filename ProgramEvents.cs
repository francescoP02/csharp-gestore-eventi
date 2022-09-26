// See https://aka.ms/new-console-template for more information

public class ProgramEvents
{
    public string Title { get; set; }
    public List<Event> Events { get; set; }

    public ProgramEvents(string title)
    {
        Title = title;
        Events = new List<Event>();
    }

    //string ShowProgramEvents()
    //{
    //    Console.WriteLine("Inserire il titolo del programma eventi: ");
    //    string titolo = Console.ReadLine();

    //    string program = "Nome programma eventi" + Title;
    //    foreach (Event evento in Events)
    //    {
    //        program += evento.ToString();
    //    }
    //    return program;
    //}

}
