import { FilterBase } from '../filter-base.model';
export interface ConfigOptionFilterDto extends FilterBase {
  name?: string | null;
  value?: string | null;
  typeId?: string | null;

}
