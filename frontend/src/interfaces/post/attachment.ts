import type { AttachmentType } from "@/enums/attachmentType";

export interface Attachment {
    id: string,
    name: string,
    type: AttachmentType,
    created: Date
}