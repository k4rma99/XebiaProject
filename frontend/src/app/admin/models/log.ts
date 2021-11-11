export class Log {
    constructor(
        public logId: number,
        public userId: number,
        public logType: string,
        public userType: string,
        public date: Date
    ){}
}
