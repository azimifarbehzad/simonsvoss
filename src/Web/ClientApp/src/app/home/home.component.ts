import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { debounceTime, map, Observable, switchMap, tap } from 'rxjs';
import { SearchService } from '../services/search.service';
import { Item } from '../types/item.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  searchField: FormControl;
  searchForm: FormGroup;
  items: Item[] = [];
  searchText = '';

  constructor(private searchService: SearchService, private fb: FormBuilder) {
    this.searchField = new FormControl();
    this.searchForm = fb.group({ search: this.searchField });

    this.searchField.valueChanges
      .pipe(
        debounceTime(400),
        tap((d) => (this.searchText = d)),
        switchMap((term) => this.searchService.search(term))
      )
      .subscribe((data) => (this.items = data as Item[]));
  }
}
