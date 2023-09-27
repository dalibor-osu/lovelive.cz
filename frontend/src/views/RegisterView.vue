<script setup lang="ts">
import RegisterForm from "../components/RegisterForm.vue";
</script>

<template>
  <div class="register flex justify-center">
    <RegisterForm />
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