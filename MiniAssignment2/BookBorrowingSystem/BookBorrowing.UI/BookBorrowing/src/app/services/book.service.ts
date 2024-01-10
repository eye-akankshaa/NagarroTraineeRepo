import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Book } from '../models/book.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http: HttpClient, private router: Router) { }

  baseServerUrl = "https://localhost:44347/api/";

  addNewBook(model: Book): Observable<void> {

    return this.http.post<void>(this.baseServerUrl + "Book/Addbooks", model);
  }



  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`https://localhost:44347/api/Book/GetAllBooks`);
  }

  

  getBookById(id: number): Observable<Book> {
    return this.http.get<Book>(`${this.baseServerUrl}Book/FindBook/` + id);
  }

  updateBook(id: number, updateBook: Book): Observable<Book> {
    return this.http.put<Book>(`https://localhost:44347/api/Book/UpdateBook/${id}`, updateBook);
  }




}
