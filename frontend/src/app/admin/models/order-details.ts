import { BookItem } from './book-item';
import { User } from './user';
export class OrderDetails {
    constructor(
        public detailsId: number,
        public userId: number,
        public bookId: number,
        public price: number,
        public isbn: number,
        public totalPrice: number,
        public oShippingAddress: string,
        public oBillingAddress: string,
        public oPaymentMode: string,
        public userDetails: User,
        public bookDetails: BookItem
    ){}    
}
