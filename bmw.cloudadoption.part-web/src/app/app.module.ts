import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from "@angular/common/http";
import { HttpLoadingInterceptor } from "./core/http-loading.interceptor";
import { TranslateLoader, TranslateModule, TranslateService } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { AgGridModule } from "ag-grid-angular";
import { AppRoutingModule } from './app-routing.module';
import { MaterialModule } from "./material.module";
import { FlexLayoutModule } from "@angular/flex-layout";

import { AppComponent } from './app.component';
import { HomeComponent } from "./core/home/home.component";
import { NotFoundComponent } from "./core/not-found/not-found.component";
import { PartListComponent } from "./parts/part-list/part-list.component";
import {BackendComponent} from "./core/backend/backend.component";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    BackendComponent,
    PartListComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    AgGridModule,
    FlexLayoutModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient]
      }
    })
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: HttpLoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function HttpLoaderFactory(http: HttpClient): TranslateHttpLoader {
  return new TranslateHttpLoader(http);
}
