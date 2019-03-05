import { Survey } from "./survey";
import { Answer } from "./answer";

export interface Question {
    id: number;
    title: string;
    questionText: string;
    comment: string;
    survey: Survey;
    answers: Array<Answer>;
}
