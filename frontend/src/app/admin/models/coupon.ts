export class Coupon {
    constructor(
        public cId: number,
        public code: string,
        public cName: string,
        public expiry: Date,
        public cDiscount: number,
    ){}
}
