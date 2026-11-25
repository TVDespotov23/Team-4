namespace SchoolLibrary.Data.Models;

public class Book
{
    // Уникален идентификатор на книгата
    public int Id { get; set; }

    // Заглавие на книгата (инициализирано с празен string, за да няма null референция)
    public string Title { get; set; } = string.Empty;

    // Автор на книгата
    public string Author { get; set; } = string.Empty;

    // Булево свойство: true = книгата е заета, false = книгата е налична
    public bool IsBorrowed { get; set; }
}