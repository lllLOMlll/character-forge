import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Interface du personnage
export interface Character {
  id: number;
  name: string;
  race: string;
  class: string;
  strength: number;
  dexterity: number;
  intelligence: number;
  wisdom: number;       
  charisma: number;
  constitution: number;
}

@Injectable({
  providedIn: 'root',
})
export class CharacterService {
  private apiUrl = 'http://localhost:5176/api/characters';

  constructor(private http: HttpClient) {}

  getCharacters(): Observable<Character[]> {
    return this.http.get<Character[]>(this.apiUrl);
  }

  createCharacter(character: Character): Observable<Character> {
    return this.http.post<Character>(this.apiUrl, character);
  }

  updateCharacter(id: number, character: Partial<Character>): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, character);
  }

  deleteCharacter(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }


// searchCharactersByClass(characterClass: string): Observable<Character[]> {
//   return this.http.get<Character[]>(`${this.apiUrl}/characters/searchByClass`, {
//     params: { characterClass }
//   });
// }
}
