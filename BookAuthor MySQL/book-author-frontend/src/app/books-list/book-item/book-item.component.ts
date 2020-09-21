import { Book } from './../book';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-book-item',
  templateUrl: './book-item.component.html',
  styleUrls: ['./book-item.component.css']
})
export class BookItemComponent implements OnInit {

  @Input() book: Book;
  @Output() getBookDetails = new EventEmitter<Book>();

  private show: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

  toggleShow(){
    if(!this.show){
      this.getBookDetails.emit(this.book);
    }
    
    this.show = !this.show;
  }

  getBookPublishedDate(){
    const date = new Date(this.book.published);

    return date.toDateString();
  }

  getBookAuthorsToString(){
    let returnString = '';
    for(const author of this.book.authors){
      returnString += author.firstName + ' ' + author.lastName + ', ';
    }

    return returnString.substr(0, returnString.length - 2);
  }

}
