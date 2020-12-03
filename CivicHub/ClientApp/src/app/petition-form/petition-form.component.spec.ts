import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PetitionFormComponent } from './petition-form.component';

describe('PetitionFormComponent', () => {
  let component: PetitionFormComponent;
  let fixture: ComponentFixture<PetitionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PetitionFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PetitionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
