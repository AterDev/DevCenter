import { FilterBase } from '../filter-base.model';
export interface CodeSnippetFilterDto extends FilterBase {
  name?: string | null;
  format?: string | null;

}
