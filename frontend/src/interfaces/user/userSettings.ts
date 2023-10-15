import type { DisplayNameCarrier } from "../form/displayNameCarrier";

export interface UserSettings extends DisplayNameCarrier {
    bio: string | null,
}