import { Component, OnInit } from '@angular/core';
import { PersonService } from '../person.service';
import { Person } from '../models/person.model';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  persons: Person[] = [];

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.personService.getPersons().subscribe(data => {
      this.persons = data;
    });
  }
}
