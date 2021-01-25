import { Prize } from "./prize.model";
import { User } from "./user.model";

export class PrizeGiven {
    prizeId: string;
    prize: Prize;
    userId: string;
    user: User;
    dateGiven: Date;
    estimatedDelivery: Date;
    deliveryState: number;
    address: string;
    phoneNumber: string;
    constructor(input?: any) {
      Object.assign(this, input);
    }
}