import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueStatePhotoComponent } from './issue-state-photo.component';

describe('IssueStatePhotoComponent', () => {
  let component: IssueStatePhotoComponent;
  let fixture: ComponentFixture<IssueStatePhotoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IssueStatePhotoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IssueStatePhotoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
