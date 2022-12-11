import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { RouterModule } from "@angular/router";

import { NavMenuComponent } from "src/app/components/nav-menu/nav-menu.component";
import { HomeComponent } from "src/app/components/home/home.component";
import { ApiAuthorizationModule } from "src/api-authorization/api-authorization.module";
import { AuthorizeGuard } from "src/api-authorization/authorize.guard";
import { AuthorizeInterceptor } from "src/api-authorization/authorize.interceptor";
import { NgbModule, NgbToastModule } from "@ng-bootstrap/ng-bootstrap";
import { CategoryEditComponent } from "./components/categories/category-edit/category-edit.component";
import { CategoriesComponent } from "./components/categories/categories.component";
import { CategoryService } from "./services/category.service";
import { AppComponent } from "./app.component";
import { ToastService } from "./services/toast.service";
import { ToastsComponent } from "./components/toasts/toasts.component";
import { RecipesComponent } from "./components/recipes/recipes.component";
import { RecipeEditComponent } from "./components/recipes/recipe-edit/recipe-edit.component";
import { RecipeService } from "./services/recipe.service";
import { GetByIdPipe } from "./pipe/get-by-id.pipe";
import { RecipeDetailComponent } from "./components/recipes/recipe-detail/recipe-detail.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CategoryEditComponent,
    CategoriesComponent,
    RecipesComponent,
    RecipeDetailComponent,
    RecipeEditComponent,
    ToastsComponent,
    GetByIdPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    NgbToastModule,
    RouterModule.forRoot([
      {
        path: "",
        component: HomeComponent,
        pathMatch: "full",
        title: "Home - CookBook",
      },
      {
        path: "categories",
        component: CategoriesComponent,
        title: "Categories - CookBook",
        children: [
          {
            path: "add",
            component: CategoryEditComponent,
            title: "Add category - CookBook",
            canActivate: [AuthorizeGuard],
          },
          {
            path: ":id/edit",
            component: CategoryEditComponent,
            title: "Edit category - CookBook",
            canActivate: [AuthorizeGuard],
          },
        ],
      },
      {
        path: "recipes",
        component: RecipesComponent,
        title: "Recipes - CookBook",
        children: [
          {
            path: "add",
            component: RecipeEditComponent,
            title: "Add recipe - CookBook",
            canActivate: [AuthorizeGuard],
          },
          {
            path: ":id",
            component: RecipeDetailComponent,
            title: "Recipe details - CookBook",
          },
          {
            path: ":id/edit",
            component: RecipeEditComponent,
            title: "Edit recipe - CookBook",
            canActivate: [AuthorizeGuard],
          },
        ],
      },
    ]),
    NgbModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthorizeInterceptor,
      multi: true,
    },
    CategoryService,
    RecipeService,
    ToastService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
