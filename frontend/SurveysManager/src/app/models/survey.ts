import { Question } from "./question";

export interface Survey {
    id: number;
    title: string;
    creator: string;
    views: number;
    date: Date;
    questions: Array<Question>
}
