import { Product } from './product';

export class Wish {
    id: number | undefined;
    userId: number | undefined;
    quantity: number | undefined;
    createdOn: Date | undefined;
    productId: number | undefined;
    product: Product | undefined;
    orderId: number | undefined;

    constructor() {
        this.id = 0;
        this.userId = 0;   
        this.quantity = 0;
        this.createdOn = new Date();
        this.productId = 0;
        this.product = new Product();       
        this.orderId = 0;
    }
}