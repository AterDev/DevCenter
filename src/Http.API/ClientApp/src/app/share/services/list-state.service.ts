import { Injectable } from '@angular/core';

@Injectable()
export class ListStateService {

  filter: FilterState<any> | null = null;
  constructor() { }
}

export interface FilterState<T> {
  query: string | null,
  filter: T | null

}
