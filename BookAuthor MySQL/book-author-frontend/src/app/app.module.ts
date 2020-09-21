import { AppRoutingModule } from './modules/routing/app-routing/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BooksListComponent } from './books-list/books-list.component';
import { AuthorsListComponent } from './authors-list/authors-list.component';
import { NavbarComponent } from './navbar/navbar.component';
import { BookItemComponent } from './books-list/book-item/book-item.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SearchPipe } from './pipes/search.pipe';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BookManagerComponent } from './books-list/book-manager/book-manager.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BooksListComponent,
    AuthorsListComponent,
    NavbarComponent,
    BookItemComponent,
    SearchPipe,
    BookManagerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
