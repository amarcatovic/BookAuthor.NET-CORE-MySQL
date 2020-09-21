import { ToastrService } from 'ngx-toastr';
import { Author } from './../../authors-list/authors';
import { ApiService } from './../../services/api.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-book-manager',
  templateUrl: './book-manager.component.html',
  styleUrls: ['./book-manager.component.css']
})
export class BookManagerComponent implements OnInit {

  authorSearchNameText: string = '';

  authors: Author[];
  addedAuthors: {id: number, name: string}[] = [];
  
  formValid: boolean = true;
  formValidText: string = '';
  form: FormGroup;

  constructor(private apiService: ApiService, private toastr: ToastrService) { 
    this.apiService.get('authors')
      .then(jsonData => this.authors = jsonData);
  }

  ngOnInit(): void {
    this.form = new FormGroup({
      'name': new FormControl('', Validators.required),
      'description': new FormControl('', Validators.required),
      'published': new FormControl('', Validators.required),
      'search': new FormControl('')
    });
  }

  addAuthor(id: number, fullName: string){
    this.addedAuthors.push({id: id, name: fullName});
  }

  removeAuthor(id: number){
    let index = 0;
    for(let i = 0; i < this.addedAuthors.length; ++i){
      if(this.addedAuthors[i].id === id){
        index = i;
        break;
      }
    }

    this.addedAuthors.splice(index, 1);
  }

  onFormSubmit(){
    if(this.addedAuthors.length === 0){
      this.formValid = false;
      this.formValidText = 'You need to add at least one author!';
    }
    else if(this.form.invalid){
      this.formValid = false;
      this.formValidText += 'Fix inputs with red borders!';
    }else {

      const authorIds: number[] = [];
      for(const author of this.addedAuthors){
        authorIds.push(author.id);
      }

      const uploadData = {
        name: this.form.get('name').value,
        description: this.form.get('description').value,
        published: this.form.get('published').value,
        authorIds: authorIds
      };

      this.apiService.post('books', uploadData)
        .then(res => {
          if(res){
            this.toastr.success('Book added!');
            this.form.reset();
            this.addedAuthors = [];
            this.authorSearchNameText = '';
          } else {
            this.toastr.error('Problem adding book!');
          }
        })
    }
  }

}
