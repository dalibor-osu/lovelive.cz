import type { BasicUser } from "./basicUser";

interface PasswordCarrier {
    password: string
}

export interface User extends PasswordCarrier, BasicUser {
    username: string,
    created: Date,
    bio: string,
}