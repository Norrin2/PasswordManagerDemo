import { Component, EventEmitter, Output, Input, OnChanges, SimpleChanges } from '@angular/core';
import { PasswordCard } from '../../models/password-card';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-password-card-form',
  templateUrl: './password-card-form.component.html',
  styleUrls: ['./password-card-form.component.scss']
})
export class PasswordCardFormComponent implements OnChanges {
  @Input() card: PasswordCard = {};
  @Output() submitForm: EventEmitter<PasswordCard> = new EventEmitter<PasswordCard>();
  passwordCardForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.passwordCardForm = this.formBuilder.group({
      name: ['', Validators.required],
      url: ['', Validators.required],
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['card'] && changes['card'].currentValue) {
      this.updateForm(changes['card'].currentValue);
    }
  }

  updateForm(card: PasswordCard) {
    this.passwordCardForm.patchValue({
      name: card.name || '',
      url: card.url || '',
      username: card.username || '',
      password: card.password || ''
    });
  }

  onSubmit() {
    if (this.passwordCardForm.valid) {
      this.submitForm.emit(this.passwordCardForm.value);
      this.passwordCardForm.reset();
    }
  }
}
