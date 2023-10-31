<template>
  <form enctype="multipart/form-data" method="post" name="userSettingsForm" class="flex flex-col gap-4">
    <section class="avatar flex flex-col gap-2">
      <div class="text-[#a0346a] text-justify dark:text-white">
        <h1 class="text-xl font-bold">
          Avatar
        </h1>
        <p>Allowed Formats: JPEG, PNG, GIF. Optimal dimensions: 230x230.</p>
      </div>
      <div class="avatar-block flex gap-7 flex-wrap mobile:gap-5">
        <div class="flex items-center justify-center w-[200px] h-[200px]">
          <label for="userSettingsAvatarInput"
                 class="flex flex-col items-center justify-center w-full h-full rounded-lg cursor-pointer bg-[#ff0b85] dark:bg-[#940d57] p-5">
            <div
              class="flex flex-col items-center justify-center w-full h-full border-white border-dashed border-2 text-white">
              <p>Click to upload or</p>
              <p>drag and drop</p>
            </div>
            <input id="userSettingsAvatarInput" type="file" name="Avatar" multiple="false" class="hidden"
                   accept="image/jpeg, image/png, image/gif" @change="onAvatarChange($event)">
          </label>
        </div>
        <div
          class="flex items-center justify-center w-[200px] h-[200px] bg-[#ff0b85] dark:bg-[#940d57] rounded-lg text-white">
          <img v-if="avatarPreviewUrl != &quot;&quot;" :src="avatarPreviewUrl" alt="avatarPreview">
          <p v-else>
            Preview
          </p>
        </div>
      </div>
    </section>
    <section class="banner flex flex-col gap-2">
      <div class="text-[#a0346a] text-justify dark:text-white">
        <h1 class="text-xl font-bold">
          Banner
        </h1>
        <p>Allowed Formats: JPEG, PNG, GIF. Optimal dimensions: 1920x330.</p>
      </div>
      <div class="banner-block flex gap-7 flex-wrap mobile:gap-5">
        <div class="flex items-center justify-center w-[200px] h-[200px]">
          <label for="userSettingsBannerInput"
                 class="flex flex-col items-center justify-center w-full h-full rounded-lg cursor-pointer bg-[#ff0b85] dark:bg-[#940d57] p-5">
            <div
              class="flex flex-col items-center justify-center w-full h-full border-white border-dashed border-2 text-white">
              <p>Click to upload or</p>
              <p>drag and drop</p>
            </div>
            <input id="userSettingsBannerInput" type="file" name="Banner" multiple="false"
                   accept="image/jpeg, image/png, image/gif" class="hidden" @change="onBannerChange($event)">
          </label>
        </div>
        <div
          class="flex items-center justify-center w-[530px] mobile:w-[200px] h-[200px] bg-[#ff0b85] dark:bg-[#940d57] rounded-lg text-white">
          <img v-if="bannerPreviewUrl != &quot;&quot;" :src="bannerPreviewUrl" alt="bannerPreview">
          <p v-else>
            Preview
          </p>
        </div>
      </div>
    </section>
    <section class="display-name flex flex-col gap-2">
      <div class="text-[#a0346a] dark:text-white">
        <h1 class="text-xl font-bold">
          Display Name
        </h1>
      </div>
      <label for="userSettingsDisplayNameInput">
        <input id="userSettingsDisplayNameInput" type="text" name="DisplayName" placeholder="Display Name"
               :value="displayName"
               class="w-full h-10 p-2 rounded-lg bg-[#ff0b85] dark:bg-[#940d57] text-white focus:outline-none placeholder:text-white">
      </label>
    </section>
    <section class="theme flex flex-col gap-2">
      <div class="text-[#a0346a] dark:text-white">
        <h1 class="text-xl font-bold">
          Theme
        </h1>
      </div>
      <div className="flex items-start gap-2 flex-wrap">
        <ThemeButton label="default" />
        <ThemeButton label="light" />
        <ThemeButton label="dark" />
        <ThemeButton label="muse" />
        <ThemeButton label="aqours" />
        <ThemeButton label="nijigasaki" />
        <ThemeButton label="liella" />
        <ThemeButton label="hasunosora" />
      </div>
    </section>
    <button type="button" class="w-36 h-10 rounded-lg bg-[#ff0b85] dark:bg-[#940d57] text-white font-bold"
            @click="submitSettings">
      Update
    </button>
  </form>
</template>

<script lang="ts">
import ThemeButton from "@/components/user/ThemeButton.vue";

import { defineComponent } from "vue";
import { useUserStore } from "../../stores/userStore";
import type { FullUser } from "@/interfaces/user/fullUser";

export default defineComponent({
	name: "UserSettingsForm",
	components: {
		ThemeButton,
	},
	setup() {
		return {};
	},
	data() {
		return {
			user: null as null | FullUser,
			displayName: "",
			avatarPreviewUrl: "",
			bannerPreviewUrl: "",
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
		onAvatarChange(e: Event): void {
			const htmlElement = e.target as HTMLInputElement;
			if (htmlElement?.files == null) {
				return;
			}
			const file = htmlElement.files[0];
			this.avatarPreviewUrl = URL.createObjectURL(file);
		},
		onBannerChange(e: Event): void {
			const htmlElement = e.target as HTMLInputElement;
			if (htmlElement?.files == null) {
				return;
			}
			const file = htmlElement.files[0];
			this.bannerPreviewUrl = URL.createObjectURL(file);
		},
	},
});
</script>