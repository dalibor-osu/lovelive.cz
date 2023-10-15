<template>
	<div class="post my-16">
		<div class="post__container flex flex-col items-center gap-10">
			<div v-for="post in posts" :key="post.id">
				<PostCard :post="post" />
			</div>
		</div>
	</div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "@/interfaces/post/post";
import type { User } from "@/interfaces/user/user";
import { usePostStore } from "@/stores/postStore";
import { useUserStore } from "@/stores/userStore";
import PostCard from "../components/posts/PostCard.vue";

export default defineComponent({
	components: {
		PostCard,
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