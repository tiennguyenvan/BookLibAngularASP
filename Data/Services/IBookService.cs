namespace BookLibrary.Data {
	public interface IBookService {		
		List<Book> GetAllBooks();
		Book? GetBookById(int id);
		void UpdateBook(int id, Book book);
		void DeleteBook(int id);	
		void AddBook(Book newBook);		
	}
}