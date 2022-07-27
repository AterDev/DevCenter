import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  constructor(
    private http: HttpClient
  ) { }

  async canAccess(url: string): Promise<boolean> {
    const response = await lastValueFrom(this.http.get(url));
    console.log(response);

    return true;
  }
}
