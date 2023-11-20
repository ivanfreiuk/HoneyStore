import { Product } from './product';

export class CartItem {
    id: number;
    userId: number | undefined;
    quantity: number;
    isOrdered: boolean | undefined;
    createdOn: Date | undefined;
    productId: number | undefined;
    product: Product;
    orderId: number | undefined;

    constructor() {
        this.id = 0;
        this.userId = 0;   
        this.quantity = 0;
        this.isOrdered = false;
        this.createdOn = new Date();
        this.productId = 0;
        this.product = new Product();       
        this.orderId = 0;
    }
}