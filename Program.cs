// See https://aka.ms/new-console-template for more information

using System;

List<Event> events = new List<Event>();
List<ProgramEvents> programEvents = new List<ProgramEvents>();

string userInput;

do
{
    Console.WriteLine("****Welcome****");

    Console.WriteLine("Insert 'add single' for add a single event");
    Console.WriteLine("Insert 'add group' for add a group of events");
    Console.WriteLine("Insert 'manage booking' for manage booking of an event");
    Console.WriteLine("Insert 'search' for search event by date");
    Console.WriteLine("Insert 'empty' for delete all events");
    Console.WriteLine("Insert 'stop' for terminate the process");
    userInput = Console.ReadLine();

    if (userInput == "add single")
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
    else if (userInput == "add group")
    {
        CreaProgrammaEventi();
    }
    else if (userInput == "search")
    {
        SearchEventByDate();
    }
    else if (userInput == "empty")
    {
        EmptyListEvent();
    }

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
    Console.WriteLine("Inserire il titolo del nuovo programma eventi: ");
    string titolo = Console.ReadLine();

    ProgramEvents programmaEventi = new ProgramEvents(titolo);

    Console.WriteLine("Quanti eventi inserire nel programma?");
    int numeroEventi = Int32.Parse(Console.ReadLine());


    for (int i = 0; i < numeroEventi; i++)
    {
        Event nuovoEvento = addEvent();
        if (nuovoEvento == null)
        {
            throw new Exception("Attenzione è stato generato un evento nullo");
        }
        programEvents.Add(programmaEventi);
    }
}

//Metodo per cercare gli eventi tramite la data 

void SearchEventByDate()
{
    List<Event> tempEvents = new List<Event>();
    Console.WriteLine("Inserire data per cercare eventi: ");
    string SDate = Console.ReadLine();
    DateTime date = Convert.ToDateTime(SDate);

    foreach (Event evento in events)
    {
        if (evento.Date == date)
        {
            tempEvents.Add(evento);
        }
    }
    Console.WriteLine($"Gli eventi presenti in data {date} sono:");
    foreach (Event evento in tempEvents)
    {
        Console.WriteLine($"Nome Evento: {evento.Title}");
    }
}

//Metodo per stampare tutti gli eventi  

void StampEventsList()
{
    foreach (Event eventItem in events)
    {
        Console.WriteLine($"Event: {eventItem.ToString()}");
    }
}

//Metodo per contare il numero di eventi  

void CountEvents()
{
    Console.WriteLine("Numero eventi in programma: " + events.Count());
}

//Metodo per azzerare la lista degli event  

void EmptyListEvent()
{
    events.Clear();
}
