import { CodeSnippetItemDto } from '../code-snippet/code-snippet-item-dto.model';
export interface PageListOfCodeSnippetItemDto {
  count: number;
  data?: CodeSnippetItemDto[];
  pageIndex: number;

}
