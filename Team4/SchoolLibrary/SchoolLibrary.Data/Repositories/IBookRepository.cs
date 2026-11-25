using SchoolLibrary.Data.Models;

namespace SchoolLibrary.Data.Repositories;

// Интерфейс, определящ какви методи трябва да има всяко хранилище за книги
public interface IBookRepository
{
    // Връща списък от всички книги
    IReadOnlyList<Book> GetAll();

    // Намира и връща книга по нейното ID (или null, ако не съществува)
    Book? GetById(int id);
}