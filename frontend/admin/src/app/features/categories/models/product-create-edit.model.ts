import { ProvidesUses } from 'src/app/shared/clients';

export interface PropertyValueEditCreateModel {
    propertyTypeId: string;
    propertyTypeName: string;
    value: string;
}

export interface ProductSocketEditCreateModel {
    socketId: string;
    name: string;
    providesUses: ProvidesUses;
    numberOfSocket: number;
}


export interface ProductEditCreateModel {
    id?: string;
    name: string;
    description: string;
    price: number;
    categoryId: string;
    properties: PropertyValueEditCreateModel[];
    productSockets: ProductSocketEditCreateModel[];
}