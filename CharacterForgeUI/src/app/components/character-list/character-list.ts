import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { CharacterService, Character } from '../../services/character';

@Component({
  selector: 'app-character-list',
  standalone: true,
  imports: [CommonModule, FormsModule], // Les deux imports nécessaires
  templateUrl: './character-list.html',
  styleUrls: ['./character-list.css']
})
export class CharacterListComponent implements OnInit {
  characters: Character[] = [];
  
  // Champs de recherche
  searchTermName: string = '';
  searchTermClass: string = '';

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
    constitution: 10
  
  }

  constructor(private characterService: CharacterService) {}

  ngOnInit(): void {
    this.loadAllCharacters();
  }

  loadAllCharacters(): void {
    this.characterService.getCharacters().subscribe({
      next: (data) => {
        this.characters = data;
      },
      error: (error) => {
        console.error('Erreur lors du chargement des personnages:', error);
      }
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
        this.characters = data.filter(c => 
          c.name.toLowerCase().includes(term)
        );
      },
      error: (error) => {
        console.error('Erreur lors de la recherche par nom:', error);
      }
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
        this.characters = data.filter(c => 
          c.class.toLowerCase().includes(term)
        );
      },
      error: (error) => {
        console.error('Erreur lors de la recherche par classe:', error);
      }
    });
  }

  onCreateCharacter(): void {
    this.characterService.createCharacter(this.newCharacter).subscribe({
      next: (created) => {
        this.characters.push(created);
        this.resetForm();
      },
      error: (error) => {
        console.error('Erreur lors de la création du personnage:', error);
      }
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
      charisma: 10
    };
  }
}