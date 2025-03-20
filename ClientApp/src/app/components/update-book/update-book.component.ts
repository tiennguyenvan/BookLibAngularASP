import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/services/book.service';

@Component({
	selector: 'app-update-book',
	templateUrl: './update-book.component.html',
	styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {
	editBookForm!: FormGroup;
	bookId: number = 0;
	constructor(
		private formBuilder: FormBuilder,  // inject form builder
		private route: ActivatedRoute,  // inject ActivatedRoute
		private service: BookService,  // inject BookService
		private router: Router  // inject RouterService
	) {
		this.bookId = parseInt(this.route.snapshot.paramMap.get('id')!);
	}

	ngOnInit(): void {
		// this.bookId = parseInt(this.route.snapshot.paramMap.get('id')!);
		this.editBookForm = this.formBuilder.group({
			id: [null],
			title: [null],
			author: [null],
			description: [null],
			rate: [null],
			dateStart: [null],
			dateRead: [null]
		})
		this.service.getBookById(this.bookId).subscribe(book => {
			this.editBookForm = this.formBuilder.group({
				id: [book.id],
				title: [book.title],
				author: [book.author],
				description: [book.description],
				rate: [book.rate],
				dateStart: [book.dateStart],
				dateRead: [book.dateRead]
			})
		})
	}

	onSubmit() {
		if (this.editBookForm.valid) {
			// this.bookId = parseInt(this.route.snapshot.paramMap.get('id')!);
			this.service.updateBook(this.editBookForm.value).subscribe(() => {
				this.router.navigate(['/show-book/', this.bookId]);
			});
		}

	}

}
