import { Routes } from '@angular/router';
import { CharacterListComponent } from './components/character-list/character-list';
import { CharacterCreate } from './components/character-create/character-create';

export const routes: Routes = [
  { path: '', redirectTo: '/characters', pathMatch: 'full' },
  { path: 'characters', component: CharacterListComponent },
  { path: 'create-character', component: CharacterCreate },
];