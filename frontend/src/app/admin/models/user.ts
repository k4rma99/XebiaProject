import { UserAddress } from './user-address';
import { Log } from './log';
import { Order } from './order';

export class User {
    constructor(
        public id: number,
        public fname: string,
        public lname: string,
        public phone: string,
        public email: string,
        public password: string,
        public accStatus: string,
        public Role: string,
        public orders: Order[],
        public logs: Log[],
        public Addresses: UserAddress[] 
    ){}
}
