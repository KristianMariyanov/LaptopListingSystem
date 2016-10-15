import { Laptop } from './laptop';

export class LaptopDetails extends Laptop {
    constructor(){super()}

    comments: string[];
    ram: number;
    weight: number;
    description: string;
    additionalParts: string;
    hardDisk: number;
    monitor: number;
    votesCount: number;
}