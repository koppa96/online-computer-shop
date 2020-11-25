import { OrderStateToStringPipe } from './order-state-to-string.pipe';

describe('OrderStateToStringPipe', () => {
  it('create an instance', () => {
    const pipe = new OrderStateToStringPipe();
    expect(pipe).toBeTruthy();
  });
});
