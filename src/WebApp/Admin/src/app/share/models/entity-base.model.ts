import { Status } from './enum/status.model';
export interface EntityBase {
  id: string;
  createdTime: Date;
  updatedTime: Date;
  status?: Status | null;
  isDeleted: boolean;

}
