import { PokemonDetailsModel } from "./pokemon-details.model";

export class Pokemon {
    id: number;
    name: string;
    baseExperience: number;
    height: number;
    weight: number;
    sprites: {
        frontDefault: string;
        backDefault: string;
    };

    constructor(pokemonData: PokemonDetailsModel) {
        this.id = pokemonData.id;
        this.name = pokemonData.name;
        this.baseExperience = pokemonData.base_experience;
        this.height = pokemonData.height;
        this.weight = pokemonData.weight;
        this.sprites = {
            frontDefault: '',
            backDefault: ''
        };
        this.sprites.backDefault = pokemonData.sprites.back_default;
        this.sprites.frontDefault = pokemonData.sprites.front_default;
    }
}
