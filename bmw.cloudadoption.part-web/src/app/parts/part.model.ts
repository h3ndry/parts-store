export interface Part {
  partNumber: string;
  partString: string;
  unitType: 'SINGLE_PIECE' | 'SMALL_BOX' | 'LARGE_BOX';
  assembled: boolean;
  status: 'NEW' | 'VALID' | 'DISCONTINUED';
  grossWeight: number;
  netWeight: number;
  weightUnit: string;
  plant: Plant;
  supplier: Supplier;
}

export interface Supplier {
  id: string;
  name: string;
}

export interface Plant {
  id: string;
  unloadPoint: string;
}
