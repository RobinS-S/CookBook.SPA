import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { filter, switchMap, take, tap } from "rxjs";
import { Category } from "src/app/model/category";
import { CategoryService } from "src/app/services/category.service";
import { ToastService } from "src/app/services/toast.service";

@Component({
  selector: "app-category-edit",
  templateUrl: "./category-edit.component.html",
})
export class CategoryEditComponent implements OnInit {
  category$ = this.activatedRoute.params.pipe(
    filter(({ id }) => id),
    switchMap(({ id }) => this.categoryService.getById(id as Number)),
    tap(user => {
      this.form.setValue(user);
    })
  );

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl(null, [Validators.required]),
    description: new FormControl(null),
  });

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private categoryService: CategoryService,
    private toastService: ToastService
  ) {}

  ngOnInit(): void {}

  save(): void {
    if (this.form.valid) {
      const category = { ...this.form.value } as Category;

      if (category.id === null) {
        this.categoryService
          .create(category)
          .pipe(take(1))
          .subscribe({
            next: category => {
              this.toastService.showSuccess(
                "Category created",
                `Category '${category.name}' was created!`
              );
              this.router.navigate([`categories/${category.id}`]);
              this.categoryService.refreshAll();
            },
            error: () => {
              this.toastService.showError(
                "Error",
                `Category '${category.name}' could not be saved.`
              );
            },
          });
      } else {
        this.categoryService
          .update(category)
          .pipe(take(1))
          .subscribe({
            next: category => {
              this.toastService.showSuccess(
                "Category created",
                `Category '${category.name}' was updated!`
              );
              this.router.navigate([`categories/${category.id}`]);
              this.categoryService.refreshAll();
            },
            error: () => {
              this.toastService.showError(
                "Error",
                `Category '${category.name}' could not be updated.`
              );
            },
          });
      }
    }
  }

  remove(id: Number): void {
    this.categoryService
      .delete(id)
      .pipe(take(1))
      .subscribe({
        next: wasDeleted => {
          if (!wasDeleted) {
            this.toastService.showError(
              "Error",
              "Category could not be removed."
            );
            return;
          }

          this.toastService.showSuccess(
            "Category removed",
            "Category was removed."
          );
          this.router.navigate(["categories/"]);
          this.categoryService.refreshAll();
        },
        error: () => {
          this.toastService.showError(
            "Error",
            "Category could not be removed."
          );
        },
      });
  }
}
