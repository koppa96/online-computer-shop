export interface PropertyModel {
    id?: string;
    name: string;
}

export interface CategoryEditCreateModel {
    id?: string;
    name: string;
    properties: PropertyModel[];
    socketIds: string[];
}