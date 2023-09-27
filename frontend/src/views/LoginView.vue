<script setup lang="ts">
import LoginForm from "../components/LoginForm.vue";
</script>

<template>
  <div class="login flex justify-center">
    <LoginForm />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useUserStore } from "@/stores/userStore";

export default defineComponent({
	computed: {
		isLoggedIn(): boolean {
			const userStore = useUserStore();
			return userStore.isLoggedIn;
		},
	},

	watch: {
		isLoggedIn(newValue: boolean) {
			if (newValue === true) {
				this?.$router.push("/");
			}
		},
	},
});
</script>