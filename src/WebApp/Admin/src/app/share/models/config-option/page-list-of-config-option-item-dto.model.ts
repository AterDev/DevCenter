import { ConfigOptionItemDto } from '../config-option/config-option-item-dto.model';
export interface PageListOfConfigOptionItemDto {
  count: number;
  data?: ConfigOptionItemDto[];
  pageIndex: number;

}
