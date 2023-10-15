<template>
	<div v-if="user != null" class="user__container">
		<div class="user__banner flex flex-col justify-center items-center w-full h-[330px] mobile:h-[220px] relative">
			<!-- <img src="" alt="User banner"> -->
			<img :src="userHelper.getUserBannerPath(user)" alt="User banner"
				class="w-full h-[330px] mobile:h-[220px] object-cover">
			<div class="absolute w-full h-full top-0 left-0 bg-gradient-to-t from-[#00000083] from-1% to-transparent" />
			<idv class="absolute bottom-0 left-0 w-full">
				<div class="m-auto w-[720px] tablet:w-[600px] mobile:w-[320px] relative">
					<!-- <img :src="userHelper.getUserAvatarPath(user!)" alt="User profile picture"> -->
					<div class="flex justify-between items-end">
						<div class="flex gap-3 mobile:gap-1 items-end">
							<img :src="userHelper.getUserAvatarPath(user)" alt="User profile picture"
								class="max-w-[230px] max-h-[230px] mobile:max-w-[115px] mobile:max-h-[115px]">
							<div class="flex flex-col items-end py-5 text-white">
								<h1 class="font-bold text-xl mobile:text-base">{{ user?.displayName }}</h1>
								<h1 class="text-base mobile:text-sm">@{{ user?.username }}</h1>
							</div>
						</div>
						<button
							class="cursor-not-allowed flex justify-center items-center rounded-xl my-5 py-1 px-3 font-bold text-sm text-white ring-2 ring-inset ring-white active:bg-white active:text-[#df067f] dark:ring-white dark:bg-[#282b30] dark:text-white dark:active:text-black dark:active:bg-white">
							Edit
						</button>
					</div>
				</div>
			</idv>
		</div>
		<div class="m-auto py-5 w-[720px] tablet:w-[600px] mobile:w-[320px]">
			<p class="bio text-justify text-base mobile:text-sm mobile:px-2 dark:text-white">
				{{ user.bio ?? "No bio" }}
			</p>
		</div>
	</div>
	<nav class="user__nav text-[#df067f] flex justify-center gap-10 border-b-[5px] border-[#df067f] h-[49px] relative">
		<div class="absolute">
			<RouterLink :to="`/user/${user?.id}`" class="py-[10px] px-4"
				active-class="border-b-[5px] border-white dark:border-[#282b30]" type="button" data-link-id="posts">
				Posts
			</RouterLink>
			<button class="py-[10px] px-4 cursor-not-allowed hidden" active-class="border-b-[5px] border-white" type="button"
				data-link-id="my_posts">
				My Posts
			</button>
			<button class="py-[10px] px-4 cursor-not-allowed" active-class="border-b-[5px] border-white" type="button"
				data-link-id="favourite">
				Favourite
			</button>
		</div>
	</nav>
	<div>
		<RouterView />
	</div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "@/interfaces/post/post";
import type { User } from "@/interfaces/user/user";
import { usePostStore } from "@/stores/postStore";
import { useUserStore } from "@/stores/userStore";
import userHelper from "@/helpers/userHelper";
import { RouterView } from "vue-router";

export default defineComponent({
	setup() {
		return {
			userHelper,
		};
	},

	data() {
		return {
			posts: [] as Array<Post>,
			user: null as User | null,
		};
	},

	computed: {
		getPosts(): Array<Post> {
			const postStore = usePostStore();
			return postStore.posts;
		},

		getUser(): User | null {
			const userStore = useUserStore();
			const userId: string = this.$route.params.userId as string;
			return userStore.userDictionary[userId];
		},
	},

	watch: {
		getPosts(newValue: Array<Post>) {
			this.posts = newValue;
		},

		getUser(newValue: User | null) {
			this.user = newValue;
		},
	},

	async mounted() {
		const postStore = usePostStore();
		const userStore = useUserStore();
		const userId: string = this.$route.params.userId as string;
		await userStore.getUser(userId);

		if (this.getUser == null) {
			this.$router.push("/");
			return;
		}

		await postStore.refreshPostsForUser(userId);
	},
});
</script>