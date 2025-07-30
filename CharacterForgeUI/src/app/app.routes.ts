import { Routes } from '@angular/router';
import { CharacterListComponent } from './components/character-list/character-list';

export const routes: Routes = [
  {
    path: '',
    redirectTo: '/characters',
    pathMatch: 'full'
  },
  {
    path: 'characters',
    component: CharacterListComponent // Nom cohérent avec la classe
  }
];