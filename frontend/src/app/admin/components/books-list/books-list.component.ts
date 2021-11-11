import { HttpClient } from '@angular/common/http';
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

  selectedFile!: File;

  bookForm!: FormGroup;
  BooklistService: any;

  bookImagesPath = "~/Images/Book/";

  selectedBook!: BookItem;

  bookModel = new BookItem(
    101,
    "123",
    "A",
    "B",
    "C",
    "XYZ",
    2021,
    10,
    "Horror",
    2394,
    1494,
    1348.2934,
    new File(["1"], "1.jpg", {type: "image/jpg",}),
    this.bookImagesPath + "",
    "o",
    102
  );


  constructor(
    private books : BooklistService,
    private router : Router,
    private form: FormBuilder,
    private modalService: NgbModal,
    private http: HttpClient
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

    this.bookForm = this.form.group({
      id : [0],
      isbn: [''],
      title: [''],
      author: [''],
      publisher: [''],
      description: [''],
      year: [0],
      stock : [0],
      genre: [''],
      price: [0],
      imageFile: File,
      imageUrl: [this.bookImagesPath + ''],
      bookStatus: [''],
      bookPos: [0]
    })

  }

  onFileSelected(event: any){
    this.selectedFile=<File>event.target.files[0];
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
    this.bookModel.imageFile = this.selectedFile;
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

  updateItem(targetModal: any , book: BookItem){
    this.modalService.open(targetModal, {
      backdrop: 'static',
      size: 'lg'
    });
    this.bookForm.patchValue( {
      id : book.id,
      isbn: book.isbn,
      title: book.title,
      author: book.author,
      publisher: book.publisher,
      description: book.description,
      year: book.year,
      stock : book.stock,
      genre: book.genre,
      price: book.price,
      imageFile: book.imageFile,
      bookStatus: book.bookStatus,
      bookPos: book.bookPos
    });
  
  }


}
