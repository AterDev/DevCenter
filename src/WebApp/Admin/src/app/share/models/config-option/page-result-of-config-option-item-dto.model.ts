import { ConfigOptionItemDto } from '../config-option/config-option-item-dto.model';
export interface PageResultOfConfigOptionItemDto {
  count: number;
  data?: ConfigOptionItemDto[] | null;
  pageIndex: number;

}
