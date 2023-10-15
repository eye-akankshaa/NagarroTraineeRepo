import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { CoreService } from 'src/app/service/core.service';
import { StudentService } from 'src/app/service/student.service';
import { EditRecordComponent } from '../edit-record/edit-record.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-records',
  templateUrl: './records.component.html',
  styleUrls: ['./records.component.css']
})
export class RecordsComponent implements OnInit {
  displayedColumns: string[] = ['rollNo', 'name', 'dob', 'score', 'action'];
  dataSource!: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  ngOnInit(): void {
    this.getStudentsList();
    if(this._coreService.getUser()===null){
      this.router.navigate(["teacher/login"])
    }

  }

  constructor(private _dialog: MatDialog, 
    private _stdService: StudentService,
    private _coreService: CoreService,
    private router: Router
    ) { }
  

  logOut(){
    this.router.navigate(['logout']);
    this._coreService.openSnackBar('Logout Successfully','Close');
  }

  getTotalStudent(){
    return this.dataSource?.data?.length||0;
  }
  getStudentsList(){
    this._stdService.getStudentList().subscribe({
      next:(res)=>{
        this.dataSource = new MatTableDataSource(res);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: console.log,
    });
  }


  deleteStudent(id: number){
    this._stdService.deleteStudent(id).subscribe({
      next: (res: any) => {
        this._coreService.openSnackBar('Student Deleted Successfully','Close');
        this.getStudentsList();
      },
      error: (err: any) => {
        console.log(err);
      }
    })
  }

  openEditForm(data: any){
    const dialogRef = this._dialog.open(EditRecordComponent,{
      data,
    });
    dialogRef.afterClosed().subscribe({
      next:(val)=>{
        this.getStudentsList();
      }
    });
    
  }
}
