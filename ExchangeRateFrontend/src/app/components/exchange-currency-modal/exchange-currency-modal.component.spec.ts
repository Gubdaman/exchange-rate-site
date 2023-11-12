import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangeCurrencyModalComponent } from './exchange-currency-modal.component';

describe('ExchangeCurrencyModalComponent', () => {
  let component: ExchangeCurrencyModalComponent;
  let fixture: ComponentFixture<ExchangeCurrencyModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExchangeCurrencyModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExchangeCurrencyModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
