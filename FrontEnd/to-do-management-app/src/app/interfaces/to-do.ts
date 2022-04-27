export interface ToDo 
{
    id : number,
    description:String,
    status:ToDoStatus
}

export enum ToDoStatus
{
    Pending = 1,
    Completed = 2
}