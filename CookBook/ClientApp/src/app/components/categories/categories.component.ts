import { Component } from "@angular/core";
import { Observable } from "rxjs";
import { Category } from "src/app/model/category";
import { CategoryService } from "src/app/services/category.service";

@Component({
  selector: "app-categories",
  templateUrl: "./categories.component.html",
  styleUrls: ["./categories.component.css"],
})
export class CategoriesComponent {
  categories$: Observable<Category[]>;

  constructor(categoryService: CategoryService) {
    this.categories$ = categoryService.getAll();
  }
}
