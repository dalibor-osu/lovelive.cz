<script setup lang="ts">
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
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white dark:text-white dark:bg-none dark:hover:ring-[2px] dark:hover:ring-inset dark:hover:ring-white`"
            active-class="header__link--active bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% text-sm font-semibold text-white dark:bg-white dark:text-black"
            data-link-id="home">
            <span class="px-3">Home</span>
        </RouterLink>
        <RouterLink to="/about" type="button"
        :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white dark:text-white dark:bg-none dark:hover:ring-[2px] dark:hover:ring-inset dark:hover:ring-white`"
            active-class="header__link--active bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% text-sm font-semibold text-white dark:bg-white dark:text-black"
            data-link-id="about">
            <span class="px-3">About</span>
        </RouterLink>
        <RouterLink to="/posts" type="button"
        :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white dark:text-white dark:bg-none dark:hover:ring-[2px] dark:hover:ring-inset dark:hover:ring-white`"
            active-class="header__link--active bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% text-sm font-semibold text-white dark:bg-white dark:text-black"
            data-link-id="posts">
            <span class="px-3">Post</span>
        </RouterLink>
        <div v-if="!userStore.isLoggedIn" class="flex gap-1">
            <RouterLink to="/login" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white dark:text-white dark:bg-none dark:hover:ring-[2px] dark:hover:ring-inset dark:hover:ring-white`"
            active-class="header__link--active bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% text-sm font-semibold text-white dark:bg-white dark:text-black"
                data-link-id="login">
                <span class="px-3">Log in</span>
            </RouterLink>
            <RouterLink to="/register" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white dark:text-white dark:bg-none dark:hover:ring-[2px] dark:hover:ring-inset dark:hover:ring-white`"
            active-class="header__link--active bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% text-sm font-semibold text-white dark:bg-white dark:text-black"
                data-link-id="register">
                <span class="px-3">Sign up</span>
            </RouterLink>
        </div>
        <div class="header__dropdown mobile:hidden relative text-left">
            <div class="header__dropdown-item">
                <button id="menu-button" type="button"
                    :class="`inline-flex w-full justify-center rounded-xl bg-white px-3 py-3 text-sm font-semibold text-[#df067f] shadow-sm ring-[2px] ring-inset ring-[#df067f] hover:bg-gradient-to-br hover:from-[#f53aa1] hover:from-10% hover:via-[#b30765] hover:via-70% hover:to-[#960052] hover:to-90% hover:text-white hover:ring-0 group dark:ring-white dark:bg-[${constHelper.darkColor}] dark:hover:from-white dark:hover:to-white dark:text-white dark:hover:text-black`">
                    <spa>More</spa>
                    <svg :class="`-mr-1 h-5 w-5 text-[#df067f] group-hover:text-white dark:text-white dark:group-hover:text-black`" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                        <path fill-rule="evenodd"
                            d="M5.23 7.21a.75.75 0 011.06.02L10 11.168l3.71-3.938a.75.75 0 111.08 1.04l-4.25 4.5a.75.75 0 01-1.08 0l-4.25-4.5a.75.75 0 01.02-1.06z"
                            clip-rule="evenodd" />
                    </svg>
                </button>
            </div>
            <div id="dropdown-content"
                :class="`dropdown__content hidden absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-[#df067f] ring-opacity-5 focus:outline-none dark:ring-white dark:bg-[${constHelper.darkColor}]`"
                role="menu" aria-orientation="vertical" aria-labelledby="menu-button" tabindex="-1">
                <div class="py-1 flex flex-col" role="none">
                    <RouterLink to="/" type="button"
                    :class="`header__link-dropdown-item hidden font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]`"
                        active-class="header__link--active" data-link-id="home">
                        <span>Home</span>
                    </RouterLink>
                    <RouterLink to="/about" type="button"
                    :class="`header__link-dropdown-item hidden font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]`"
                        active-class="header__link--active" data-link-id="about">
                        <span>About</span>
                    </RouterLink>
                    <RouterLink to="/posts" type="button"
                    :class="`header__link-dropdown-item hidden font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]`"
                        active-class="header__link--active" data-link-id="posts">
                        <span>Post</span>
                    </RouterLink>
                    <div v-if="!userStore.isLoggedIn" class="flex flex-col">
                        <RouterLink to="/login" type="button"
                        :class="`header__link-dropdown-item hidden font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]`"
                            active-class="header__link--active" data-link-id="login">
                            <span>Log in</span>
                        </RouterLink>
                        <RouterLink to="/register" type="button"
                            :class="`header__link-dropdown-item hidden font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]`"
                            active-class="header__link--active" data-link-id="register">
                            <span>Sign up</span>
                        </RouterLink>
                    </div>
                </div>
            </div>
        </div>
        <div class="other flex justify-end mobile:w-[100px]">
            <div v-if="userStore.isLoggedIn" class="profile flex items-center justify-center w-[70px] h-[55px]">
                <img class="rounded-full border-2 border-[#df067f] w-[55px] h-[55px] dark:border-white"
                    :src="userStore.user?.profilePicture ?? 'https://i.pinimg.com/550x/18/b9/ff/18b9ffb2a8a791d50213a9d595c4dd52.jpg'"
                    @click="userStore.logoutUser">
                <!-- <p class="text-[#df067f] font-bold">{{ userStore.user?.displayName }}</p> -->
            </div>
            <div class="menu hidden mobile:flex justify-center" type="button">
                <div
                    class="header__menu hidden mobile:flex transition-all duration-500 cursor-pointer w-[50px] h-[50px] items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg" class="text-[#df067f] open transition-all duration-700 dark:text-white"
                        fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" width="40" height="40">
                        <path stroke-linecap="round" stroke-linejoin="round"
                            d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
                    </svg>
                </div>
            </div>
        </div>
    </nav>
</template>