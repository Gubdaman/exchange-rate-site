import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SaveExchangeModalComponent } from './save-exchange-modal.component';

describe('SaveExchangeModalComponent', () => {
  let component: SaveExchangeModalComponent;
  let fixture: ComponentFixture<SaveExchangeModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SaveExchangeModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SaveExchangeModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
