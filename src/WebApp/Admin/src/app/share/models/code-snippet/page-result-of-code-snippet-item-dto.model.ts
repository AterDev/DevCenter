import { CodeSnippetItemDto } from '../code-snippet/code-snippet-item-dto.model';
export interface PageResultOfCodeSnippetItemDto {
  count: number;
  data?: CodeSnippetItemDto[] | null;
  pageIndex: number;

}
