import { TitleCasePipe } from '@angular/common';
import { Component, Input } from '@angular/core';
import { Pokemon } from '../../models/pokemon';

@Component({
  selector: 'app-pokemon-badge',
  imports: [TitleCasePipe],
  templateUrl: './pokemon-badge.html',
  styleUrl: './pokemon-badge.css'
})
export class PokemonBadge {
  @Input() pokemon! : Pokemon;
}
