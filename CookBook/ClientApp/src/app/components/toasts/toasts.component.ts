import { Component } from "@angular/core";
import { ToastService } from "src/app/services/toast.service";

@Component({
  selector: "app-toasts",
  template: `
    <ngb-toast
      *ngFor="let toast of toastService.toasts"
      [header]="toast.header"
      [class]="toast.classname"
      [autohide]="true"
      [delay]="toast.delay || 5000"
      (hidden)="toastService.remove(toast)">
      {{ toast.body }}
    </ngb-toast>
  `,
  host: {
    class: "toast-container position-fixed bottom-0 end-0 p-3",
    style: "z-index: 1200",
  },
})
export class ToastsComponent {
  constructor(public toastService: ToastService) {}
}
