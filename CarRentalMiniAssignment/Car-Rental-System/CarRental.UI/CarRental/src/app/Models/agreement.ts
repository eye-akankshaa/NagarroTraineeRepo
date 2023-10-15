export interface Agreement {
   agreementId:number;
    userId: string;
    vehicleId: string;
   maker: string;
   model: number;
   startDate:Date;
   endDate:Date;
   rentalDuration: number;
   totalDuration: number;
   isReturnRequired: boolean;
  }