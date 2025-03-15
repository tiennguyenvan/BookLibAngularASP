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
			throw new NotImplementedException();
		}

		public List<Book> GetAllBooks()
		{
			// create new list to prevent unwanted modification
			// on the original list
			return Data.Books.ToList();
		}

		public Book GetBookById(int id)
		{
			throw new NotImplementedException();
		}

		public void UpdateBook(int id, Book book)
		{
			throw new NotImplementedException();
		}
	}
}