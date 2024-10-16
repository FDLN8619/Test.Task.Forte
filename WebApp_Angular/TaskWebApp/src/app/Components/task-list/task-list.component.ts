import { Component, OnInit } from '@angular/core';
import { Task, TaskService } from 'src/app/Services/task.service';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  taskFinded:Task = {
    id:0,
    tittle:'',
    description:'',
    createDate:'',//new Date('2024-01-01'),
    eStatus:-1,
    eStatusString:''
  }
  constructor(private readonly taskSvc: TaskService){}
  ngOnInit():void{
    this.getTasks()
  }
  formTask=false
  lstTask:Task[] = []
  //Obtenemos las tareas de la API
  getTasks():void{
    this.taskSvc.getTask()
    .subscribe(tasks => {
      this.lstTask = [...tasks]
    })
  }
  //Mostramos el componente de Agregar Tarea
  onShowFormNewTask(show:boolean): void{
    this.clearTaskFinded()
    this.formTask = show
    if(!show)this.getTasks()
  }
//Agerga una tarea a la lista
  addNewTask(task:Task):void{
    this.lstTask.push(task)
    this.formTask = false
  }
  // Ocultamos el componente de Editar/Agregar
  UpdTask():void{
    this.formTask = false
  }
  // se obtiene la inteface de Task desde la peticion de obtener la tarea en base al Id y despues se llena el modelo para que cargue los datos en el componente de agergar tarea
  onEdit(id:number):void{
    this.taskSvc.getTaskById(id)
    .subscribe(resp => {
      this.onShowFormNewTask(true)
      this.taskFinded = resp
      console.log('resp: ',resp)
      console.log('taskFinded: ',this.taskFinded)
    })
  }
  // elimina una Tarea(hace peticion a la aPI DELETE)
  onDelete(id:number):void{
    this.taskSvc.deleteTask(id)
    .subscribe(resp => {
      this.getTasks()
    })
  }
  // limpia el modelo para que lo limpie en el componente hijo(ageregar tarea)
  clearTaskFinded():void{
    this.taskFinded={
      id:0,
      tittle:'',
      description:'',
      createDate:'',//new Date('2024-01-01'),
      eStatus:-1,
      eStatusString:''
    }
  }

}
