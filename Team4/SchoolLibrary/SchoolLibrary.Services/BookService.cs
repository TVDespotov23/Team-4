using SchoolLibrary.Data.Models;
using SchoolLibrary.Data.Repositories;

namespace SchoolLibrary.Services;

public class BookService
{
    // Поле за съхранение на хранилището (инжектира се през конструктора)
    private readonly IBookRepository repository;

    // Конструктор: получава хранилището като параметър
    public BookService(IBookRepository repository)
    {
        // Използваме this.repository, за да разграничим полето от параметъра
        this.repository = repository;
    }

    // Метод за вземане на всички книги
    public IReadOnlyList<Book> GetAllBooks()
    {
        return repository.GetAll();
    }

    // Метод за заемане на книга
    public string BorrowBook(int id)
    {
        // 1. Търсим книгата в хранилището по Id
        Book? book = repository.GetById(id);

        // 2. Проверка: книгата съществува ли?
        if (book == null)
        {
            return "Книгата не е намерена.";
        }

        // 3. Проверка: книгата вече заета ли е?
        if (book.IsBorrowed)
        {
            return "Книгата вече е заета.";
        }

        // 4. Отбелязваме книгата като заета
        book.IsBorrowed = true;

        // 5. Връщаме съобщение за успех
        return "Книгата е заета успешно.";
    }

    // Метод за връщане на книга
    public string ReturnBook(int id)
    {
        // 1. Търсим книгата в хранилището по Id
        Book? book = repository.GetById(id);

        // 2. Проверка: книгата съществува ли?
        if (book == null)
        {
            return "Книгата не е намерена.";
        }

        // 3. Проверка: книгата била ли е заета въобще?
        if (!book.IsBorrowed)
        {
            return "Книгата не е заета.";
        }

        // 4. Отбелязваме книгата като отново налична
        book.IsBorrowed = false;

        // 5. Връщаме съобщение за успех
        return "Книгата е върната успешно.";
    }
}