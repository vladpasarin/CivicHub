export class RequestResponse {

    id: string;
    mail: string;
    token: string;
    constructor(input?: any) {
        Object.assign(this, input);
    }
}
