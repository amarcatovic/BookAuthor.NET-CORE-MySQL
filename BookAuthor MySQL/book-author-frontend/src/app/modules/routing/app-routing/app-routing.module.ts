import { BookManagerComponent } from './../../../books-list/book-manager/book-manager.component';
import { HomeComponent } from './../../../home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksListComponent } from 'src/app/books-list/books-list.component';
import { AuthorsListComponent } from 'src/app/authors-list/authors-list.component';

const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'books', component: BooksListComponent, },
  {path: 'books/add', component: BookManagerComponent, },
  {path: 'authors', component: AuthorsListComponent},
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
