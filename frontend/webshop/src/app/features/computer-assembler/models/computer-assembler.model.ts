import { CategoryListResponse, ProductListResponse } from 'src/app/shared/clients';

export interface ComputerAssemblerItem {
  category: CategoryListResponse;
  chosenProduct: ProductListResponse;
}
