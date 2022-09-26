// See https://aka.ms/new-console-template for more information

public class Event
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
    public int MaxOccupancy { get; private set; }
    public int ReservedSeats { get; private set; }

    public Event(string title, DateTime date, int maxOccupancy)
    {

        if (title == "")
        {
            throw new Exception("Title cannot be empty");
        }
        else
        {
            Title = title;
        }
        if (date < DateTime.Now)
        {
            throw new Exception("Invalid Date (date has passed)");
        }
        else
        {
            Date = date;
        }
        if (maxOccupancy <= 0)
        {
            throw new Exception("Occupancy cannot be negative or equals 0");
        }
        else
        {
            MaxOccupancy = maxOccupancy;
        }

        ReservedSeats = 0;
    }


    public int PrenotaPosti(int seatsToBook)
    {

        if (seatsToBook > GetAvailableSeats())
        {
            throw new Exception("Invalid number of seats(Too many places)");
        } else
        {
            ReservedSeats += seatsToBook;
            return ReservedSeats;
        }
    }

    public int DisdiciPosti(int seatsToBeCanceled)
    {
        if( (ReservedSeats - seatsToBeCanceled) > 0)
        {
            ReservedSeats -= seatsToBeCanceled;
            return ReservedSeats;

        } else
        {
            throw new Exception("Invalid number of seats");
        }
    }

    public int GetAvailableSeats()
    {
        int availableSeats = 0;
        availableSeats = MaxOccupancy - ReservedSeats;
        return availableSeats;
    }

    public override string ToString()
    {
        return Date + " - " + Title;
        
    }
}

