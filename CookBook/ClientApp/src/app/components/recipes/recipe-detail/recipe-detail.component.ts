import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { filter, Observable, switchMap } from "rxjs";
import { AuthorizeService } from "src/api-authorization/authorize.service";
import { Category } from "src/app/model/category";
import { CategoryService } from "src/app/services/category.service";
import { RecipeService } from "src/app/services/recipe.service";

@Component({
  selector: "app-recipe-detail",
  templateUrl: "./recipe-detail.component.html",
})
export class RecipeDetailComponent implements OnInit {
  categories$: Observable<Category[]>;
  recipe$ = this.activatedRoute.params.pipe(
    filter(({ id }) => id),
    switchMap(({ id }) => this.recipeService.getById(id as number))
  );

  constructor(
    private activatedRoute: ActivatedRoute,
    private recipeService: RecipeService,
    categoryService: CategoryService
  ) {
    this.categories$ = categoryService.getAll();
  }

  ngOnInit(): void {}

  sendMail(title: string) {
    const url = `mailto:friend@gmail.com?subject=I%20found%20a%20nice%20recipe%20on%20CookBook%3A%20${title}&body=I%20found%20a%20nice%20recipe%20on%20CookBook%2C%20${title}%0D%0AYou%20can%20find%20it%20here%3A%20${window.location.href}`;
    window.open(url);
  }
}
