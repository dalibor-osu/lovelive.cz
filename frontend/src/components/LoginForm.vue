<script setup lang="ts">
import type { Login } from "@/interfaces/user/login";
import { RouterLink } from "vue-router";
import { useUserStore } from "@/stores/userStore";
import { ref } from "vue";
import constHelper from "../assets/helper";

const username = ref("");
const password = ref("");
const userStore = useUserStore();

const login = () => {
  const loginInfo: Login = {
    username: username.value,
    password: password.value,
  };

  userStore.loginUser(loginInfo);
};
</script>

<template>
  <div
    :class="`login__card flex items-center justify-center rounded-xl bg-gradient-to-br from-[#ffb7df] from-10% via-[#eb3298] via-70% to-[#e0007c] w-[375px] py-16 my-28`">
    <form class="login__form flex flex-col gap-5">
      <label class="login__username relative">
        <input v-model="username" type="text" placeholder="Username"
          :class="`login__username-input rounded-xl placeholder-white placeholder:text-[15px] text-white focus:outline-none bg-gradient-to-br from-[#960052] from-10% via-[#b30765] via-30% to-[#f53aa1] to-90% shadow-xl w-full max-w-[300px] pl-2 pr-10 h-10`">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
          class="w-6 h-6 absolute top-1/2 -translate-y-1/2 right-3 text-white">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z" />
        </svg>
      </label>
      <label class="login__password relative">
        <input v-model="password" type="password" placeholder="Password"
          :class="`login__password-input rounded-xl placeholder-white placeholder:text-[15px] text-white focus:outline-none bg-gradient-to-br from-[#960052] from-10% via-[#b30765] via-30% to-[#f53aa1] to-90% shadow-xl w-full max-w-[300px] pl-2 pr-10 h-10`">
        <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
          class="w-6 h-6 absolute top-1/2 -translate-y-1/2 right-3 text-white">
          <path stroke-linecap="round" stroke-linejoin="round"
            d="M16.5 10.5V6.75a4.5 4.5 0 10-9 0v3.75m-.75 11.25h10.5a2.25 2.25 0 002.25-2.25v-6.75a2.25 2.25 0 00-2.25-2.25H6.75a2.25 2.25 0 00-2.25 2.25v6.75a2.25 2.25 0 002.25 2.25z" />
        </svg>
      </label>
      <label class="text-white text-sm flex items-center gap-2">
        <input checkbox type="checkbox"
          class="w-3 h-3 rounded-xl ring-2 ring-white appearance-none checked:bg-gradient-to-br checked:from-[#ffffff] checked:to-[#ffffff] checked:ring-0">
        Remember me
      </label>
      <div class="login__button flex justify-between items-center">
        <button type="button" @click="login"
          :class="`w-24 h-10 rounded-xl bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% mobile:from-[#960052] mobile:to-[#f53aa1] text-sm font-semibold text-white shadow-xl`">
          Log in
        </button>
        <a href="#" class="text-white text-sm underline h-10 flex items-center">Forgot password?</a>
      </div>
      <div class="text-white mt-5 flex gap-1">
        <span class="font-bold text-xs">Don't have an account?</span>
        <RouterLink to="/register" class="text-white text-xs underline flex items-center" data-link-id="register">
            Register!
        </RouterLink>
      </div>
    </form>
  </div>
</template>