import type { UserRoleTypes } from "@/enums/userRoleTypes";

export interface BasicUser {
    id: string,
    displayName: string | null,
    profilePicture: string,
    roles: Array<UserRoleTypes>,
}