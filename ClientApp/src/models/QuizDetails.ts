export class QuizDetails {
    public id?: number
    public name?: string
    public createdAt?: Date
    public modifiedAt?: Date
    public questions?: Question[]
}

export class Question {
    public text?: string
    public answerOptions?: AnswerOption[]
    public expanded: boolean = false
}

export class AnswerOption {
    public text?: string
    public isCorrectAnswer?: boolean
}
  