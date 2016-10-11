import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Laptop } from "../laptop";
import { LaptopDetails } from "../laptop-details";
import { Observable } from 'rxjs/Observable';
import './rxjs-operators';

@Injectable()
export class LaptopService {
    private laptopsUrl = 'api/laptops/';
    private laptopDetailsUrl = 'api/laptops/';

    constructor(private http: Http) {}

    getLaptops(): Observable<Laptop[]> {
        return this.http.get(this.laptopsUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getLaptop(id: number): Observable<LaptopDetails> {
        return this.http.get(this.laptopsUrl + id)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body;
    }

    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}