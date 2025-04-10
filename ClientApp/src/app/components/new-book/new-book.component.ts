import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Book } from 'src/app/interfaces/book';
import { BookService } from 'src/app/services/book.service';

@Component({
  selector: 'app-new-book',
  templateUrl: './new-book.component.html',
  styleUrls: ['./new-book.component.css']
})
export class NewBookComponent implements OnInit {
	addBookForm!: FormGroup;
	
	constructor(private service: BookService, private fb: FormBuilder, private router: Router) { }
	ngOnInit(): void {
		this.addBookForm = this.fb.group({
			id: [Math.floor(Math.random() * 1000)],
			title: [null, Validators.required],
            author: [null, Validators.required],
            description: [null, Validators.compose([Validators.required, Validators.minLength(30)])],
            rate: [null],
            dateStart: [null],
            dateRead: [null]			
		})
	}

	onSubmit() {
		if(this.addBookForm.valid) {
            this.service.addBook(this.addBookForm.value).subscribe(book => {
                this.router.navigate(['/books']);
            });
        }
    }
	
}
