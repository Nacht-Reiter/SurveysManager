import { Component, OnInit } from '@angular/core';
import { SurveysService } from '../services/surveys.service';
import { PlateSurvey } from '../models/plate-survey';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Survey } from '../models/survey';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public surveys : PlateSurvey[];
  public newSurvey : Survey;

  constructor(private surveyService : SurveysService, private modalService: NgbModal) { }

  ngOnInit() {
    this.surveyService.getAll().subscribe((data: PlateSurvey[]) => {
      this.surveys = data;
    })
    this.refresh();
  }

  onAdd(content){
    this.modalService.open(content);
  }

  onCreate(){
    this.surveyService.create(this.newSurvey).subscribe(() =>{
      this.surveyService.getAll().subscribe((data: PlateSurvey[]) => {
        this.surveys = data;
        this.refresh();
      })
      this.modalService.dismissAll();
    });
  }

  refresh(){
    this.newSurvey = {
      id: 0,
      title: "",
      creator: "",
      views: 0,
      date: undefined,
      questions: []
    }
  }
}
