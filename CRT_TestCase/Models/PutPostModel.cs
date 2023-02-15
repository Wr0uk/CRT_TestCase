namespace CRT_TestCase;

public class PutPostModel
{
    public PutPostModel(Book book)
    {
        author = book.author;
        isElectronicBook = book.isElectronicBook;
        name = book.name;
        year = book.year;
    }
    public PutPostModel(string author, bool isElectronicBook,string name, int year)
    {
        this.author = author;
        this.isElectronicBook = isElectronicBook;
        this.name = name;
        this.year = year;
    }

    public override bool Equals(Object obj)
    {
        PutPostModel toEqual = (PutPostModel) obj;
        return
            author == toEqual.author &&
            isElectronicBook == toEqual.isElectronicBook &&
            name == toEqual.name &&
            year == toEqual.year;
    }

    public string author { get; set; }
    public bool isElectronicBook { get; set; }
    public string name { get; set; }
    public int year { get; set; }
}