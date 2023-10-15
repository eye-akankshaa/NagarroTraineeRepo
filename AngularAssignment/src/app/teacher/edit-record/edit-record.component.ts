import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { StudentService } from 'src/app/service/student.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CoreService } from 'src/app/service/core.service';


@Component({
  selector: 'add-edit-record',
  templateUrl: './edit-record.component.html',
  styleUrls: ['./edit-record.component.css']
})
export class EditRecordComponent implements OnInit{
  stdForm: FormGroup;

  constructor(private _fb: FormBuilder,
    private _stdService: StudentService,
    private _dialogRef: MatDialogRef<EditRecordComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _coreService: CoreService) {
    this.stdForm = this._fb.group({
      rollNo: ['',Validators.required],
      name: '',
      dob: '',
      score: '',
    });
  }
  ngOnInit(): void {
    this.stdForm.patchValue(this.data);
  }
  

  onFormSubmit() {
    if (this.stdForm.valid) {
        this._stdService.updateStudent(this.data.id,this.stdForm.value).subscribe({
          next: (val: any) => {
            this._coreService.openSnackBar('Record Updated Successfully','Close');
            this._dialogRef.close(true);
          },
          error: (err: any) => {
            console.log(err);
          }
        }); 
    }
  }
}
