import { defineStore } from "pinia";
import { mande } from "mande";
import { LoginResultType } from "@/enums/loginResultType";
import type { NewUser } from "@/interfaces/user/newUser";
import type { LoginResult } from "@/interfaces/user/loginResult";
import type { Login } from "@/interfaces/user/login";
import type { User } from "@/interfaces/user/user";
import Cookies from "js-cookie";
import type { FullUser } from "@/interfaces/user/fullUser";

const api = mande("/api/user");

const setToken = (token: string) => {
	Cookies.set("token", token);
	api.options.headers.Authorization = "Bearer " + token;
};

const clearToken = () => {
	Cookies.remove("token");
	delete api.options.headers.Authorization;
};

const getToken = (): string | null => {
	return Cookies.get("token") ?? null;
};

export const useUserStore = defineStore("user", {
	state: (): UserStore => {
		return {
			user: null,
			userDictionary: {} as Record<string, User>,
		};
	},

	getters: {
		isLoggedIn(): boolean {
			return this.user != null;
		},
	},

	actions: {
		async registerUser(newUser: NewUser): Promise<void> {
			try {
				const response = await api.post<LoginResult>("/register", newUser);

				if (response.resultType !== LoginResultType.Success) {
					return;
				}

				Cookies.set("token", response.token);
				setToken(response.token);
				this.user = response.user;
			}
			catch (error) {
				console.log(error);
			}
		},

		async loginUser(login: Login): Promise<void> {
			try {
				const response = await api.post<LoginResult>("/login", login);

				if (response.resultType !== LoginResultType.Success) {
					return;
				}

				setToken(response.token);
				this.user = response.user;
			}
			catch (error) {
				console.log(error);
			}
		},

		logoutUser(): void {
			this.user = null as null | FullUser;
			clearToken();
		},

		async getCurrentUser() {
			const token = getToken();

			if (token == null) {
				return;
			}

			try {
				api.options.headers.Authorization = "Bearer " + token;
				const response = await api.get<FullUser>("/current");
				this.user = response;
			}
			catch (error) {
				//	NOTE(dalibor) This is not a correct behaviour. We should check if the response code is 401 and then clear the token.
				clearToken();
				console.log(error);
			}
		},

		async getUser(id: string) {
			const token = getToken();

			if (token == null) {
				return;
			}

			try {
				api.options.headers.Authorization = "Bearer " + token;
				const response = await api.get<User>("/" + id);
				this.userDictionary[id] = response;
			}
			catch (error) {
				//	NOTE(dalibor) This is not a correct behaviour. We should check if the response code is 401 and then clear the token.
				clearToken();
				console.log(error);
			}
		},
	},
});

  interface UserStore {
    user: User | null
	userDictionary: Record<string, User>
  }