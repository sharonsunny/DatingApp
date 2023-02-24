import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

@Input() userFromHomeComponent:any;
@Output() cancelRegister=new EventEmitter();
ngOnInit(): void {
}
model:any={}
constructor(private accountService :AccountService){

}

register(){
  this.accountService.register(this.model).subscribe({
    next: response =>{
      console.log(response);
      this.cancel();
    },
    error: error =>console.log(error)
    
  })
}
cancel(){
  this.cancelRegister.emit(false);
}
}