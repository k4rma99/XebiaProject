import { BookItem } from './../../models/book-item';
import { BooklistService } from './../../services/booklist.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-book-profile',
  templateUrl: './book-profile.component.html',
  styleUrls: ['./book-profile.component.scss']
})
export class BookProfileComponent implements OnInit {

  @Input() book!: BookItem;

  constructor(
    private router: Router,
    private service: BooklistService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {

    let book_id = + this.route.snapshot.params['booksId'];
    
    console.log(book_id);

    this.service.listByID(book_id)
      .subscribe(
        data => this.book = data,
        error => console.log("Error" , error)
      )

    console.log(this.book)
  }

}
