<template>
  <form enctype="multipart/form-data" method="post" name="userSettingsForm">
	<label for="userSettingsAvatarInput">Avatar</label>
    <input id="userSettingsAvatarInput" type="file" name="Avatar" multiple="false" accept="image/jpeg, image/png, image/gif">
	<label for="userSettingsBannerInput">Banner</label>
    <input id="userSettingsBannerInput" type="file" name="Banner" multiple="false" accept="image/jpeg, image/png, image/gif">
	<label for="userSettingsDisplayNameInput">Display Name</label>
    <input id="userSettingsDisplayNameInput" type="text" name="DisplayName" placeholder="Display Name" :value="displayName">
    <button type="button" @click="submitSettings">
      Submit
    </button>
  </form>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { useUserStore } from "../../stores/userStore";
import type { FullUser } from "@/interfaces/user/fullUser";

export default defineComponent({
	name: "UserSettingsForm",
	setup() {
		return {

		};
	},

	data() {
		return {
			user: null as null | FullUser,
			displayName: "",
		};
	},

	mounted() {
		const userStore = useUserStore();
		const user: null | FullUser = userStore.user;

		if (user === null) {
			this.$router.push("/login");
			return;
		}

		this.user = user;
		this.displayName = user.displayName ?? "";
	},
	methods: {
		async submitSettings(): Promise<void> {
			const form = document.forms.namedItem("userSettingsForm");
			const formData = new FormData(form as HTMLFormElement);
			const userStore = useUserStore();
			await userStore.updateUser(formData);
		},
	},
});
</script>