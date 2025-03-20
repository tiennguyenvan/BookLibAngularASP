import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/interfaces/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.css']
})
export class BooksComponent implements OnInit {
	public books: Book[] = [];
	constructor(private service: BookService) {	}

	ngOnInit(): void {
        this.service.getAllBooks().subscribe(books => {
            this.books = books;
        });
    }
}
