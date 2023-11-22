import { Producer } from './producer';
import { Category } from './category';
import { ProductPhoto } from './product-photo';

export class Product {
    id: number;
    imageUrl: string | undefined;
    name: string;    
    mark: number;
    description: string | undefined;
    price: number;
    quantity: number;
    commentsEnabled: boolean | undefined;
    producer: Producer;
    productPhotoId: number;
    productPhoto: ProductPhoto;
    categories: Category[] | undefined;

    constructor() {
        this.id = 0;
        this.name = '';   
        this.imageUrl = '';
        this.mark = 0;
        this.description = '';
        this.price = 0;
        this.quantity = 0;       
        this.commentsEnabled = true;
        this.productPhotoId = 0;
        this.productPhoto = new ProductPhoto();
        this.producer = new Producer();
        this.categories = [];
    }
}