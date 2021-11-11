import { BookItem } from './book-item';
export class Authors {
    constructor(
        public authorId: number,
        public authorFname: string,
        public authorLname: string,
        public authorCountry: string,
        public writtenBooks: BookItem[]
    ){}
}
