using System.Net;

namespace CRT_TestCase.Tests;

public class AssertDefaultValueTest
{
    private const string EndPoint = "http://localhost:5000/api/books";

    [Fact]
    public void Test_Put_Assert()
    {
        var getAllStatus = EndPointsMethods.GetAll(EndPoint, out Root? data);
        if (getAllStatus is not HttpStatusCode.OK)
            Assert.Fail($"Error when tryed getAll, status code is: {(int) getAllStatus}({getAllStatus})");
        if (data == null)
            Assert.Fail("Can not cath id because data is null");
        var book = data.books[0];
        book.author = "testAuthor";
        book.name = "testName";
        book.year = 2023;
        book.isElectronicBook = true;
        var status = EndPointsMethods.Put(EndPoint, book, out Book newBook);
        if (status != HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
        Assert.Equal(book, newBook);
    }

    [Fact]
    public void Test_Post_Assert()
    {
        PutPostModel data = new PutPostModel(
            "testAuthor",
            false,
            "testName",
            2023
        );
        var status = EndPointsMethods.Post(EndPoint, data, out Book book);
        if (status != HttpStatusCode.Created)
            Assert.Fail($"Status code is: {(int) status}({status})");
        PutPostModel dataToCheck = new PutPostModel(book);
        if (!data.Equals(dataToCheck))
            Assert.Fail("Posted data is incorrect");

    }

    [Fact]
    public void Test_Delete_Assert()
    {
        var getAllStatus = EndPointsMethods.GetAll(EndPoint, out Root? data);
        if (getAllStatus is not HttpStatusCode.OK)
            Assert.Fail($"Error when tryed getAll, status code is: {(int) getAllStatus}({getAllStatus})");
        if (data == null || data.books.Count == 0)
            Assert.Fail("Can not cath id because data is null");
        var books = data.books;
        var status = EndPointsMethods.Delete(EndPoint, books[0].id);
        if (status != HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
        var newGetAllStatus = EndPointsMethods.GetAll(EndPoint, out Root? newData);
        if (newGetAllStatus is not HttpStatusCode.OK)
            Assert.Fail($"Error when tryed getAll, status code is: {(int) getAllStatus}({getAllStatus})");
        if (books.Count - 1 != newData.books.Count)
            Assert.Fail("Delete was not procced");
    }
}