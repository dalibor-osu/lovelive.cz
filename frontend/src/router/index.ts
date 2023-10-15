import { createRouter, createWebHistory } from "vue-router";
import HomeView from "../views/HomeView.vue";
import LoginView from "../views/LoginView.vue";
import RegisterView from "../views/RegisterView.vue";
import AboutView from "../views/AboutView.vue";
import PostsView from "../views/PostsView.vue";
import UserPageView from "../views/UserPageView.vue";
import UserPagePostsView from "../views/UserPagePostsView.vue";
import UserPageMyPostsView from "../views/UserPageMyPostsView.vue";
import UserPageFavouriteView from "../views/UserPageFavouriteView.vue";

const router = createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	routes: [
		{
			path: "/",
			name: "home",
			component: HomeView,
		},
		{
			path: "/home",
			redirect: "/",
		},
		{
			path: "/about",
			name: "about",
			component: AboutView,
		},
		{
			path: "/login",
			name: "login",
			component: LoginView,
		},
		{
			path: "/register",
			name: "register",
			component: RegisterView,
		},
		{
			path: "/posts",
			name: "posts",
			component: PostsView,
		},
		{
			path: "/user/:userId",
			name: "userPage",
			component: UserPageView,
			children: [
				{
					path: "",
					name: "userPagePosts",
					component: UserPagePostsView,
				},
				{
					path: "my_posts",
					name: "userPageMyPosts",
					component: UserPageMyPostsView,
				},
				{
					path: "favourite",
					name: "userPageFavourite",
					component: UserPageFavouriteView,
				},
			],
		},
	],
});

export default router;
