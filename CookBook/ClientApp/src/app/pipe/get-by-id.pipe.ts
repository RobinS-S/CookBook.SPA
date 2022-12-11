import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "getById",
})
export class GetByIdPipe implements PipeTransform {
  transform(value: number, args?: any[]): any {
    if (!args) {
      return null;
    }
    return args.find(o => o.id === value);
  }
}
