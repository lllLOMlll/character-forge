import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import  { CharacterService } from '../../services/character';
import { Character } from '../../services/character';

@Component({
  standalone: true,
  imports: [CommonModule, FormsModule],
  selector: 'app-edit-character',
  templateUrl: './edit-character.html',
})
export class EditCharacterPage implements OnInit {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private characterService = inject(CharacterService);

  character: Character = {
    id: 0,
    name: '',
    race: '',
    class: '',
    strength: 0,
    dexterity: 0,
    intelligence: 0,
    constitution: 0,
    wisdom: 0,
    charisma: 0,
  };

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.characterService.getCharacterById(id).subscribe((data) => {
      this.character = data;
    });
  }

  onUpdateCharacter() {
    this.characterService.updateCharacter(this.character.id, this.character).subscribe(() => {
      this.router.navigate(['/characters'], {
        state: { successMessage: `${this.character.name} updated successfully!` },
      });
    });
  }

  cancel(): void {
    this.router.navigate(['/characters']);
  }
}
