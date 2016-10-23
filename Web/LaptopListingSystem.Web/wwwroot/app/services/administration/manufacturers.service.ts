import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import '../rxjs-operators'

import { BaseAdministrationService } from './base-administration.service';
import { Manufacturer } from "../../manufacturer";

@Injectable()
export class ManufacturersService extends BaseAdministrationService {
    private baseManufacturersUrl = 'api/administration/manufacturers';

    constructor(public http: Http) { super(http); }

    getManufacturers(): Observable<any> {
        return this.getAll(this.baseManufacturersUrl);
    }

    getDropdownItems(): Observable<any> {
        return this.getAll(`${this.baseManufacturersUrl}/getdropdownitems`);
    }

    addManufacturer(name: string): Observable<any> {
        return this.add(this.baseManufacturersUrl, `name=${name}`);
    }

    deleteManufacturer(manufacturerId: number): Observable<any> {
        return this.delete(`${this.baseManufacturersUrl}/${manufacturerId}`);
    }

    getManufacturer(manufacturerId: number): Observable<Manufacturer> {
        return this.get(`${this.baseManufacturersUrl}/${manufacturerId}`);
    }

    updateManufacturer(manufacturerId: number, name: string): Observable<any> {
        return this.update(this.baseManufacturersUrl, `name=${name}&manufacturerId=${manufacturerId}`);
    }
}