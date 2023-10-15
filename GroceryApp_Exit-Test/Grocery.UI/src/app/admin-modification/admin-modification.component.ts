import { HttpClient } from '@angular/common/http';
import { compileNgModule } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { ProductService } from '../services/product.service';
import { FormBuilder, FormGroup } from '@angular/forms';

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
  selector: 'app-admin-modification',
  templateUrl: './admin-modification.component.html',
  styleUrls: ['./admin-modification.component.css']
})
export class AdminModificationComponent implements OnInit {
  products: Product[] = [];
  displayedProducts: Product[] = [];
  currentPage: number = 1;
  pageSize: number = 4;
  totalItems: number = 0;
  totalPages: number = 0;
  pages: number[] = [];
  searchTerm: string = '';
  selectedCategory: string = 'All';
  fg!: FormGroup;
  searchQuery: string = "";
  filteredData = this.products;
  Categories:string[]=[];

  constructor(private productService: ProductService,private router:Router,private http:HttpClient,private fb:FormBuilder) {}

  ngOnInit() {
    this.fetchProducts();

    this.fg = this.fb.group({

      search: ['']

    })
  }
   
  // fetchProducts(): void {
  //   this.productService.getProducts().subscribe(
  //     (data: any) => {
  //       console.log(data);
  //       this.products = data;
  //       this.totalItems = this.products.length;
  //       this.totalPages = Math.ceil(this.totalItems / this.pageSize);
  //       this.updateDisplayedProducts();
  //       this.updatePages();
  //     },
  //     (error) => {
  //       console.error(error);
  //     }
  //   );
  // }
  
  fetchProducts(): void {
    this.productService.getProducts().subscribe(
      (data: any) => {
        this.products = data;
        const distinctCategories = [...new Set(this.products.map(product => product.category))];

        this.Categories = distinctCategories

        console.log(this.Categories);
        this.filterProducts("");
        this.totalItems = this.products.length;
        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
        this.updateDisplayedProducts();
        this.updatePages();
      },
      (error) => {
        console.error(error);
      }
    );
  }


  // filterProducts(category: string): void {
  //   this.selectedCategory = category;
  //   this.currentPage = 1;
  //   this.updateDisplayedProducts();
  //   this.updatePages();
  // }

  searchProducts(): void {
    this.currentPage = 1;
    this.updateDisplayedProducts();
    this.updatePages();
  }

  search() {

    this.filterProducts(this.fg.value.search)
  }

  filterProducts(temp: string) {
    this.searchQuery = temp;
    this.filteredData = this.products.filter(product => product.productName.toLowerCase().includes(this.searchQuery.toLowerCase()) || product.description.toLowerCase().includes(this.searchQuery.toLowerCase()) || product.category.toLowerCase().includes(this.searchQuery.toLowerCase()));

  }

  updateDisplayedProducts(): void {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    let filteredProducts = this.products;

    if (this.selectedCategory !== 'All') {
      filteredProducts = filteredProducts.filter((product) => product.category === this.selectedCategory);
    }

    if (this.searchTerm.trim() !== '') {
      filteredProducts = filteredProducts.filter((product) =>
        product.productName.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    }

    this.displayedProducts = filteredProducts.slice(startIndex, endIndex);
  }

  updatePages(): void {
    this.pages = [];
    for (let i = 1; i <= this.totalPages; i++) {
      this.pages.push(i);
    }
  }

  goToPage(page: number): void {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.updateDisplayedProducts();
    }
  }
  


  deleteProduct(id:number)
  {
    if (confirm("Do you really want to delete this product?"))
    {
      console.log("product id: "+id);
      this.productService.deleteProduct(id).subscribe({
        next: (res) => {
          alert(res.message);
          
        },
        error: (err) => {alert(err?.error.message)}
      })
    }
  }

  editProduct(id:number)
  {
    this.router.navigate(['/admin/edit',id]);
    
  }

  onCategoryChange(event: any) {

    const selectedValue = event.target.value;

    console.log("Selected value:", selectedValue);

    this.filterProducts(selectedValue);

  }
}
