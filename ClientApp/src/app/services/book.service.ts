import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Book } from '../interfaces/book';

@Injectable({
	providedIn: 'root'
})
export class BookService {
	_baseUrl: string = 'https://localhost:7130/api/book';
	constructor(private http: HttpClient) {

	}

	getAllBooks() {
		return this.http.get<Book[]>(this._baseUrl);
	}
	getBookById(id: number) {
        return this.http.get<Book>(`${this._baseUrl}/${id}`);
    }
	addBook(book: Book) {
		return this.http.post<Book>(this._baseUrl, book);
	}
	deleteBook(id: number) {
		return this.http.delete(`${this._baseUrl}/${id}`);
	}
	updateBook(book: Book) {
        return this.http.put<Book>(`${this._baseUrl}/${book.id}`, book);
    }

}
