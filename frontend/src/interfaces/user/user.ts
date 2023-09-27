interface PasswordCarrier {
    password: string
}

export interface User extends PasswordCarrier {
    id: string,
    username: string,
    displayName: string,
    profilePicture: string,
    email: string,
    created: Date,
    updated: Date,
}