import type { DisplayNameCarrier } from "../form/displayNameCarrier";
import type { EmailCarrier } from "../form/emailCarrier";
import type { PasswordCarrier } from "../form/passwordCarrier";
import type { UsernameCarrier } from "../form/usernameCarrier";

export interface NewUser extends PasswordCarrier, UsernameCarrier, EmailCarrier, DisplayNameCarrier {}