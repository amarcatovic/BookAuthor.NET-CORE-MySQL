import { Author } from './../authors-list/authors';
export interface Book{
    id: number;
    name: string;
    description: string;
    published: string;
    authors: Author[];
}