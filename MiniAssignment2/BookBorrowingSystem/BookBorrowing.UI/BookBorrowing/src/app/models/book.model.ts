export interface Book {
    bookId: number;
    name: string;
    rating: number;
    author: string;
    genre: string;
    is_Book_Available: boolean;
    description: string;
    lent_By_User_id: number;
    currently_Borrowed_By_User_id: number;
}