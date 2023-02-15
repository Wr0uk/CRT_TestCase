namespace CRT_TestCase;

public class Book
{
    public string author { get; set; }
    public uint id { get; set; }
    public bool isElectronicBook { get; set; }
    public string name { get; set; }
    public int year { get; set; }
    
    public override bool Equals(Object obj)
    {
        Book toEqual = (Book) obj;
        return
            author == toEqual.author &&
            isElectronicBook == toEqual.isElectronicBook &&
            id == toEqual.id &&
            name == toEqual.name &&
            year == toEqual.year;
    }
}

public class Root
{
    public List<Book> books { get; set; }
}

public class SingleBook
{
    public Book book { get; set; }
}
