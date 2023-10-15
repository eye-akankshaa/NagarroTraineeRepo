import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CoreService } from 'src/app/service/core.service';
import { StudentService } from 'src/app/service/student.service';

@Component({
  selector: 'app-result-search',
  templateUrl: './result-search.component.html',
  styleUrls: ['./result-search.component.css']
})
export class ResultSearchComponent implements OnInit{
  resultForm: FormGroup;
  showResult: boolean = false;
  student!: any;
  ngOnInit(): void {
    //this.student=JSON.parse(localStorage.getItem('studentRecord')||'[]');
  }
  constructor(
    private formBuilder: FormBuilder,
    private _studentService: StudentService,
    private _coreService: CoreService
  ) {
    this.resultForm = this.formBuilder.group({
      rollNo: '',
      dob: ''
    });
    this.showResult = false;
  }
  
  checkResult() {
    const rollNo = Number(this.resultForm.value.rollNo); //user enterd roll no
    const dob = new Date(this.resultForm.value.dob); //usr enterd date
    this._studentService.getStudentList().subscribe({
      //res m mere paas student list aayi
      next: (res: any) => {
        this.student = res.find((a: any) => {
          return a.rollNo === rollNo && new Date(a.dob).getTime() === dob.getTime();  
        })
        if (this.student) {
          this.showResult = true;
         // localStorage.setItem('studentRecord',JSON.stringify(this.student));
          //this.student=JSON.parse(localStorage.getItem('studentRecord')||'[]');
        }
        else {
          this._coreService.openSnackBar('Invalid Credentials', 'Close');
        }
      }, error: (err: any) => {
        this._coreService.openSnackBar('Something went wrong', 'Close');
      }
    });
  }
  closeResult() {
    this.showResult = false;
    //localStorage.setItem('studentRecord',JSON.stringify(null));
  }
}