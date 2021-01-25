export class Prize {
    id: string;
    name: string;
    description: string;
    price: number;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}