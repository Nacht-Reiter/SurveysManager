import { Injectable } from '@angular/core';
import { ApiService, RequestMethod } from './api.service';
import { Observable } from 'rxjs';
import { PlateSurvey } from '../models/plate-survey';
import { Survey } from '../models/survey';
import { Question } from '../models/question';

@Injectable({
  providedIn: 'root'
})
export class SurveysService {

  constructor(private api : ApiService) { }

  getAll() : Observable<Array<PlateSurvey>> {
    return this.api.sendRequest(RequestMethod.Get, `surveys`, undefined);
  }

  getById(id: number) : Observable<Survey> {
    return this.api.sendRequest(RequestMethod.Get, `survey/${id}`, undefined);
  }

  getAllQuestions(id: number) : Observable<Array<Question>> {
    return this.api.sendRequest(RequestMethod.Get, `survey/${id}`, undefined);
  }

  create(survey: Survey) : Observable<Survey> {
    return this.api.sendRequest(RequestMethod.Post, `survey`, survey);
  }

  addQuestion(id: number, question: Question){
    return this.api.sendRequest(RequestMethod.Post, `survey/${id}`, question);
  }

  update(survey: Survey, id: number) : Observable<Survey> {
    return this.api.sendRequest(RequestMethod.Put, `survey/${id}`, survey);
  }

  delete(id: number) : Observable<Survey> {
    return this.api.sendRequest(RequestMethod.Delete, `survey/${id}`, undefined);
  }

  removeQuestions(id: number) : Observable<Survey> {
    return this.api.sendRequest(RequestMethod.Delete, `surveyquestions/${id}`, undefined);
  }
}
