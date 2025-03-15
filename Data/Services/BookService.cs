using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary.Data.Services
{
	public class BookService : IBookService
	{
		public void AddBook(Book newBook)
		{
			Data.Books.Add(newBook);
			// throw new NotImplementedException();
		}

		public void DeleteBook(int id)
		{
			var bookToRemove = Data.Books.FirstOrDefault(b => b.Id == id);
			if (bookToRemove == null)
			{
				return;
			}
			Data.Books.Remove(bookToRemove);
		}

		public List<Book> GetAllBooks()
		{
			// create new list to prevent unwanted modification
			// on the original list
			return Data.Books.ToList();
		}

		public Book? GetBookById(int id)
		{
			return Data.Books.FirstOrDefault(b => b.Id == id);
		}

		public void UpdateBook(int id, Book book)
		{
			var oldBook = Data.Books.FirstOrDefault(b => b.Id == id);
			if (oldBook == null)
			{
				return;
			}
			oldBook.Title = book.Title;
			oldBook.Author = book.Author;
			oldBook.Description = book.Description;
			oldBook.Rate = book.Rate;
			oldBook.DateStart = book.DateStart;
			oldBook.DateRead = book.DateRead;
		}
	}
}