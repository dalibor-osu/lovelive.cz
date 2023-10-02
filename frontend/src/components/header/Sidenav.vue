<script setup lang="ts">
import { RouterLink } from "vue-router";
import { useUserStore } from "@/stores/userStore";

const userStore = useUserStore();
</script>

<template>
  <nav
    :class="`sidenav fixed top-[82px] z-30 right-0 flex text-white bg-[#df067f] dark:bg-[#a7005c] w-0 h-full transition-[width] duration-500`">
    <div class="sidenav__box container p-2">
      <button class="sidenav__close flex justify-end w-[222px]">
        <svg class="cursor-pointer" xmlns="http://www.w3.org/2000/svg" height="40" viewBox="0 -960 960 960" width="40">
          <path fill="#fff"
            d="m251.333-204.667-46.666-46.666L433.334-480 204.667-708.667l46.666-46.666L480-526.666l228.667-228.667 46.666 46.666L526.666-480l228.667 228.667-46.666 46.666L480-433.334 251.333-204.667Z" />
        </svg>
      </button>

      <div class="sidenav__link flex flex-col flex-wrap gap-2">
        <RouterLink to="/" type="button" class="sidenav__link-item w-[222px] py-2 transition-colors text-[#df067f]"
          data-link-id="home" active-class="font-bold underline">
          <span>Home</span>
        </RouterLink>
        <RouterLink to="/about" type="button" class="sidenav__link-item w-[222px] py-2 transition-colors text-[#df067f]"
          data-link-id="about" active-class="font-bold underline">
          <span>About</span>
        </RouterLink>
        <RouterLink to="/posts" type="button" class="sidenav__link-item w-[222px] py-2 transition-colors text-[#df067f]"
          data-link-id="posts" active-class="font-bold underline">
          <span>Post</span>
        </RouterLink>
        <div v-if="!userStore.isLoggedIn" class="flex flex-col gap-2">
          <RouterLink to="/login" type="button" class="sidenav__link-item w-[222px] py-2 transition-colors text-[#df067f]"
            data-link-id="login" active-class="font-bold underline">
            <span>Log in</span>
          </RouterLink>
          <RouterLink to="/register" type="button" class="sidenav__link-item w-[222px] py-2 transition-colors text-[#df067f]"
            data-link-id="register" active-class="font-bold underline">
            <span>Sign up</span>
          </RouterLink>
        </div>
      </div>
    </div>
  </nav>
</template>