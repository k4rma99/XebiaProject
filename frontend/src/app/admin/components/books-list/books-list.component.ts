import { BookItem } from './../../models/book-item';
import { BooklistService } from './../../services/booklist.service';
// import { Book } from './../../interfaces/book';
import { Subscription } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import {NgbModal, ModalDismissReasons, NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

  title = 'ng-bootstrap-modal-demo';
  closeResult!: string;
  modalOptions!: NgbModalOptions;

  books_list: any[] = [];
  bookSubscription: Subscription | undefined = undefined;

  bookForm!: FormGroup;
  BooklistService: any;

  selectedBook!: BookItem;

  bookModel = new BookItem(
    101,
    "123",
    "A",
    "B",
    "C",
    new Date("2021-01-01"),
    "D",
    0,
    "E",
    "F",
    new Date("2021-01-01"),
    0,
    "F"
  );


  constructor(
    private books : BooklistService,
    private router : Router,
    private form: FormBuilder,
    private modalService: NgbModal
  ) {
    this.modalOptions = {
      backdrop:'static',
      backdropClass:'customBackdrop'
    }
  }

  ngOnInit(): void {

    this.books.listBooks().subscribe((data : any) => {
      this.books_list = data as any[];
      // console.log(this.books_list)
    })

  }

  open(content: any) {
    this.modalService.open(content, this.modalOptions).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }


  // createBookItem(){
  //   this.bookModel.isbn = this.bookForm.value.isbn;
  //   this.bookModel.title = this.bookForm.value.title;
  //   this.bookModel.subtitle = this.bookForm.value.subtitle;
  //   this.bookModel.author = this.bookForm.value.author;
  //   this.bookModel.published = this.bookForm.value.published;
  //   this.bookModel.publisher = this.bookForm.value.publisher;
  //   this.bookModel.pages = this.bookForm.value.pages;
  //   this.bookModel.description = this.bookForm.value.description;
  //   this.bookModel.website = this.bookForm.value.website;
  //   this.bookModel.featured_date = this.bookForm.value.featured_date;
  //   this.bookModel.stock = this.bookForm.value.stock;
  //   this.bookModel.Genre = this.bookForm.value.Genre;


  //   this.BooklistService.createBook(this.bookModel)
  //     .subscribe((res: any) => {
  //       console.log(res);
  //       alert("Book added sucessfully")
  //     })
  //     this.bookForm .reset;
  // }

  onSubmit(){
    this.books.createBook(this.bookModel)
      .subscribe(
        data => console.log("Success!" , data),
        error => console.log("Error" , error)
      )
  }

  getDetails(book: BookItem) : void{
    this.selectedBook = book;
    // console.log(this.selectedBook)
    this.router.navigateByUrl("/booksdb/" + book.id);
  }

  removeItem(id: number){
    this.books.deleteBook(id)
    .subscribe(
      data => console.log("Success!" , data),
      error => console.log("Error" , error)
    )
  }

  updateItem(id: number){
    console.log("Bk")
    console.log(id);
  }


}
