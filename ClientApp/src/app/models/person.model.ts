export interface Person {
  id: number;
  firstName: string;
  lastName: string;
  patronymic?: string; // необязательное поле
  birthdate: Date;
  numberPhone: string;
  documentType: string;
  numberDocument: string;
  dateOfIssue: Date;
  whoIssuedDocument: string;
  address: string;
  product: string;
  photoPath: string;
}
