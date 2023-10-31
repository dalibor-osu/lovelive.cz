<template>
	<div class="user-settings flex items-center justify-center py-10">
		<div class="user-settings__container">
			<div class="user-settings__card w-full h-full rounded-lg bg-pink-100 p-5">
				<UserSettingsForm />
			</div>
		</div>
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