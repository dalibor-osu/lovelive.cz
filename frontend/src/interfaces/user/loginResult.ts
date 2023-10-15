import type { LoginResultType } from "@/enums/loginResultType";
import type { FullUser } from "./fullUser";

export interface LoginResult {
    token: string,
    resultType: LoginResultType,
    user: FullUser | null
}