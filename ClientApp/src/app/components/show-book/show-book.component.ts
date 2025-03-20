import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/interfaces/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-show-book',
  templateUrl: './show-book.component.html',
  styleUrls: ['./show-book.component.css']
})
export class ShowBookComponent implements OnInit {
	public book!: Book;
	constructor(
		private service: BookService,
        private router: Router,
		private route: ActivatedRoute,
	) { }

	ngOnInit(): void {
		const bookId = parseInt(this.route.snapshot.paramMap.get('id')!);
        this.service.getBookById(bookId).subscribe(book => {
			this.book = book;
		})
    }

	deleteBook(bookId: number) {
		this.service.deleteBook(bookId).subscribe(() => {
            this.router.navigate(['/books']);
        });        
	}
}
