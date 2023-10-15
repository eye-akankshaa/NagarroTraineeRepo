import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { ProductService } from '../services/product.service';
import { Route, Router } from '@angular/router';

export interface Product
{
  productId:number,
  productName:string,
  description:string,
  category:string,
  quantity:number,
  price:number,
  discount:number,
  specification:string,
  data: string
}
@Component({
  selector: 'app-admin-add-product',
  templateUrl: './admin-add-product.component.html',
  styleUrls: ['./admin-add-product.component.css']
})
export class AdminAddProductComponent implements OnInit {
  displayMsg: string='';
  isProductAdded: boolean=false;
  // productForm!: FormGroup;
  selectedFile!: File|null;
  public imageError:string ='';
  public fileArray: Blob[] = [];
  readonly selectImageError: string= 'Please select image';
  readonly typeImageError:string='Only jpeg,jpg and png image are allowed';
  readonly validImageTypes = ['image/jpg', 'image/jpeg', 'image/png']
  constructor(private formBuilder: FormBuilder, private http: HttpClient,private productService:ProductService,private router:Router) {}
   
  //image selection 
  onFileSelected(event: any) {
    debugger
    this.imageError ='';
    
    this.selectedFile = event.target.files[0];
    if(!this.validImageTypes.includes(this.selectedFile?.type??""))
    {
      this.imageError = this.typeImageError
      this.selectedFile = null;
    }
    else{
      if(this.selectedFile!==null){
      this.projectImage(this.selectedFile);
      }
    }
    debugger
  }

  source:string = '';
    projectImage(file: File) {
        let reader = new FileReader;
        // TODO: Define type of 'e'
        reader.onload = (e: any) => {
            // Simply set e.target.result as our <img> src in the layout
            this.source = e.target.result;
        };
        // This will process our file and get it's attributes/data
        reader.readAsDataURL(file);
    }

  ngOnInit() {
   
  }

  //for inserting image testin purpose
  uploadImage() {
    debugger
    if (this.selectedFile) {
      const uploadData = new FormData();
      uploadData.append('image', this.selectedFile, this.selectedFile.name);

      this.http.post<any>('https://localhost:44325/api//GroceryStore//AddProduct', uploadData).subscribe(
        response => {
          console.log('Image uploaded successfully');
        },
        error => {
          console.error('Error uploading image:', error);
        }
      );
    }
  }

  productForm = new FormGroup({
    productName: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z]{2}.*")]),
    description: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(255),Validators.pattern("[a-zA-Z].*")]),
    category: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z].*")]),
    quantity: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
    price: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
    discount: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
    specification: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z].*")]),
  });


  onSubmit() {
    debugger
    if(this.selectedFile){
    this.productService.addProduct([
      this.productForm.value.productName??"",
      this.productForm.value.description??"",
      this.productForm.value.category??"",
      this.productForm.value.quantity??"",
      this.productForm.value.price??"",
      this.productForm.value.discount??"",
      this.productForm.value.specification??"",
      this.source
    ])
    .subscribe(res => {
      if(res="Success")
      {
        this.displayMsg='Proudct Added Successfully';
        this.isProductAdded=true;
        alert("Product added Successfully");
        this.router.navigate(['admin/admin-modification']);
      }
      else if(res = 'Already Exist')
          {
            this.displayMsg='Product Already exist! try another';
            this.isProductAdded=false;
          }
      else{
        this.displayMsg='Something went wrong';
        this.isProductAdded=false;
        alert("Product not added");
      }
    }); 
  }
  else
   this.imageError = this.selectImageError;
  }

 // ...

get ProductName(): FormControl {
  return this.productForm.get("productName") as FormControl;
}

get Description(): FormControl {
  return this.productForm.get("description") as FormControl;
}

get Category(): FormControl {
  return this.productForm.get("category") as FormControl;
}

get Quantity(): FormControl {
  return this.productForm.get("quantity") as FormControl;
}

get Price(): FormControl {
  return this.productForm.get("price") as FormControl;
}

get Discount(): FormControl {
  return this.productForm.get("discount") as FormControl;
}

get Specification(): FormControl {
  return this.productForm.get("specification") as FormControl;
}
}
