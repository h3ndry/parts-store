import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Part } from './part.model';
import { BehaviorSubject, firstValueFrom, tap } from 'rxjs';
import { environment } from "../../environments/environment";
import { MessageService } from "../core/message.service";
import {BackendService} from "../core/backend/backend.service";

@Injectable({
  providedIn: 'root'
})
export class PartService {

  private readonly _partSource = new BehaviorSubject<Part[]>([]);
  public readonly parts$ = this._partSource.asObservable();

  constructor(private httpClient: HttpClient,
              private messageService: MessageService,
              private backendService: BackendService
  ) {
  }

  private showErrorMessage(e: any, message: string) {
    this.messageService.showError( `${message} - server returned code ${e.status}`)
  }
  
  private getPartsUrl()
  {
    return `${environment.baseUrl}${this.backendService.getPath()}/api/part`;
  }

  async loadPartsAsync() {
    let parts = await firstValueFrom(this.httpClient.get<Part[]>(this.getPartsUrl())
      .pipe(
        tap({
          error: (e) => this.showErrorMessage(e, `Failed to load Parts`)
        })
      ));
    this._partSource.next(parts)
  }
}
