import type { BasicUser } from "../user/basicUser";
import type { Attachment } from "./attachment";

export interface Post {
    id: string,
    text: string,
    attachments: Array<Attachment>,
    user: BasicUser,
    likeCount: number,
    liked: boolean,
    created: Date,
    updated: Date
}