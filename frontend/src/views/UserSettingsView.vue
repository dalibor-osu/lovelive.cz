<template>
  <div>
    <h1>User Settings</h1>
    <UserSettingsForm />
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import UserSettingsForm from "@/components/user/UserSettingsForm.vue";

export default defineComponent({
	name: "UserSettingsView",
	components: {
		UserSettingsForm,
	},
	setup() {
		return {

		};
	},
});
</script>