export interface OrderAddress {
  zipCode: string;
  cityName: string;
  publicPlaceName: string;
  houseNumber: string;
  stairCaseNumber: string;
  floor: string;
  door: string;
}

export interface OrderMetadata {
  name: string;
  phoneNumber: string;
  address: OrderAddress;
}
