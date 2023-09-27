import type { BasicUser } from "../user/basicUser";
import type { Attachment } from "./attachment";

export interface Post {
    id: string,
    text: string,
    attachments: Array<Attachment>,
    user: BasicUser
    created: Date,
    updated: Date
}