import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentExchangeRateComponent } from './current-exchange-rate.component';

describe('CurrentExchangeRateComponent', () => {
  let component: CurrentExchangeRateComponent;
  let fixture: ComponentFixture<CurrentExchangeRateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CurrentExchangeRateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CurrentExchangeRateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
