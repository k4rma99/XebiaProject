export class BookItem {
    constructor(
        public id : number,
        public isbn: string,
        public title: string,
        public author: string,
        public publisher: string,
        public description: string,
        public year: number,
        public stock : number,
        public genre: string,
        public genreId: number,
        public authorId: number,
        public price: number,
        public imageFile: File,
        public imageUrl: string,
        public bookStatus: string,
        public bookPos: number
    ){}
}
