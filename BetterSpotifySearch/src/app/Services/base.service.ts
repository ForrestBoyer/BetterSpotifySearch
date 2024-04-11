import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Injectable } from "@angular/core";

@Injectable()
export class BaseService {
    constructor(protected http: HttpClient) { }

    protected getUrl(url: string) {
        return environment.baseUrl + url;
      }
}
