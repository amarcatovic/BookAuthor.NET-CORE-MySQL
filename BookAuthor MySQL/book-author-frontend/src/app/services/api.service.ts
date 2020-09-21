import { Injectable } from '@angular/core';
import { rejects } from 'assert';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private url: string = 'https://localhost:44306/api/';

  constructor(private toastr: ToastrService) { }

  async get(resource: string): Promise<any>{
    return await fetch(`${this.url}${resource}`)
      .then(response => {
        if(response.status !== 200){
          this.toastr.error(`Unable to get ${resource}`);
        } else{
          return response.json();
        }
      });
  }

  async post(resource: string, data: any): Promise<any>{
    
    const promise = new Promise((resolve, reject) => {
      fetch(`${this.url}${resource}`, {
        method: 'POST',
        body: JSON.stringify(data),
        headers: {
          'Content-Type': 'application/json'
        },
      })
      .then(res => {
        if(res.status === 201){
          resolve(true);
        } else{
          resolve(false);
        }
      });
    });

    return promise;
  }
}
