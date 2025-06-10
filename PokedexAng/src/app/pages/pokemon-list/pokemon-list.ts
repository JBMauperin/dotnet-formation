import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Pokemon } from '../../models/pokemon';
import { PokemonService } from '../../services/pokemon-service';
import { PokemonBadge } from "../pokemon-badge/pokemon-badge";

@Component({
  selector: 'app-pokemon-list',
  imports: [CommonModule, PokemonBadge],
  templateUrl: './pokemon-list.html',
  styleUrl: './pokemon-list.css'
})
export class PokemonList {
  protected title = 'Pokemon List';
  protected loadingPokemons = false;
  protected pokemons: Pokemon[] = [];
  protected currentPage = 0;

  constructor(private pokemonService: PokemonService) { }

  ngOnInit() {
    this.loadPokemons();
  }

  protected loadPokemons() {
    this.loadingPokemons = true;
    this.pokemonService.getPokemonList(20, this.currentPage * 20).subscribe({
      next: (pokemons: Pokemon[]) => {
        this.pokemons = pokemons;
        this.loadingPokemons = false;
        console.log('Pokemons loaded:', this.pokemons);
      },
      error: (error) => {
        console.error('Error loading pokemons:', error);
        this.pokemons = [];
        this.loadingPokemons = false;
      }
    });
  }

  protected loadNextPokemons() {
    this.currentPage++;
    this.loadPokemons();
  }

  protected loadPreviousPokemons() {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.loadPokemons();
    }
  }
}
