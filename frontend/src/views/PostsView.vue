<script setup lang="ts">
import NewPostForm from "../components/posts/NewPostForm.vue";
import PostCard from "../components/posts/PostCard.vue";
import { useUserStore } from "@/stores/userStore";

const userStore = useUserStore();
</script>

<template>
  <div class="post my-5">
    <div v-if="userStore.isLoggedIn" class="post__container flex flex-col items-center">
      <NewPostForm />
      <ul class="post-list">
        <li v-for="post in posts" :key="post.id" class="mt-10">
          <PostCard :post="post" />
        </li>
      </ul>
    </div>
    <div v-else class="post__container flex flex-col items-center">
      <ul class="post-list">
        <li v-for="post in posts" :key="post.id" class="mt-10">
          <PostCard :post="post" />
        </li>
      </ul>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "@/interfaces/post/post";
import { usePostStore } from "@/stores/postStore";

export default defineComponent({
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
		async loadMorePosts() {
			const postStore = usePostStore();
			const lastPost : Post | null = this.posts?.slice(-1)[0] ?? null;
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