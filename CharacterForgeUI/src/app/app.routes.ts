import { Routes } from '@angular/router';
import { CharacterListComponent } from './pages/character-list/character-list';
import { CharacterCreate } from './pages/character-create/character-create';
import { EditCharacterPage } from './pages/edit-character/edit-character';

export const routes: Routes = [
  { path: '', redirectTo: '/characters', pathMatch: 'full' },
  { path: 'characters', component: CharacterListComponent },
  { path: 'create-character', component: CharacterCreate },
  { path: 'edit-character/:id', component: EditCharacterPage },
];