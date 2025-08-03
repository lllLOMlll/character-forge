import { Component } from '@angular/core';
import { CharacterService, Character } from '../../services/character';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-character-create',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './character-create.html',
  styleUrl: './character-create.css',
})
export class CharacterCreate {
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

  createCharacterMessage: string = '';

  constructor(
    private characterService: CharacterService,
    private router: Router
  ) {}

  onCreateCharacter(): void {
    this.characterService.createCharacter(this.newCharacter).subscribe({
      next: () => {
        this.router.navigateByUrl('/characters', {
          state: { successMessage: '✅ Character created!' },
        });
      },
      error: () => {
        this.router.navigateByUrl('/characters', {
          state: { errorMessage: '❌ Failed to create character' },
        });
      },
    });
  }

  onCancel(): void {
    this.router.navigate(['/characters']);
  }
  
}
