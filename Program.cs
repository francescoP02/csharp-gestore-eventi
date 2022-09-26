// See https://aka.ms/new-console-template for more information

using System;

List<Event> events = new List<Event>();

string userInput;

Console.WriteLine("****Welcome****");

do
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine("Insert 'event' for add a single event");
    Console.WriteLine("Insert 'program' for add a program of events");
    Console.WriteLine("Insert 'booking' for manage booking of an event");
    Console.WriteLine("Insert 'search' for search event by date");
    Console.WriteLine("Insert 'empty' for delete all events");
    Console.WriteLine("Insert 'stop' for terminate the process");
    Console.WriteLine(Environment.NewLine);
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "event":
            try
            {
                Console.Clear();
                Console.WriteLine(Environment.NewLine);
                addEvent();
            }
            catch (Exception e)
            {
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine($"Error: {e.Message}");
            }
            break;

        case "program":
            
            Console.Clear();
            CreaProgrammaEventi();
            
            break;

        case "booking":
            Console.Clear();

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
                        Console.WriteLine("Insert 'book' for booking seats");
                        Console.WriteLine("Insert 'cancel' for cancel booked seats");
                        Console.WriteLine("Insert 'end' for terminate the process");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "book":
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine(Environment.NewLine);
                                    Console.WriteLine("****How many seats do you want to book?****");
                                    int numberSeats = Convert.ToInt32(Console.ReadLine());
                                    singleEvent.PrenotaPosti(numberSeats);
                                    Console.WriteLine($"****Remaining places: {singleEvent.GetAvailableSeats()}****");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(Environment.NewLine);
                                    Console.WriteLine($"****Error: {e.Message}****");
                                }
                                break;

                            case "cancel":
                                try
                                {
                                    Console.Clear();
                                    Console.WriteLine(Environment.NewLine);
                                    Console.WriteLine("****How many places do you want to cancel?****");
                                    int numberSeats = Convert.ToInt32(Console.ReadLine());
                                    singleEvent.DisdiciPosti(numberSeats);
                                    Console.WriteLine($"Remaining places: {singleEvent.GetAvailableSeats()}");
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(Environment.NewLine);
                                    Console.WriteLine($"****Error: {e.Message}****");
                                }
                                break;
                        }

                    } while (input != "end");
                }
            }

            if (found == false)
            {
                Console.WriteLine("Event not found");
            }
            break;

        case "search":
            Console.Clear();

            SearchEventByDate();
            break;

        case "empty":
            Console.Clear();

            EmptyListEvent();
            break;
    };

} while (userInput != "stop");

CountEvents();

StampEventsList();




//Metodo per aggiungere un singolo evento

Event addEvent()
{
    Console.WriteLine("****Insert event's name: ****");
    string eventTitle = Console.ReadLine();

    Console.WriteLine("****Insert event's date (gg/mm/yyy): ****");
    DateTime eventDate = DateTime.Parse(Console.ReadLine());

    Console.WriteLine("****Insert max occupancy: ****");
    int totalSeats = Int32.Parse(Console.ReadLine());


    Event evento = new Event(eventTitle, eventDate, totalSeats);
    events.Add(evento);
    Console.WriteLine(evento.ToString());

    return evento;
}

//Metodo per creare un programma di eventi   

void CreaProgrammaEventi()
{
    Console.WriteLine(Environment.NewLine);
    Console.Write("Enter the title of the event program: ");
    string tempTitle = Console.ReadLine();

    ProgramEvents programmaEventi = new ProgramEvents(tempTitle);

    Console.Write("Enter how many events you want to include in the program: ");
    int tempNumber = Int32.Parse(Console.ReadLine());
    try
    {
        for (int i = 0; i < tempNumber; i++)
        {
            Event newEvent = addEvent();
            if (newEvent == null)
            {
                throw new Exception("**** Attention a null event has been generated *****");
            }

            programmaEventi.AddEvent(newEvent);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(Environment.NewLine);
        Console.WriteLine($"****Error: {e.Message}****");
    }

    Console.WriteLine(ProgramEvents.GetEventsList(programmaEventi.Events));

}

//Metodo per cercare gli eventi tramite la data 

void SearchEventByDate()
{
    List<Event> tempEvents = new List<Event>();
    Console.WriteLine("****Enter date to search for events: ****");
    string SDate = Console.ReadLine();
    DateTime date = Convert.ToDateTime(SDate);

    foreach (Event evento in events)
    {
        if (evento.Date == date)
        {
            tempEvents.Add(evento);
        }
    }
    Console.WriteLine($"****The events on date {date} are: ****");
    foreach (Event evento in tempEvents)
    {
        Console.WriteLine($"Event's name: {evento.Title}");
    }
}

//Metodo per stampare tutti gli eventi  

void StampEventsList()
{
    foreach (Event eventItem in events)
    {
        Console.WriteLine($"****Event: {eventItem.ToString()}****");
    }
}

//Metodo per contare il numero di eventi  

void CountEvents()
{
    Console.WriteLine($"****Number of scheduled events: {events.Count()}****");
}

//Metodo per azzerare la lista degli event  

void EmptyListEvent()
{
    events.Clear();
}

