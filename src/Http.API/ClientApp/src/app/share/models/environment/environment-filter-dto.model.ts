import { FilterBase } from '../filter-base.model';
export interface EnvironmentFilterDto extends FilterBase {
  name?: string | null;

}
