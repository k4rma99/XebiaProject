import { OrderDetails } from './order-details';
import { Coupon } from './coupon';
export class Order {
    constructor(
        public orderId: number,
        public userId: number,
        public orderDate: Date,
        public orderCouponId: number,
        public coupon: Coupon,
        public orderDetails: OrderDetails[]
    ){}
}
