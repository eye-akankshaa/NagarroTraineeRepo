import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ChangeDetectorRef, } from '@angular/core';
import { ProductService } from '../services/product.service';
import { User } from '../Models/User';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

interface Product {
  productId: number;
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
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
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

  constructor(private productService: ProductService, private authService: AuthService, private router: Router,private fb:FormBuilder) { }
  currentUserEmail = "";
  currentUserName = "";
  ngOnInit() {
    this.currentUserEmail = this.authService.currentUserEmail;
    this.fetchProducts();
    
    this.fg = this.fb.group({

      search: ['']

    })

    

  }

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

  onProductDetails(id: number) {

    console.log("we are on product details page")
    if(this.authService.isUserLogin)
    this.router.navigate(['product-details', id]);
    else
    this.router.navigate(['product-details-logout', id]);
  }

  onCategoryChange(event: any) {

    const selectedValue = event.target.value;

    console.log("Selected value:", selectedValue);

    this.filterProducts(selectedValue);

  }
}
