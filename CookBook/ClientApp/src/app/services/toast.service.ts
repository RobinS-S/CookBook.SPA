import { Injectable, TemplateRef } from "@angular/core";
import { ToastInfo } from "../model/toast-info";

@Injectable({ providedIn: "root" })
export class ToastService {
  toasts: ToastInfo[] = [];

  show(
    header: string,
    body: string,
    classname: string = "bg-info text-light",
    delay: number = 5000
  ) {
    this.toasts.push({
      header,
      body,
      classname,
      delay,
    } as ToastInfo);
  }

  showSuccess(header: string, body: string, delay: number = 5000) {
    this.show(header, body, "bg-success text-light", delay);
  }

  showError(header: string, body: string, delay: number = 5000) {
    this.show(header, body, "bg-danger text-light", delay);
  }

  showInfo(header: string, body: string, delay: number = 5000) {
    this.show(header, body, "bg-info text-light", delay);
  }

  remove(toast: ToastInfo) {
    this.toasts = this.toasts.filter(t => t !== toast);
  }

  clear() {
    this.toasts.splice(0, this.toasts.length);
  }
}
