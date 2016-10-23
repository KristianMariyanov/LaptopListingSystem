import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import '../rxjs-operators'

import { BaseAdministrationService } from './base-administration.service';
import { LaptopDetails } from "../../laptop-details";

@Injectable()
export class LaptopsService extends BaseAdministrationService {
    private baseLaptopsUrl = 'api/administration/laptops';

    constructor(public http: Http) { super(http); }

    getLaptops(): Observable<any> {
        return this.getAll(this.baseLaptopsUrl);
    }

    getDropdownItems(): Observable<any> {
        return this.getAll(`${this.baseLaptopsUrl}/getdropdownitems`);
    }

    addLaptop(
        model: string,
        manufacturerId: number,
        imageUrl: string,
        price: number,
        ram: number,
        weight: number,
        description: string,
        additionalParts: string,
        hardDisk: number,
        monitor: number): Observable<any> {
            let headers = this.getAuthorizationHeader();
            headers.append('Content-Type', 'application/json');
            let options = new RequestOptions({ headers: headers });
            let data = {
                model: model,
                manufacturerId: manufacturerId,
                imageUrl: imageUrl,
                price: price,
                ram: ram,
                weight: weight,
                description: description,
                additionalParts: additionalParts,
                hardDisk: hardDisk,
                monitor: monitor
            }
            return this.http.post(this.baseLaptopsUrl, data, options)
                .catch(this.handleError);
    }

    deleteLaptop(laptopId: number): Observable<any> {
        return this.delete(`${this.baseLaptopsUrl}/${laptopId}`);
    }

    getLaptop(laptopId: number): Observable<any> {
        return this.get(`${this.baseLaptopsUrl}/${laptopId}`);
    }

    updateLaptop(
        id: number,
        model: string,
        manufacturerId: number,
        imageUrl: string,
        price: number,
        ram: number,
        weight: number,
        description: string,
        additionalParts: string,
        hardDisk: number,
        monitor: number): Observable<any> {
            let headers = this.getAuthorizationHeader();
            headers.append('Content-Type', 'application/json');
            let options = new RequestOptions({ headers: headers });
            let data = {
                id: id,
                model: model,
                manufacturerId: manufacturerId,
                imageUrl: imageUrl,
                price: price,
                ram: ram,
                weight: weight,
                description: description,
                additionalParts: additionalParts,
                hardDisk: hardDisk,
                monitor: monitor
            }
            return this.http.put(this.baseLaptopsUrl, data, options)
                .catch(this.handleError);
    }
}