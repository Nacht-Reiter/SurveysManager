import { Component, OnInit } from '@angular/core';
import { SurveysService } from '../services/surveys.service';
import { Survey } from '../models/survey';
import { ActivatedRoute } from '@angular/router';
import { Question } from '../models/question';
import { Answer } from '../models/answer';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-survey',
  templateUrl: './survey.component.html',
  styleUrls: ['./survey.component.css']
})
export class SurveyComponent implements OnInit {


  public survey: Survey;
  public newQuestion: Question;
  public newAnswer: Answer;
  constructor(private survaysService: SurveysService, private activatedRoute: ActivatedRoute,  private modalService: NgbModal) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      this.survaysService.getById(params.surveyId).subscribe((data: Survey) => {
          this.survey = data;
      });
    });
    this.refreshData();
  }

  onAdd(content){
    this.modalService.open(content);
  }

  onCreate(){
    this.survaysService.addQuestion(this.survey.id, this.newQuestion).subscribe((data: Survey) =>{
      this.survey = data;
      this.refreshData();
      this.modalService.dismissAll();
    })
  }

  onAddAnswer(){
    this.newQuestion.answers.push(this.newAnswer);
    this.newAnswer = {
      id: 0,
      answerText: ""
    };
  }

  refreshData() {
    this.newQuestion = {
      id: 0,
      title: "",
      questionText: "",
      comment: "",
      survey: undefined,
      answers: []
    };
    this.newAnswer = {
      id: 0,
      answerText: ""
    };

  }

}
