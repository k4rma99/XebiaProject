export class UserAddress {
    constructor(
        public addId: number,
        public userId: number,
        public addLineOne: string,
        public addLineTwo: string,
        public landMark: string,
        public city: string,
        public state: string,
        public country: string,
        public pincode: string  
    ){}
}
