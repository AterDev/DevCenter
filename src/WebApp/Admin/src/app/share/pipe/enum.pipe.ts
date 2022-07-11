import { Pipe, PipeTransform } from '@angular/core';
import { NavigationType } from '../models/enum/navigation-type.model';

@Pipe({
  name: 'enum'
})
export class EnumPipe implements PipeTransform {
  transform(value: unknown, type: string): unknown {
    let result = '';
    switch (type) {
      case 'sex':
        switch (value) {
          case 0:
            result = '男';
            break;
          case 1:
            result = '女';
            break;
          default:
            result = '其他';
            break;
        }
        break;
      case 'navigation':
        switch (value) {
          case NavigationType.Default:
            result = NavigationType[NavigationType.Default];
            break;

          case NavigationType.CodeSnippets:
            result = NavigationType[NavigationType.CodeSnippets];
            break;
          case NavigationType.Server:
            result = NavigationType[NavigationType.Server];
            break;
          case NavigationType.Tools:
            result = NavigationType[NavigationType.Tools];
            break;
          case NavigationType.WebSite:
            result = NavigationType[NavigationType.WebSite];
            break;
          default:
            break;
        }
        break;
      default:
        break;
    }
    return result;
  }
}

