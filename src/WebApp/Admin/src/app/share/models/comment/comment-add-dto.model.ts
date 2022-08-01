export interface CommentAddDto {
  /**
   * 评论内容
   */
  content?: string | null;
  blogId: string;
  userId: string;

}
