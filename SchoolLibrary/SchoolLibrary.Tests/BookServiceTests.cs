using SchoolLibrary.Data.Repositories;
using SchoolLibrary.Services;
using Xunit;

namespace SchoolLibrary.Tests;

public class BookServiceTests
{
    // Тест 1: Заемане на налична книга
    [Fact]
    public void BorrowBook_WhenBookIsAvailable_MarksItAsBorrowed()
    {
        // Arrange (Подготовка)
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        // Act (Действие)
        string result = service.BorrowBook(1);

        // Assert (Проверка)
        Assert.Equal("Книгата е заета успешно.", result);
        Assert.True(repository.GetById(1)!.IsBorrowed);
    }

    // Тест 2: Повторно заемане на вече заета книга
    [Fact]
    public void BorrowBook_WhenBookIsAlreadyBorrowed_ReturnsMessage()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);
        service.BorrowBook(1);

        // Act
        string result = service.BorrowBook(1);

        // Assert
        Assert.Equal("Книгата вече е заета.", result);
    }

    // Допълнителен тест 3: Заемане на несъществуваща книга
    [Fact]
    public void BorrowBook_WhenBookDoesNotExist_ReturnsNotFoundMessage()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);

        // Act
        string result = service.BorrowBook(999);

        // Assert
        Assert.Equal("Книгата не е намерена.", result);
    }

    // Допълнителен тест 4: Връщане на заета книга
    [Fact]
    public void ReturnBook_WhenBookIsBorrowed_MakesItAvailableAgain()
    {
        // Arrange
        var repository = new InMemoryBookRepository();
        var service = new BookService(repository);
        service.BorrowBook(1);

        // Act
        string result = service.ReturnBook(1);

        // Assert
        Assert.Equal("Книгата е върната успешно.", result);
        Assert.False(repository.GetById(1)!.IsBorrowed);
    }
}