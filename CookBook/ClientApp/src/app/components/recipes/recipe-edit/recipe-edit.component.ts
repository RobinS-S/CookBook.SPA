import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { filter, Observable, switchMap, take, tap } from "rxjs";
import { Category } from "src/app/model/category";
import { IngredientEntry } from "src/app/model/ingredient-entry";
import { PreparationStep } from "src/app/model/preparationstep";
import { Recipe } from "src/app/model/recipe";
import { CategoryService } from "src/app/services/category.service";
import { RecipeService } from "src/app/services/recipe.service";
import { ToastService } from "src/app/services/toast.service";

@Component({
  selector: "app-recipe-edit",
  templateUrl: "./recipe-edit.component.html",
})
export class RecipeEditComponent {
  categories$: Observable<Category[]>;
  recipe$ = this.activatedRoute.params.pipe(
    filter(({ id }) => id),
    switchMap(({ id }) => this.recipeService.getById(id as number)),
    tap(user => {
      this.form.setValue(user);
      this.currentEditingIngredient = -1;
      this.currentEditingStep = -1;
      this.categoryAddForm.reset();
      this.ingredientAddForm.reset();
      this.preparationStepForm.reset();
      this.preparationStepForm.patchValue({
        position: user.preparation.length + 1,
      });
    })
  );

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    title: new FormControl(null, [Validators.required]),
    description: new FormControl(null, [Validators.required]),
    suitableFor: new FormControl(1, [Validators.required]),
    categoryIds: new FormControl([]),
    ingredientEntries: new FormControl([]),
    preparation: new FormControl([]),
  });

  categoryAddForm: FormGroup = new FormGroup({
    categoryId: new FormControl(-1),
  });

  ingredientAddForm: FormGroup = new FormGroup({
    product: new FormControl(null, [Validators.required]),
    quantity: new FormControl(1, [Validators.required]),
    unit: new FormControl(null),
  });
  currentEditingIngredient: number = -1;

  preparationStepForm: FormGroup = new FormGroup({
    position: new FormControl(null, [Validators.min(1)]),
    description: new FormControl(""),
  });
  currentEditingStep: number = -1;

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private recipeService: RecipeService,
    private toastService: ToastService,
    categoryService: CategoryService
  ) {
    this.categories$ = categoryService.getAll();
  }

  save(): void {
    if (this.form.valid) {
      const recipe = { ...this.form.value } as Recipe;

      if (recipe.id === null) {
        this.recipeService
          .create(recipe)
          .pipe(take(1))
          .subscribe({
            next: r => {
              this.toastService.showSuccess(
                "Recipe created",
                `Recipe '${r.title}' was created!`
              );
              this.router.navigate([`recipes/${r.id}`]);
              this.recipeService.refreshAll();
            },
            error: () => {
              this.toastService.showError(
                "Error",
                `Recipe '${recipe.title}' could not be saved.`
              );
            },
          });
      } else {
        this.recipeService
          .update(recipe)
          .pipe(take(1))
          .subscribe({
            next: r => {
              this.toastService.showSuccess(
                "Recipe created",
                `Recipe '${r.title}' was updated!`
              );
              this.router.navigate([`recipes/${r.id}`]);
              this.recipeService.refreshAll();
            },
            error: () => {
              this.toastService.showError(
                "Error",
                `Recipe '${recipe.title}' could not be updated.`
              );
            },
          });
      }
    }
  }

  remove(id: number): void {
    this.recipeService
      .delete(id)
      .pipe(take(1))
      .subscribe({
        next: wasDeleted => {
          if (!wasDeleted) {
            this.toastService.showError(
              "Error",
              "Recipe could not be removed."
            );
            return;
          }

          this.toastService.showSuccess(
            "Recipe removed",
            "Recipe was removed."
          );
          this.router.navigate(["recipes/"]);
          this.recipeService.refreshAll();
        },
        error: () => {
          this.toastService.showError("Error", "Recipe could not be removed.");
        },
      });
  }

  addCategory(): void {
    const value = Number.parseInt(this.categoryAddForm.value.categoryId, 10);
    if (value >= 0 && !this.form.value.categoryIds.includes(value)) {
      this.form.value.categoryIds.push(value);
    }
    this.categoryAddForm.reset();
  }

  removeCategory(id: number): void {
    const idx = this.form.controls.categoryIds.value.indexOf(id);
    if (id >= 0) {
      this.form.controls.categoryIds.value.splice(idx, 1);
    }
  }

  saveIngredient(): void {
    if (this.ingredientAddForm.invalid) {
      return;
    }

    const ingredient = this.ingredientAddForm.value as IngredientEntry;

    if (this.currentEditingIngredient !== -1) {
      this.form.controls.ingredientEntries.value[
        this.currentEditingIngredient
      ] = ingredient;
      this.currentEditingIngredient = -1;
    } else {
      this.form.controls.ingredientEntries.value.push(ingredient);
    }
    this.ingredientAddForm.reset();
  }

  removeIngredient(idx: number): void {
    if (idx >= 0) {
      this.form.controls.ingredientEntries.value.splice(idx, 1);
    }
  }

  savePreparationStep(): void {
    if (this.preparationStepForm.invalid) {
      return;
    }

    const preparationStep = {
      position: this.preparationStepForm.value.position,
      description: this.preparationStepForm.value.description,
    } as PreparationStep;

    if (this.currentEditingStep !== -1) {
      this.form.controls.preparation.value[this.currentEditingStep] =
        preparationStep;
      this.currentEditingStep = -1;
    } else {
      this.form.controls.preparation.value.push(preparationStep);
    }
    this.preparationStepForm.reset();
    this.preparationStepForm.patchValue({
      position: this.form.value.preparation.length + 1,
    });
  }

  removePreparationStep(idx: number): void {
    if (idx >= 0) {
      this.form.controls.preparation.value.splice(idx, 1);
      this.currentEditingStep = -1;
      this.preparationStepForm.reset();
      this.preparationStepForm.patchValue({
        position: this.form.value.preparation.length + 1,
      });
    }
  }

  editPreparationStep(idx: number): void {
    if (idx === this.currentEditingStep) {
      this.preparationStepForm.reset();
      this.currentEditingStep = -1;
      return;
    }
    this.currentEditingStep = idx;
    this.preparationStepForm.setValue(
      this.form.controls.preparation.value[idx]
    );
  }

  editIngredient(idx: number): void {
    if (idx === this.currentEditingIngredient) {
      this.ingredientAddForm.reset();
      this.currentEditingIngredient = -1;
      return;
    }
    this.currentEditingIngredient = idx;
    this.ingredientAddForm.setValue(
      this.form.controls.ingredientEntries.value[idx]
    );
  }
}
