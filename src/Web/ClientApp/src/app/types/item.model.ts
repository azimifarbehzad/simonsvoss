import { Building } from './building.model';
import { LockModel } from './lock.model';
import { Medium } from './medium.model';

export class Item {
  id: string = '';
  name: string = '';
  type: number = 0;
  typeName: string = '';
  description: string = '';
  score: number = 0;
  lock: LockModel = { serialNumber: '', floor: '', roomNumber: '' };
  medium: Medium = { serialNumber: '', owner: '', type: '' };

  building: Building = { shortCut: '' };
}
