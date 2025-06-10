import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, forkJoin, map, switchMap } from 'rxjs';
import { Pokemon } from '../models/pokemon';
import { PokemonDetailsModel } from '../models/pokemon-details.model';
import { PokemonListModel } from '../models/pokemon-list.model';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  private baseUrl: string = 'https://pokeapi.co/api/v2/pokemon';

  constructor(private http: HttpClient) { }

  getPokemon(pokemonName: string): Observable<Pokemon> {
    const url = `${this.baseUrl}/${pokemonName}`;

    return this.http.get<PokemonDetailsModel>(url).pipe(
      map(pokemonData => new Pokemon(pokemonData))
    );
  }

  getPokemonList(limit: number = 20, offset: number = 0): Observable<Pokemon[]> {
    const url = `${this.baseUrl}?limit=${limit}&offset=${offset}`;

    return this.http.get<PokemonListModel>(url).pipe(
      switchMap((data: PokemonListModel) => {
        const detailsRequests: Observable<PokemonDetailsModel>[] = data.results.map(pokemon => 
          this.http.get<PokemonDetailsModel>(pokemon.url)
        )

        return forkJoin(detailsRequests);
      }),
      map((details: PokemonDetailsModel[]) => {
        return details.map(pokemonDetail => new Pokemon(pokemonDetail));
      })
    );
  }
}
