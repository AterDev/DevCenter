import { Selection } from '../selection.model';
export interface ResourceSelectDataDto {
  typeDefines?: Selection[] | null;
  tags?: Selection[] | null;
  group?: Selection[] | null;

}
