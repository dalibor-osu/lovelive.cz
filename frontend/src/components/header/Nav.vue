<script setup lang="ts" >
import { RouterLink } from "vue-router";
import { useUserStore } from "@/stores/userStore";
import constHelper from "../../assets/helper";

const userStore = useUserStore();
const menu: HTMLDivElement | null = document.querySelector("div.menu");
document.addEventListener('DOMContentLoaded', () => {
    if (userStore.isLoggedIn) {
        menu?.classList.remove("hidden", "mobile:flex");
        menu?.classList.add("flex", "mobile:hidden");
    }
});
</script>

<template>
    <nav class="header__nav w-9/12 mobile:w-0 flex items-center justify-end gap-1 font-roboto">
        <RouterLink to="/" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#CF888D] active:bg-[#CF888D] active:text-[#fff] dark:ring-[#CF888D] dark:text-[#CF888D]`"
            :active-class="`header__link--active text-[#fff] dark:text-[#fff] bg-[#CF888D]`" data-link-id="home">
            <span class="px-3">Home</span>
        </RouterLink>
        <RouterLink to="/about" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#CF888D] active:bg-[#CF888D] active:text-[#fff] dark:ring-[#CF888D] dark:text-[#CF888D] dark:active:bg-[#CF888D]`"
            :active-class="`header__link--active text-[#fff] dark:text-[#fff] bg-[#CF888D]`" data-link-id="about">
            <span class="px-3">About</span>
        </RouterLink>
        <RouterLink to="/posts" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#CF888D] active:bg-[#CF888D] active:text-[#fff] dark:ring-[#CF888D] dark:text-[#CF888D] dark:active:bg-[#CF888D]`"
            :active-class="`header__link--active text-[#fff] dark:text-[#fff] bg-[#CF888D]`" data-link-id="posts">
            <span class="px-3">Post</span>
        </RouterLink>
        <div v-if="!userStore.isLoggedIn" class="flex gap-1">
            <RouterLink to="/login" type="button"
                :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#CF888D] active:bg-[#CF888D] active:text-[#fff] dark:ring-[#CF888D] dark:text-[#CF888D] dark:active:bg-[#CF888D]`"
                :active-class="`header__link--active text-[#fff] dark:text-[#fff] bg-[#CF888D]`" data-link-id="login">
                <span class="px-3">Log in</span>
            </RouterLink>
            <RouterLink to="/register" type="button"
                :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#CF888D] active:bg-[#CF888D] active:text-[#fff] dark:ring-[#CF888D] dark:text-[#CF888D] dark:active:bg-[#CF888D]`"
                :active-class="`header__link--active text-[#fff] dark:text-[#fff] bg-[#CF888D]`" data-link-id="register">
                <span class="px-3">Sign up</span>
            </RouterLink>
        </div>
        <div class="other flex justify-end mobile:w-[100px]">
            <div v-if="userStore.isLoggedIn" class="profile flex items-center justify-center w-[70px] h-[55px]">
                <img class="rounded-full border-2 border-[#CF888D] w-[55px] h-[55px] dark:border-[#CF888D]"
                    :src="userStore.user?.profilePicture ?? 'https://i.pinimg.com/550x/18/b9/ff/18b9ffb2a8a791d50213a9d595c4dd52.jpg'"
                    @click="userStore.logoutUser">
                <!-- <p class="text-[#CF888D] font-bold">{{ userStore.user?.displayName }}</p> -->
            </div>
            <div class="menu hidden mobile:flex justify-center" type="button">
                <div
                    class="header__menu hidden mobile:flex transition-all duration-500 cursor-pointer w-[50px] h-[50px] items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg"
                        class="text-[#CF888D] open transition-all duration-700 dark:text-[#CF888D]" fill="none"
                        viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" width="40" height="40">
                        <path stroke-linecap="round" stroke-linejoin="round"
                            d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
                    </svg>
                </div>
            </div>
        </div>
    </nav>
</template>