import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CharacterService, Character } from '../../services/character';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-character-list',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './character-list.html',
  styleUrls: ['./character-list.css'],
})
export class CharacterListComponent implements OnInit {
  characters: Character[] = [];

  // Champs de recherche
  searchTermName: string = '';
  searchTermClass: string = '';
  successMessage: string = '';
  errorMessage: string = '';

  // Character creation
  newCharacter: Character = {
    id: 0,
    name: '',
    race: '',
    class: '',
    strength: 10,
    dexterity: 10,
    intelligence: 10,
    wisdom: 10,
    charisma: 10,
    constitution: 10,
  };

  constructor(
    private characterService: CharacterService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const state = window.history.state as {
      successMessage?: string;
      errorMessage?: string;
    };

    if (state?.successMessage) {
      this.successMessage = state.successMessage;
      setTimeout(() => {
        this.successMessage = '';
      }, 5000);
    }

    if (state?.errorMessage) {
      this.errorMessage = state.errorMessage;
      setTimeout(() => (this.errorMessage = ''), 5000);
    }

    this.loadAllCharacters();
  }

  loadAllCharacters(): void {
    this.characterService.getCharacters().subscribe({
      next: (data) => {
        this.characters = data;
      },
      error: (error) => {
        console.error('Erreur lors du chargement des personnages:', error);
      },
    });
  }

  searchByName(): void {
    if (!this.searchTermName.trim()) {
      this.loadAllCharacters();
      return;
    }

    const term = this.searchTermName.toLowerCase();
    this.characterService.getCharacters().subscribe({
      next: (data) => {
        this.characters = data.filter((c) =>
          c.name.toLowerCase().includes(term)
        );
      },
      error: (error) => {
        console.error('Erreur lors de la recherche par nom:', error);
      },
    });
  }

  searchByClass(): void {
    if (!this.searchTermClass.trim()) {
      this.loadAllCharacters();
      return;
    }

    const term = this.searchTermClass.toLowerCase();
    this.characterService.getCharacters().subscribe({
      next: (data) => {
        this.characters = data.filter((c) =>
          c.class.toLowerCase().includes(term)
        );
      },
      error: (error) => {
        console.error('Erreur lors de la recherche par classe:', error);
      },
    });
  }

  onCreateCharacter(): void {
    this.characterService.createCharacter(this.newCharacter).subscribe({
      next: (created) => {
        this.successMessage = '✅ Character created successfully!';
        this.characters.push(created);
        this.resetForm();

        setTimeout(() => {
          this.successMessage = '';
        }, 5000);
      },
      error: (error) => {
        console.error('Erreur lors de la création du personnage:', error);
      },
    });
  }

  resetForm(): void {
    this.newCharacter = {
      id: 0,
      name: '',
      race: '',
      class: '',
      strength: 10,
      dexterity: 10,
      constitution: 10,
      intelligence: 10,
      wisdom: 10,
      charisma: 10,
    };
  }

  editCharacter(c: Character) {
    const updatedCharacter: Partial<Character> = {
      name: prompt('New name', c.name) || c.name,
      race: prompt('New race', c.race) || c.race,
      class: prompt('New class', c.class) || c.class,
      strength: Number(prompt('Strength', c.strength.toString())),
      dexterity: Number(prompt('Dexterity', c.dexterity.toString())),
      intelligence: Number(prompt('Intelligence', c.intelligence.toString())),
    };

    this.characterService
      .updateCharacter(c.id, updatedCharacter)
      .subscribe(() => {
        this.loadAllCharacters(); // recharge la liste
      });
  }

  onDeleteCharacter(c: Character): void {
    if (!confirm(`Are you sure you want to delete ${c.name}?`)) {
      return;
    }

    this.characterService.deleteCharacter(c.id).subscribe({
      next: () => {
        this.successMessage = `🗑️ Character ${c.name} deleted successfully!`;
        this.loadAllCharacters();
        this.scrollToTop();
        setTimeout(() => {
          this.successMessage = '';
        }, 5000);
      },
      error: (error) => {
        console.error('Error while deleting the character:', error);
        this.errorMessage = `❌ Error deleting character ${c.name}. Please try again later.`;
        this.loadAllCharacters();
        this.scrollToTop();
        setTimeout(() => {
          this.errorMessage = '';
        }, 5000);
      },
    });
  }

  scrollToTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }


}
