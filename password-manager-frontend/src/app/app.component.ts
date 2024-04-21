import { Component, OnInit } from '@angular/core';
import { PasswordCardService } from './services/password-card-service';
import { PasswordCard } from './models/password-card';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  public passwordCards: Array<PasswordCard> = [];
  public filteredPasswordCards: Array<PasswordCard> = [];
  showForm: boolean = false;
  selectedCard: PasswordCard = {};
  searchTerm: string = '';

  constructor(private passwordCardService: PasswordCardService) {}

  ngOnInit(): void {
    this.updatePasswordCards();
  }

  updatePasswordCards()
  {
    this.passwordCardService.findAll()
        .subscribe( (cards) => {
          this.passwordCards = cards;
          this.filterCards();
          this.showForm = false;
        });
  }

  toggleFormVisibility() {
    if (this.showForm)
    {
      this.showForm = false;
      this.selectedCard = {};
    } else
      this.showForm = true;
  }

  editCard(card: PasswordCard) {
    this.selectedCard = card;
    this.showForm = true;
  }

  deleteCard(card: PasswordCard) {
    this.passwordCardService.delete(card.id!)
      .subscribe(() => this.updatePasswordCards());
  }

  onSubmitForm(passwordCard: PasswordCard) {
    if (this.selectedCard.id) {
      this.passwordCardService.update(this.selectedCard.id, passwordCard)
        .subscribe(() => this.updatePasswordCards());
    } else {
      this.passwordCardService.create(passwordCard)
        .subscribe(() => this.updatePasswordCards());
    }
  }

  filterCards() {
    if (this.searchTerm)
    {
      this.filteredPasswordCards = this.passwordCards.filter(card =>
        card.name!.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
    } else this.filteredPasswordCards = this.passwordCards;

  }

  search() {
    this.filterCards();
  }

}
