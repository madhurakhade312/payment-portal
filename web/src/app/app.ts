import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit{
  
  http = inject(HttpClient);
  empList = signal<any[]>([])

  empObj: any = {
    "empId": 0,
    "empName": "",
    "empMobile": "",
    "empEmail": "",
    "city": "",
    "state": "",
    "address": ""
  }

  ngOnInit(): void {
    this.getAllEmployee();
  }

  getAllEmployee(){
    this.http.get("https://localhost:44327/api/Employee/GetEmployee").subscribe({
      next:(res:any) => {
        this.empList.set(res);
      }
    })
  }

  onEdit(data: any){
    this.empObj = {...data};
  }

  onReset(){
    this.empObj = {
      "empId": 0,
      "empName": "",
      "empMobile": "",
      "empEmail": "",
      "city": "",
      "state": "",
      "address": ""
    }
  }

  onUpdate(){
    this.http.put("https://localhost:44327/api/Employee/UpdateEmployee?id="+this.empObj.empId, this.empObj).subscribe({
      next:(res:any) => {
        alert("Employee Update");
        this.onReset();
        this.getAllEmployee()
      }
    })
  }

  onDelete(id: number){
    this.http.delete("https://localhost:44327/api/Employee/DeleteEmployee?id="+id, { responseType: 'text' }).subscribe({
      next:(res:any) => {
        alert("Employee Deleted");
        this.getAllEmployee()
      }
    })
  }

  onSaveEmp(){
    this.http.post("https://localhost:44327/api/Employee/CreateNewEmployee", this.empObj).subscribe({
      next:(res:any) => {
        alert("Employee Created");
        this.onReset();
        this.getAllEmployee()
      }
    })
  }
}
