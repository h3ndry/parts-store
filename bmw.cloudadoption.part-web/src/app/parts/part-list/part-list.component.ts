import {Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';
import { Observable } from "rxjs";
import { ColDef, SelectionChangedEvent} from 'ag-grid-community';
import { BaseColDefParams } from 'ag-grid-community/dist/lib/entities/colDef';
import { PartService } from "../part.service";
import { Part } from '../part.model';

@Component({
  selector: 'app-part-list',
  templateUrl: './part-list.component.html',
  styleUrls: [ './part-list.component.scss' ]
})
export class PartListComponent implements OnInit {

  defaultColDef: ColDef;
  columnDefs: ColDef[]
  parts$ : Observable<Part[]>

  constructor(private router: Router,
              private translator: TranslateService,
              private partService: PartService
  ) {
    this.parts$ = this.partService.parts$;
    this.defaultColDef = defaultColDef;
    this.columnDefs = columnDefs.map(field => {
       return { ...field, headerName: translator.instant(field.headerName) }
    });

    this.translator.onLangChange.subscribe(() => {
      this.columnDefs = columnDefs.map(field => {
        return { ...field, headerName: translator.instant(field.headerName) }
      });
    });
  }

  async ngOnInit() {
    await this.partService.loadPartsAsync();
  }

  async onCreate() {
    await this.router.navigate([ 'part', 'create' ])
  }

  async onRefresh() {
    await this.partService.loadPartsAsync();
  }

  async onSelectionChanged(event: SelectionChangedEvent) {
    const selectedPart = event.api.getSelectedRows()[0] as Part;
    await this.router.navigate([ 'part', selectedPart.partNumber ]);
  }
}

const columnDefs = [
  { headerName: 'PART_NUMBER', field: 'partNumber' },
  { headerName: 'PART_STRING', field: 'partString' },
  { headerName: 'UNIT_TYPE', field: 'unitType' },
  { headerName: 'ASSEMBLED', field: 'assembled' },
  { headerName: 'STATUS', field: 'status' },
  { headerName: 'GROSS_WEIGHT', field: 'grossWeight' },
  { headerName: 'NET_WEIGHT', field: 'netWeight' },
  { headerName: 'WEIGHT_UNIT', field: 'weightUnit' },
  { headerName: 'PLANT_ID', valueGetter: (params: BaseColDefParams) => params.data?.plant?.id },
  { headerName: 'SUPPLIER_ID', valueGetter: (params: BaseColDefParams) => params.data?.supplier?.id }
];

const defaultColDef = {
  flex: 1,
  sortable: false,
};
