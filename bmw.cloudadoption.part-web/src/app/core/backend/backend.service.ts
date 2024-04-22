import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class BackendService {
    
    Path: string = '';
    
    constructor() {
    }
    
    public setPath(path: string) {
        this.Path = path;
    }
    
    public getPath(){
        return this.Path;
    }
}
