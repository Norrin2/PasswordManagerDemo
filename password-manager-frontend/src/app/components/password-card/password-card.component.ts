import { Component, EventEmitter, Input, Output } from '@angular/core';
import { PasswordCard } from '../../models/password-card';
import { Clipboard } from '@angular/cdk/clipboard';

@Component({
  selector: 'app-password-card',
  templateUrl: './password-card.component.html',
  styleUrl: './password-card.component.scss'
})
export class PasswordCardComponent {

  @Input() card: PasswordCard = {};
  @Output() deleteCardEmmiter: EventEmitter<PasswordCard> = new EventEmitter<PasswordCard>();
  @Output() editCardEmmiter: EventEmitter<PasswordCard> = new EventEmitter<PasswordCard>();

  passwordVisible: boolean = false;

  constructor(private clipboard: Clipboard) {}

  toggleVisibility() {
    this.passwordVisible = !this.passwordVisible;
  }

  copyToClipboard() {
    this.clipboard.copy(this.card.password!);
  }

  editCard()
  {
    this.editCardEmmiter.emit(this.card);
  }

  deleteCard()
  {
    this.deleteCardEmmiter.emit(this.card);
  }
}

