import { FormGroup, FormControl } from '@angular/forms';
import { ApiService } from './../services/api.service';
import { Component, OnInit } from '@angular/core';
import {Book} from './book';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.css']
})
export class BooksListComponent implements OnInit {

  form: FormGroup;

  private bookClicked: boolean = false;
  private books: Book[];
  bookSearchName: string = '';
  selectedBook: Book;

  constructor(private apiService: ApiService) {
    this.apiService.get('books')
      .then(jsonData => this.books = jsonData); 
   }

  ngOnInit(): void {

    this.form = new FormGroup({
      'search': new FormControl('')
    });

  }

  showBookDetails(book: Book){
    this.bookClicked = true;
    this.selectedBook = book;
  }

}
