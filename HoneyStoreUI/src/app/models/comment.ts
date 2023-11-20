export class Comment {
    id: number;
    productId: number | undefined; 
    userId: number;
    headline: string | undefined;
    createdOn: Date | undefined;
    mark: number;
    content: string | undefined;
    userName: string;

    constructor(){
        this.id = 0;
        this.userId = 0;
        this.mark = 0;
        this.userName = ''
    }
}