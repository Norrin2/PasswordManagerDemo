import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PasswordCard } from '../models/password-card';

@Injectable({
  providedIn: 'root'
})
export class PasswordCardService {
  private baseUrl = 'http://localhost:5129/password-cards';

  constructor(private http: HttpClient) { }

  findAll(): Observable<PasswordCard[]> {
    return this.http.get<PasswordCard[]>(`${this.baseUrl}`);
  }

  findById(name: string): Observable<PasswordCard[]> {
    return this.http.get<PasswordCard[]>(`${this.baseUrl}/${name}`);
  }

  create(passwordCard: PasswordCard): Observable<PasswordCard> {
    return this.http.post<PasswordCard>(`${this.baseUrl}`, passwordCard);
  }

  update(id: string, passwordCard: PasswordCard): Observable<any> {
    return this.http.put(`${this.baseUrl}/${id}`, passwordCard);
  }

  delete(id: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
