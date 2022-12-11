import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, ReplaySubject, take } from "rxjs";
import { Recipe } from "../model/recipe";

@Injectable()
export class RecipeService {
  private recipe$: ReplaySubject<Recipe[]> = new ReplaySubject<Recipe[]>(1);

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {
    this.recipe$.next([]);
  }

  getAll() {
    return this.recipe$.asObservable();
  }

  refreshAll() {
    this.http
      .get<Recipe[]>(`${this.baseUrl}api/recipes`)
      .pipe(take(1))
      .subscribe({
        next: recipe => {
          this.recipe$.next(recipe);
        },
        error: error => {
          console.error(`HTTP request failure: ${error}`);
        },
      });
  }

  create(recipe: Recipe): Observable<Recipe> {
    return this.http.post<Recipe>(`${this.baseUrl}api/recipes`, recipe);
  }

  update(recipe: Recipe): Observable<Recipe> {
    return this.http.put<Recipe>(
      `${this.baseUrl}api/recipes/${recipe.id}`,
      recipe
    );
  }

  delete(recipeId: Number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.baseUrl}api/recipes/${recipeId}`);
  }

  getById(id: Number): Observable<Recipe> {
    return this.http.get<Recipe>(`${this.baseUrl}api/recipes/${id}`);
  }
}
