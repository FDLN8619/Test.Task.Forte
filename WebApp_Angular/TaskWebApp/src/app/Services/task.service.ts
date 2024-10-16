import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

export interface Task{
  id: number,
  tittle: string,
  description: string,
  eStatus: number,
  eStatusString: string,
  createDate: string
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  // se agrega la ruta de la API
  private readonly API ='http://localhost:5232/'

  // se Inyecta HTTPCliet
  constructor(private readonly http:HttpClient) { }

  //** Se Agregan Peticiones (Get,Post,Put,Delete) */
  addNewTask(task:Task):Observable<Task>{
    return this.http.post<Task>(`${this.API}api/Task/InsTask`,task)
  }
  getTask():Observable<Task[]>{
    return this.http.get<Task[]>(`${this.API}api/Task/GetTasks`)
  }
  getTaskById(id:number):Observable<Task>{
    return this.http.get<Task>(`${this.API}api/Task/GetTaskById?id=${id}`)
  }
  updateTask(task:Task): Observable<Task>{
    //const body ={}
    return this.http.put<Task>(`${this.API}api/Task/UpdTask`,task)
  }
  deleteTask(id:number): Observable<void>{
    return this.http.delete<void>(`${this.API}api/Task/DelTask?id=${id}`)
  }
}
