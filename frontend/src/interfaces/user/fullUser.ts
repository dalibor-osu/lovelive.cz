import type { User } from "./user";

export interface FullUser extends User {
    email: string,
    updated: Date,
}