import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PokemonBadge } from './pokemon-badge';

describe('PokemonBadge', () => {
  let component: PokemonBadge;
  let fixture: ComponentFixture<PokemonBadge>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PokemonBadge]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PokemonBadge);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
