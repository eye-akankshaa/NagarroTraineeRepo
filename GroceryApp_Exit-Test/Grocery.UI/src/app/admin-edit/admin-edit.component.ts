import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ProductService } from '../services/product.service';

interface Product {
  productId:number;
  productName: string;
  description: string;
  category: string;
  quantity: number;
  price: number;
  discount: number;
  specification: string;
  data: string;
}
@Component({
  selector: 'app-admin-edit',
  templateUrl: './admin-edit.component.html',
  styleUrls: ['./admin-edit.component.css']
})
export class AdminEditComponent implements OnInit {
  displayMsg: string='';
  isProductAdded: boolean=false;
  // productForm!: FormGroup;
  selectedFile!: File|null;
  public imageError:string ='';
  public fileArray: Blob[] = [];
  readonly selectImageError: string= 'Please select image';
  readonly typeImageError:string='Only jpeg,jpg and png image are allowed';
  readonly validImageTypes = ['image/jpg', 'image/jpeg', 'image/png']
  constructor(private formBuilder: FormBuilder, private http: HttpClient,private productService:ProductService,private router:Router,private route:ActivatedRoute) {}
   
  //image selection 
  onFileSelected(event: any) {
    
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

    this.updatedProductForm = this.formBuilder.group({
      productName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100), Validators.pattern("[a-zA-Z]{2}.*")]],
      description: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(255), Validators.pattern("[a-zA-Z].*")]],
      category: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100), Validators.pattern("[a-zA-Z].*")]],
      quantity: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      price: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      discount: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      specification: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100), Validators.pattern("[a-zA-Z].*")]],
    });
    

    let strProductId = this.route.snapshot.paramMap.get('id');

    this.productId = Number(strProductId);

    this.getProduct(this.productId);
  }

  //for inserting image testing purpose
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

  // productForm = new FormGroup({
  //   productName: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z]{2}.*")]),
  //   description: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(255),Validators.pattern("[a-zA-Z].*")]),
  //   category: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z].*")]),
  //   quantity: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
  //   price: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
  //   discount: new FormControl("",[Validators.required, Validators.pattern("^[0-9]*$")]),
  //   specification: new FormControl("",[Validators.required,Validators.minLength(2),Validators.maxLength(100),Validators.pattern("[a-zA-Z].*")]),
  // });


  onSubmit() {
    if(this.selectedFile){
    this.productService.updateProduct([
      this.updatedProductForm.value.productName??"",
      this.updatedProductForm.value.description??"",
      this.updatedProductForm.value.category??"",
      this.updatedProductForm.value.quantity??"",
      this.updatedProductForm.value.price??"",
      this.updatedProductForm.value.discount??"",
      this.updatedProductForm.value.specification??"",
      this.source
    ])
    .subscribe(res => {
      if(res="Success")
      {
        this.displayMsg='Proudct Added Successfully';
        this.isProductAdded=true;
        
      }
      else if(res = 'Already Exist')
          {
            this.displayMsg='Product Already exist! try another';
            this.isProductAdded=false;
          }
      else{
        this.displayMsg='Something went wrong';
        this.isProductAdded=false;
      }
    }); 
  }
  else
   this.imageError = this.selectImageError;
  }

 // ...

get ProductName(): FormControl {
  return this.updatedProductForm.get("productName") as FormControl;
}

get Description(): FormControl {
  return this.updatedProductForm.get("description") as FormControl;
}

get Category(): FormControl {
  return this.updatedProductForm.get("category") as FormControl;
}

get Quantity(): FormControl {
  return this.updatedProductForm.get("quantity") as FormControl;
}

get Price(): FormControl {
  return this.updatedProductForm.get("price") as FormControl;
}

get Discount(): FormControl {
  return this.updatedProductForm.get("discount") as FormControl;
}

get Specification(): FormControl {
  return this.updatedProductForm.get("specification") as FormControl;
}

updatedProductForm!:FormGroup

ProductToBeEdited!:Product

productId = 0;

getProduct(id:number)
  {
    this.productService.findProduct(id).subscribe({
      next: (temp) => {
        this.ProductToBeEdited = temp;
 
        // Prefilling the fields with the old details
      console.log(this.ProductToBeEdited)
        this.updatedProductForm.patchValue({

          productName: this.ProductToBeEdited.productName,

          description: this.ProductToBeEdited.description,

          quantity: this.ProductToBeEdited.quantity,

          price: this.ProductToBeEdited.price,

          discount: this.ProductToBeEdited.discount,

          specification: this.ProductToBeEdited.specification,

          // image: this.ProductToBeEdited.image,

          category: this.ProductToBeEdited.category

        });
      },

      error: (res) => {
        console.log(res);

      }

    });
 
  }

  

  updateProduct()
  {
    this.ProductToBeEdited.productName = this.updatedProductForm.value.productName;

    this.ProductToBeEdited.description = this.updatedProductForm.value.description;

    this.ProductToBeEdited.quantity = this.updatedProductForm.value.quantity;

    this.ProductToBeEdited.price = this.updatedProductForm.value.price;

    this.ProductToBeEdited.discount = this.updatedProductForm.value.discount;

    this.ProductToBeEdited.specification = this.updatedProductForm.value.specification;

    // this.ProductToBeEdited.image = this.updatedProductForm.value.image;

    this.ProductToBeEdited.category = this.updatedProductForm.value.category;



    this.productService.updateProduct(this.ProductToBeEdited).subscribe({
      next: (res) => {
        alert(res.message);
        // this.router.navigate(['adminHome']);
        this.router.navigate(['admin', 'admin-modification']);
      },
      error: (err) => alert(err?.error.message)
    });

  }

}
