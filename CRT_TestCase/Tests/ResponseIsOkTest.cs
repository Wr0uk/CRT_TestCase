using System.Net;

namespace CRT_TestCase.Tests;

public class ResponseIsOkTest
{
    private const string EndPoint = "http://localhost:5000/api/books";

    [Fact]
    public void Test_GetAll_IsOk()
    {
        var status = EndPointsMethods.GetAll(EndPoint);
        if (status is not HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
    }

    [Fact]
    public void Test_GetByID_IsOk()
    {
        var getAllStatus = EndPointsMethods.GetAll(EndPoint, out Root? data);
        if (getAllStatus is not HttpStatusCode.OK)
            Assert.Fail($"Error when tryed getAll, status code is: {(int) getAllStatus}({getAllStatus})");
        if (data == null)
            Assert.Fail("Can not cath id because data is null");
        uint id = data.books[0].id;
        var status = EndPointsMethods.GetById(EndPoint, id);
        if (status != HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
    }

    [Fact]
    public void Test_Put_isOk()
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
        var status = EndPointsMethods.Put(EndPoint , book);
        if (status != HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
    }

    [Fact]
    public void Test_Post_isOk()
    {
        PutPostModel data = new PutPostModel(
            "testAuthor",
            false,
            "testName",
            2023
        );
        var status = EndPointsMethods.Post(EndPoint, data);
        if (status != HttpStatusCode.Created)
            Assert.Fail($"Status code is: {(int) status}({status})");
    }

    [Fact]
    public void Test_Delete_isOk()
    {
        var getAllStatus = EndPointsMethods.GetAll(EndPoint, out Root? data);
        if (getAllStatus is not HttpStatusCode.OK)
            Assert.Fail($"Error when tryed getAll, status code is: {(int) getAllStatus}({getAllStatus})");
        if (data == null || data.books.Count==0)
            Assert.Fail("Can not cath id because data is null");
        var id = data.books[0].id;
        var status = EndPointsMethods.Delete(EndPoint, id);
        if (status != HttpStatusCode.OK)
            Assert.Fail($"Status code is: {(int) status}({status})");
    }
}
