namespace HotelManagementSoftware;

public class HotelCatalogue // Catalogue
{
    // Detta hotelCatalogue klass säger varje klass som hämtar data från en hotell databas ska implementera interfacet ISQLConnection för att kopplas till Catalogue klassen (logiken) och kunna köras i detta program.

    ISQLRepository iSQLRepository;
    public HotelCatalogue(ISQLRepository _iSQLRepository)
    {
        iSQLRepository = _iSQLRepository;
    }

    // Här ska alla metoder som hanterar deta från databasen ligga och även olika listor av olika typer av data som hämtas från databasen.





}





// ISQLRepository interfacet är för att varje klass som hämtar data från en hotell databas och vill köras i detta program ska implementeras ISQLConnectionoch interfacet och dess metoder, 
// Metoder i detta interface säger att varje klass som matchar tabeller i en hotell databas ska implementera interfacet ISearchable.
public interface ISQLRepository // Detta interface är kopplingen mellan logiken och klassen som hanterar databasen.
{
    // En metod som ska kontrollerar om connection med databasen är öppet.
    void OpenDBConnection();

    IEnumerable<ISearchable> GetRooms();
    IEnumerable<ISearchable> GetCustomers();
    IEnumerable<ISearchable> GetReservations();
    void AddCustomer(string name, string email, string phoneNumber);
    void AddReservation(DateTime checkIn, DateTime checkOut, int totalCost, int customerId, int roomId);
    void UpdateRoomInfo(int roomNumber, string type, int price);
}




public interface ISearchable // Detta intreface ska implementeras av alla klasser som matchar tabeller från databasen
{
    bool MyContains(int value);
}

abstract class HotelItem : ISearchable
{
    public abstract bool MyContains(int value);

    public abstract override string ToString();
}



public class Room : ISearchable
{
    public int Id { get; set; }
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }


    //DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    //Konstruktor 
    // public Room(int _roomNumber, string _type, int _price)
    // {
    //     RoomNumber = _roomNumber;
    //     Type = _type;
    //     Price = _price;
    // }


    // Metod från ISearchable interfacet
    public bool MyContains(int roomNumber)
    {
        if (RoomNumber.Equals(roomNumber))
        {
            return true;
        }
        return false;
    }

    public bool MyContains(string typeOfRoom)
    {
        if (Type.Contains(typeOfRoom, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }
}





public class Reservation : ISearchable
{
    public int Id { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int TotalCost { get; set; }
    public int CustomerId { get; set; }
    public int RoomId { get; set; }


    //DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    // Konstruktor
    // public Reservation(DateTime _checkIn, DateTime _checkOut, int _totalCost, int _customerId, int _roomId)
    // {
    //     CheckIn = _checkIn;
    //     CheckOut = _checkOut;
    //     TotalCost = _totalCost;
    //     CustomerId = _customerId;
    //     RoomId = _roomId;
    // }


    // Metod från ISearchable interfacet
    public bool MyContains(int customerId)
    {
        if (CustomerId.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    // En överlagring av metoden MyContains som tar emot reservationId i string form för att ge möjligheten att kunna hitta på reservationer genom id
    public bool MyContains(string reservationId)
    {
        if (Id.Equals(int.Parse(reservationId)))
        {
            return true;
        }
        return false;
    }

}




public class Customer : ISearchable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    //DENNA Konstruktor SKA FIXAS EFTERSOM NÄR VI HÄMTAR DATTA FRÅN DATABASEN DÅ FUNKAR DET INTR OM Konstruktor FINNS I KLASSEN!
    // Konstruktor
    // public Customer(string _name, string _email, string _phoneNumber)
    // {
    //     Name = _name;
    //     Email = _email;
    //     PhoneNumber = _phoneNumber;
    // }


    // Metod från ISearchable interfacet
    public bool MyContains(int customerId)
    {
        if (Id.Equals(customerId))
        {
            return true;
        }
        return false;
    }

    // En överlagring av metoden MyContains som ger möjlighet att kunna hitta kunder även gerom deras namn
    public bool MyContains(string customerName)
    {
        if (Name.Contains(customerName, StringComparison.InvariantCultureIgnoreCase))
        {
            return true;
        }
        return false;
    }

}

