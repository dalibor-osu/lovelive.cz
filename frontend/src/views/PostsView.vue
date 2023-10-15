<template>
	<div class="post my-16">
		<div class="post__container flex flex-col items-center gap-10">
			<NewPostForm v-if="isLoggedIn()" />
			<div v-for="post in posts" :key="post.id">
				<PostCard :post="post" />
			</div>
		</div>
	</div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "@/interfaces/post/post";
import { usePostStore } from "@/stores/postStore";
import NewPostForm from "../components/posts/NewPostForm.vue";
import PostCard from "../components/posts/PostCard.vue";
import { useUserStore } from "@/stores/userStore";

export default defineComponent({
	components: {
		NewPostForm,
		PostCard,
	},

	data() {
		return {
			posts: [] as Array<Post> | null,
			morePosts: true,
			loading: false,
		};
	},

	computed: {
		getPosts(): Array<Post> | null {
			const postStore = usePostStore();
			return postStore.posts;
		},
	},

	watch: {
		getPosts(newValue: Array<Post> | null) {
			this.posts = newValue;
		},
	},

	async mounted() {
		const postStore = usePostStore();
		await postStore.refreshPosts();
		this.scroll();
	},

	methods: {
		isLoggedIn() {
			const userStore = useUserStore();
			return userStore.isLoggedIn;
		},
		async loadMorePosts() {
			const postStore = usePostStore();
			const lastPost: Post | null = this.posts?.slice(-1)[0] ?? null;
			this.morePosts = await postStore.loadMorePosts(lastPost);
			this.loading = false;
		},

		async scroll() {
			window.onscroll = () => {
				const bottomOfWindow = Math.max(window.scrollY, document.documentElement.scrollTop, document.body.scrollTop) + window.innerHeight >= document.documentElement.offsetHeight - 300;
				if (bottomOfWindow && this.morePosts && !this.loading) {
					this.loading = true;
					this.loadMorePosts();
				}
			};
		},
	},
});
</script>