export class Product {
  
  constructor(id: number, name: string, price: number,categoryId:number, description:string) {
    this.id = id ;
    this.name = name;
    this.price = price;
    this.categoryId = categoryId;
    this.description = description;
  }
    id: number;
    name: string;
    price: number;
    categoryId: number;
    description: string;
  }