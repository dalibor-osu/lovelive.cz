import type { Post } from "@/interfaces/post/post";
import { defineStore } from "pinia";
import { mande } from "mande";
import Cookies from "js-cookie";
import type { LikeResult } from "@/interfaces/post/likeResult";

const api = mande(`${window.location.origin}/api/post`);
const interactionApi = mande(`${window.location.origin}/api/interaction`);

const setToken = (token: string) => {
	Cookies.set("token", token);
	api.options.headers.Authorization = "Bearer " + token;
	interactionApi.options.headers.Authorization = "Bearer " + token;
};

const getToken = (): string | null => {
	return Cookies.get("token") ?? null;
};

const refreshToken = (): string | null => {
	const token = getToken();
	if (token !== null) {
		setToken(token);
	}
	return token;
};

const usePostStore = defineStore("post", {
	state: (): PostState => {
		return {
			posts: [] as Array<Post>,
		};
	},

	actions: {
		async refreshPosts(): Promise<void> {
			try {
				refreshToken();
				api.options.query = { limit: 10 };
				const posts = await api.get<Array<Post>>("/list");
				this.posts = posts;
			}
			catch (error) {
				console.error(error);
			}
			finally {
				api.options.query = {};
			}

			return;
		},

		async refreshPostsForUser(userId: string): Promise<void> {
			try {
				refreshToken();
				api.options.query = { parentId: userId, limit: 10 };
				const posts = await api.get<Array<Post>>("/list");
				this.posts = posts;
			}
			catch (error) {
				console.error(error);
			}
			finally {
				api.options.query = {};
			}

			return;
		},

		async createPost(data: FormData): Promise<void> {
			const token: string | null = getToken();
			const request = new XMLHttpRequest();
			request.open("POST", "api/post", false);
			request.setRequestHeader("Authorization", "Bearer " + token ?? "");
			request.send(data);
			await this.refreshPosts();
		},

		async loadMorePosts(lastPost: Post | null): Promise<boolean> {
			try {
				refreshToken();
				api.options.query = { limit: 10 };

				if (lastPost?.created !== null) {
					Object.assign(api.options.query, { lastItemCreatedAt: (new Date(lastPost!.created)).toISOString() });
				}

				const posts = await api.get<Array<Post>>("/list");
				this.posts?.push(...posts);

				return posts.length >= 10;
			}
			catch (error) {
				console.error(error);
			}
			finally {
				api.options.query = {};
			}

			return false;
		},

		async like(postId: string): Promise<boolean | null> {
			try {
				refreshToken();
				const response = await interactionApi.post<LikeResult>(`/like/${postId}`);
				const postIdx = this.posts.findIndex((post) => post.id === response.postId);

				if (postIdx === null) {
					return null;
				}

				this.posts[postIdx].likeCount += response.liked ? 1 : -1;
				this.posts[postIdx].liked = response.liked;
				return response.liked;
			}
			catch (error) {
				console.error(error);
				return null;
			}
		},
	},
});

interface PostState {
    posts: Array<Post>,
}

export { usePostStore };
export type { PostState };