export interface PokemonDetailsModel {
    id: number;
    name: string;
    base_experience: number;
    height: number;
    weight: number;
    sprites: {
        front_default: string;
        back_default: string;
    }
}
