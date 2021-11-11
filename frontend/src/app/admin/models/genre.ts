import { BookItem } from './book-item';
export class Genre {
    constructor(
        public genreId: number,
        public genreName: string,
        public desc: string,
        public Image: string,
        public genreStatus: string,
        public genrePosition: string,
        public createdDate: Date,
        public books: BookItem[]
    ){}
}
