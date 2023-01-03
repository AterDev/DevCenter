import { Selection } from '../old-resource/selection.model';
export interface ResourceSelectDataDto {
  typeDefines?: Selection[] | null;
  tags?: Selection[] | null;
  group?: Selection[] | null;

}
