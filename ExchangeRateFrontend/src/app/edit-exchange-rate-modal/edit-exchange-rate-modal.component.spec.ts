import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditExchangeRateModalComponent } from './edit-exchange-rate-modal.component';

describe('EditExchangeRateModalComponent', () => {
  let component: EditExchangeRateModalComponent;
  let fixture: ComponentFixture<EditExchangeRateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditExchangeRateModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditExchangeRateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
