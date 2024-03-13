import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";

export abstract class BaseService<T> {

    constructor(protected http: HttpClient) { }

    protected getUrl(url: string) {
        return environment.baseUrl + url;
      }
}
