export class Signature {
    id: string;
    issueStateId: string;
    userId: string;
    mail?:string;
    name:string;
    dateSigned:Date;
    cnp:number;
    adresa:string;
    serieBuletin:string;
    numarBuletin:number;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}
  