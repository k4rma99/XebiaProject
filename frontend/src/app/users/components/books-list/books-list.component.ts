import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styles: [
  ]
})
export class BooksListComponent implements OnInit {
  bookList: any[] = [];
  bookSubscription:Subscription | undefined = undefined;

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.bookSubscription = this.userService.getBooks().subscribe( (res:any) => {
      console.log(`Res inside ts file:${res[0].name}`);
      this.bookList = res;
    });
    console.log(`userList = ${this.bookList}`);
  }

  handleAddToCart(book:any){

  }

}
