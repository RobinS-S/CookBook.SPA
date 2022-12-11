import { Component } from "@angular/core";
import { CategoryService } from "./services/category.service";
import { RecipeService } from "./services/recipe.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent {
  loading = false;

  constructor(categoryService: CategoryService, recipeService: RecipeService) {
    categoryService.refreshAll();
    recipeService.refreshAll();
  }
}
