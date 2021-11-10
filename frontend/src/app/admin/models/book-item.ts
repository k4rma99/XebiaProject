export class BookItem {
    constructor(
        public id : number,
        public isbn: string,
        public title: string,
        public subtitle: string,
        public author: string,
        public published: Date,
        public publisher: string,
        public pages: number,
        public description: string,
        public website: string,
        public featured_date: Date,
        public stock : number,
        public Genre: string
    ){}
}
