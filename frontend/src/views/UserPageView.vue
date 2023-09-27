<script setup lang="ts">
import PostCard from "../components/posts/PostCard.vue";
</script>

<template>
  <div class="user-container">
    <img :src="user?.profilePicture" alt="user photo">
    <h1>{{ user?.displayName }}</h1>
  </div>
  <div class="post-container">
    <ul class="post-list">
      <li v-for="post in posts" :key="post.id">
        <PostCard :post="post" />
      </li>
    </ul>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "@/interfaces/post/post";
import type { User } from "@/interfaces/user/user";
import { usePostStore } from "@/stores/postStore";
import { useUserStore } from "@/stores/userStore";

export default defineComponent({
	data() {
		return {
			posts: [] as Array<Post> | null,
			user: null as User | null,
		};
	},

	computed: {
		getPosts(): Array<Post> | null {
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
		getPosts(newValue: Array<Post> | null) {
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

<style>
.post-container {
  text-align: center;
}
.post-list {
  display: inline-block;
  text-align: left;
}
</style>