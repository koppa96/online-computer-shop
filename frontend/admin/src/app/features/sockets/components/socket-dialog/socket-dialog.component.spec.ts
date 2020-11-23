import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SocketDialogComponent } from './socket-dialog.component';

describe('SocketDialogComponent', () => {
  let component: SocketDialogComponent;
  let fixture: ComponentFixture<SocketDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SocketDialogComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SocketDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
