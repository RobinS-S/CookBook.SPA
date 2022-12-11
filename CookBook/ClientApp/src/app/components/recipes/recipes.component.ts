import { Component } from "@angular/core";
import { Observable } from "rxjs";
import { Recipe } from "src/app/model/recipe";
import { RecipeService } from "src/app/services/recipe.service";

@Component({
  selector: "app-recipes",
  templateUrl: "./recipes.component.html",
  styleUrls: ["./recipes.component.css"],
})
export class RecipesComponent {
  recipes$: Observable<Recipe[]>;

  constructor(recipesService: RecipeService) {
    this.recipes$ = recipesService.getAll();
  }
}
