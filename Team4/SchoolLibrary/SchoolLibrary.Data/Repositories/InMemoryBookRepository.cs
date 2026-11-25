using SchoolLibrary.Data.Models;

namespace SchoolLibrary.Data.Repositories;

public class InMemoryBookRepository : IBookRepository
{
    // Примерен списък с книги в паметта
    private readonly List<Book> books = new()
    {
        new Book { Id = 1, Title = "Под игото", Author = "Иван Вазов", IsBorrowed = false },
        new Book { Id = 2, Title = "Малкият принц", Author = "Антоан дьо Сент Екзюпери", IsBorrowed = false },
        new Book { Id = 3, Title = "Пипи Дългото чорапче", Author = "Астрид Линдгрен", IsBorrowed = false }
    };

    // Връща целия списък с книги
    public IReadOnlyList<Book> GetAll()
    {
        return books;
    }

    // Търсене на книга по нейното Id
    public Book? GetById(int id)
    {
        // Обхождаме всяка книга в списъка
        foreach (Book book in books)
        {
            // Сравняваме уникалния номер на книгата с търсеното id
            if (book.Id == id)
            {
                // Връщаме намерената книга
                return book;
            }
        }

        // Ако обходим целия списък и не открием съвпадение, връщаме null
        return null;
    }
}