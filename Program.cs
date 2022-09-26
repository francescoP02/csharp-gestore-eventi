// See https://aka.ms/new-console-template for more information

using System;

List<Event> events = new List<Event>();

string userInput;

do
{
    Console.WriteLine("****Welcome****");

    Console.WriteLine("Insert 'add' for add a event");
    Console.WriteLine("Insert 'manage booking' for manage booking of an event");
    Console.WriteLine("Insert 'stop' for terminate the process");
    userInput = Console.ReadLine();

    if (userInput == "add")
    {
        try
        {
            Console.WriteLine(Environment.NewLine);
            addEvent();
        }
        catch (Exception e)
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    else if (userInput == "manage booking")
    {
        Console.WriteLine("****Enter event's name****");

        string eventTitle = Console.ReadLine();

        bool found = false;

        foreach (Event singleEvent in events)
        {
            if (singleEvent.Title == eventTitle)
            {
                found = true;
                string input;
                do
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Insert 'book seats' for add a event");
                    Console.WriteLine("Insert 'cancel seats' for modify user data");
                    Console.WriteLine("Insert 'end' for terminate the process");
                    input = Console.ReadLine();

                    if (input == "book seats")
                    {
                        try
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("****How many seats do you want to book?****");
                            int numberSeats = Convert.ToInt32(Console.ReadLine());
                            singleEvent.PrenotaPosti(numberSeats);
                            Console.WriteLine($"Remaining places: {singleEvent.GetAvailableSeats()}");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }
                    if (input == "cancel seats")
                    {
                        try
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine("****How many places do you want to cancel?****");
                            int numberSeats = Convert.ToInt32(Console.ReadLine());
                            singleEvent.DisdiciPosti(numberSeats);
                            Console.WriteLine($"Remaining places: {singleEvent.GetAvailableSeats()}");
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(Environment.NewLine);
                            Console.WriteLine($"Error: {e.Message}");
                        }
                    }

                } while (input != "end");
            }
        }

        if (found == false)
        {
            Console.WriteLine("Event not found");
        }
    }

} while (userInput != "stop");

foreach (Event singleEvent in events)
{
    Console.WriteLine(singleEvent.ToString());
}



void addEvent()
{
    Console.WriteLine("****Insert event's name: ****");
    string eventTitle = Console.ReadLine();

    Console.WriteLine("****Insert event's date (gg/mm/yyy): ****");
    DateTime eventDate = System.DateTime.Parse(Console.ReadLine());

    Console.WriteLine("****Insert max occupancy: ****");
    int totalSeats = Int32.Parse(Console.ReadLine());


    Event evento = new Event(eventTitle, eventDate, totalSeats);
    events.Add(evento);
    Console.WriteLine(evento.ToString());
}
