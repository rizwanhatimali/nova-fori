import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageToDoComponent } from './manage-to-do.component';

describe('ManageToDoComponent', () => {
  let component: ManageToDoComponent;
  let fixture: ComponentFixture<ManageToDoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ManageToDoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageToDoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
