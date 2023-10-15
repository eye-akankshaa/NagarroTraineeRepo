import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { map, of } from 'rxjs';
import { CoreService } from 'src/app/service/core.service';
import { StudentService } from 'src/app/service/student.service';

@Component({
  selector: 'app-add-record',
  templateUrl: './add-record.component.html',
  styleUrls: ['./add-record.component.css']
})
export class AddRecordComponent implements OnInit {
  addRecordsForm!: FormGroup
  constructor(private formBuilder: FormBuilder, 
    private router: Router,
    private _stdService: StudentService, 
    private _coreService: CoreService) { }

  ngOnInit(): void {
    this.addRecordsForm = this.formBuilder.group({
      rollNo: [''],
      name: [''],
      dob: [''],
      score: ['']

    })
  }

  addRecords() {
    const rollNo=this.addRecordsForm.value.rollNo;
    this.checkRollNoUniqueness(rollNo).subscribe((isUnique: boolean)=>{
      if(!isUnique){
        this.addRecordsForm.get('rollNo')?.setErrors({notUnique:true});
        this._coreService.openSnackBar('rollno not unique', 'Close');
      }else{
        this._stdService.addStudent(this.addRecordsForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Record Added Successfully', 'Close');
            this.router.navigate(["teacher/records"]);
          },
          error: (err: any) => {
            console.log(err);
          }
        });
      }
    });
    
  }

  checkRollNoUniqueness(rollNo: any) {
    return this._stdService.getStudentList().pipe(
      map((res: any) => {
        return !res.find((a: any) => {
          return a.rollNo === rollNo;
        });
      })
    );
  }

}
