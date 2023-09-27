import type { LoginResultType } from "@/enums/loginResultType";
import type { User } from "./user";

export interface LoginResult {
    token: string,
    resultType: LoginResultType,
    user: User | null
}