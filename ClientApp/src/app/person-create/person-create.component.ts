import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PersonService } from '../person.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.css']
})
export class PersonCreateComponent {
  personForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private personService: PersonService,
    private router: Router
  ) {
    this.personForm = this.fb.group({
      lastName: ['', Validators.required],
      firstName: ['', Validators.required],
      patronymic: [''],
      birthdate: ['', Validators.required],
      numberPhone: ['', Validators.required],
      documentType: ['', Validators.required],
      numberDocument: ['', Validators.required],
      dateOfIssue: ['', Validators.required],
      whoIssuedDocument: [''],
      address: [''],
      product: [''],
      photo: [null, Validators.required]
    });
  }

  onSubmit() {
    if (this.personForm.valid) {
      this.personService.createPerson(this.personForm.value).subscribe(() => {
        console.log('Person created successfully');
        this.router.navigate(['/persons']);
      });
    }
  }
}
