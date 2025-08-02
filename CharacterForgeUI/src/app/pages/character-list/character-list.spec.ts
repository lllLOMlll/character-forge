import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { CharacterService, Character } from '../../services/character';

@Component({
  selector: 'app-character-list',
  standalone: true,
  imports: [CommonModule], // <- AJOUT ICI
  templateUrl: './character-list.html',
  styleUrls: ['./character-list.css']
})
export class CharacterList implements OnInit {
  characters: Character[] = [];

  constructor(private characterService: CharacterService) {}

  ngOnInit(): void {
    this.characterService.getCharacters().subscribe((data) => {
      this.characters = data;
    });
  }
}

