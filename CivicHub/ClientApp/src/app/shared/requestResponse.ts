export class RequestResponse {

    mail: string;
    password: string;
    token: string;
    constructor(input?: any) {
        Object.assign(this, input);
    }
}
