import type { UserRoleTypes } from "@/enums/userRoleTypes";

export interface BasicUser {
    id: string,
    displayName: string | null,
    hasCustomAvatar: boolean,
    roles: Array<UserRoleTypes>,
}