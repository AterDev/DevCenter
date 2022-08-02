import { CommentItemDto } from '../comment/comment-item-dto.model';
export interface PageListOfCommentItemDto {
  count: number;
  data?: CommentItemDto[];
  pageIndex: number;

}
