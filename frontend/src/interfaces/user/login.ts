import type { PasswordCarrier } from "../form/passwordCarrier";
import type { UsernameCarrier } from "../form/usernameCarrier";

export interface Login extends UsernameCarrier, PasswordCarrier {}