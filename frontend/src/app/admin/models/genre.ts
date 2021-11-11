import { BookItem } from './book-item';
export class Genre {
    constructor(
        public genreId: number,
        public genreName: string,
        public desc: string,
        public ImageUrl: string,
        public ImageFile: File,
        public genreStatus: string,
        public genrePosition: number,
        public createdDate: Date,
        public books: BookItem[]
    ){}
}
