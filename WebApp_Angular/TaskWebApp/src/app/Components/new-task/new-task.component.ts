import { Component, EventEmitter, Output, Input } from '@angular/core';
import { Task, TaskService } from 'src/app/Services/task.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-new-task',
  templateUrl: './new-task.component.html',
  styleUrls: ['./new-task.component.css']
})
export class NewTaskComponent {
  //se crean Outputs para emitir un evento al agregar un tarea y al cancelar para regresar a la ventana principal(del hijo al padre)
  @Output() clickTaskEvent = new EventEmitter<Task>
  @Output() clickCancelEvent =new EventEmitter<boolean>
  // se crea un input para setear el modelo desde el componente padre al hijo
  @Input() model:Task = {
    id:0,
    tittle:'',
    description:'',
    createDate:'',//new Date('2024-01-01'),
    eStatus:-1,
    eStatusString:''
  }
  //se injecta el servicio TaskService
  constructor(private readonly taskSvc: TaskService){}
  // se llama al metodo addNewTask del servicio para hacer la peticion a la  aPi
  addNewTask(task:Task):void{
    this.taskSvc.addNewTask(task)
  }
  // al guaradar los cambios en el formulario se valida si se tiene que actualizar o agregar una nueva tarea
  onSubmit(form:NgForm):void{
    this.model.eStatus = Number(this.model.eStatus)
    if(this.model.id > 0){
      this.taskSvc.updateTask(this.model).subscribe(res =>{
        if(res)
          this.clickCancelEvent.emit(false)
      })
    }else{
      this.taskSvc.addNewTask(this.model).subscribe(res =>{
        this.clickTaskEvent.emit(res)
      })
    }
  }
  //emite el evento de cancelar
  onCancel():void{
    this.clickCancelEvent.emit(false)
  }

}
