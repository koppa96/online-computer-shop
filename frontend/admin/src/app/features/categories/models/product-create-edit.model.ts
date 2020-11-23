export interface PropertyValueEditCreateModel {
    propertyTypeId: string;
    propertyTypeName: string;
    value: string;
}

export interface ProductEditCreateModel {
    id?: string;
    name: string;
    description: string;
    price: number;
    categoryId: string;
    properties: PropertyValueEditCreateModel[];
    sockets: string[];
}