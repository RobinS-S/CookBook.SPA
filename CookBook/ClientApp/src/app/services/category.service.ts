import { HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable, ReplaySubject, take } from "rxjs";
import { Category } from "../model/category";

@Injectable()
export class CategoryService {
  private categories$: ReplaySubject<Category[]> = new ReplaySubject<
    Category[]
  >(1);

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") private baseUrl: string
  ) {
    this.categories$.next([]);
  }

  getAll() {
    return this.categories$.asObservable();
  }

  refreshAll() {
    this.http
      .get<Category[]>(`${this.baseUrl}api/categories`)
      .pipe(take(1))
      .subscribe({
        next: categories => {
          this.categories$.next(categories);
        },
        error: error => {
          console.error(`HTTP request failure: ${error}`);
        },
      });
  }

  create(category: Category): Observable<Category> {
    return this.http.post<Category>(`${this.baseUrl}api/categories`, category);
  }

  update(category: Category): Observable<Category> {
    return this.http.put<Category>(
      `${this.baseUrl}api/categories/${category.id}`,
      category
    );
  }

  delete(categoryId: Number): Observable<boolean> {
    return this.http.delete<boolean>(
      `${this.baseUrl}api/categories/${categoryId}`
    );
  }

  getById(id: Number): Observable<Category> {
    return this.http.get<Category>(`${this.baseUrl}api/categories/${id}`);
  }
}
