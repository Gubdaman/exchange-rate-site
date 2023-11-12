import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteExchangeRateModalComponent } from './delete-exchange-rate-modal.component';

describe('DeleteExchangeRateModalComponent', () => {
  let component: DeleteExchangeRateModalComponent;
  let fixture: ComponentFixture<DeleteExchangeRateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DeleteExchangeRateModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeleteExchangeRateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
