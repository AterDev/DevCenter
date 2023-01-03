import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'cutString'
})
export class CutStringPipe implements PipeTransform {

  transform(value: string, length: number = 10, suffix = '...'): string {
    if (value.length > length) {
      return value.slice(0, length) + suffix;
    } else {
      return value;
    }
  }
}
