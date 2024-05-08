export class Post {
    author: string;
    authorId: number;
    id: number;
    likes: number;
    popularity: number;
    reads: number;
    tags: string[];

    constructor(data: Post) {
        this.author = data.author;
        this.authorId = data.authorId;
        this.id = data.id;
        this.likes = data.likes;
        this.popularity = data.popularity;
        this.reads = data.reads;
        this.tags = data.tags;
    }
}
