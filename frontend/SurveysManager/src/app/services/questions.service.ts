import { Injectable } from '@angular/core';
import { ApiService, RequestMethod } from './api.service';
import { Observable } from 'rxjs';
import { Question } from '../models/question';

@Injectable({
  providedIn: 'root'
})
export class QuestionsService {

  constructor(private api : ApiService) { }

  getAll() : Observable<Array<Question>> {
    return this.api.sendRequest(RequestMethod.Get, `questions`, undefined);
  }

  getById(id: number) : Observable<Question> {
    return this.api.sendRequest(RequestMethod.Get, `question/${id}`, undefined);
  }

  create(question: Question) : Observable<Question> {
    return this.api.sendRequest(RequestMethod.Post, `question`, question);
  }

  update(question: Question, id: number) : Observable<Question> {
    return this.api.sendRequest(RequestMethod.Put, `question/${id}`, question);
  }

  delete(id: number) : Observable<Question> {
    return this.api.sendRequest(RequestMethod.Delete, `question/${id}`, undefined);
  }
}
