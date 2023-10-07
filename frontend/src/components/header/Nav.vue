<script setup lang="ts" >
import { RouterLink } from "vue-router";
import { useUserStore } from "@/stores/userStore";
import constHelper from "../../assets/helper";
import { ref, onMounted, onUnmounted } from "vue";
import { vOnClickOutside } from '@vueuse/components';

const userStore = useUserStore();
const menu: HTMLDivElement | null = document.querySelector("div.menu");
document.addEventListener('DOMContentLoaded', () => {
    if (userStore.isLoggedIn) {
        menu?.classList.remove("hidden", "mobile:flex");
        menu?.classList.add("flex", "mobile:hidden");
    }
});

const isVisiblePfDropdown = ref(false);

const toggleDropdown = () => {
    isVisiblePfDropdown.value = !isVisiblePfDropdown.value;
}

onMounted(() => {
    const handleResize = () => {
        isVisiblePfDropdown.value = false;
    };

    window.addEventListener('resize', handleResize);

    // Zrušíme posluchač události resize při zničení komponenty (unmount)
    onUnmounted(() => {
        window.removeEventListener('resize', handleResize);
    });
});

function closeDropdown() {
    isVisiblePfDropdown.value = false
}
</script>

<template>
    <nav class="header__nav w-9/12 mobile:w-0 flex items-center justify-end gap-1 font-roboto">
        <RouterLink to="/" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:ring-2 ring-inset ring-[#df067f] active:bg-[#df067f] active:text-white dark:ring-white dark:bg-[${constHelper.darkColor}] dark:text-white dark:active:text-black dark:active:bg-white`"
            :active-class="`header__link--active text-white bg-[#df067f] ring-2`" data-link-id="home">
            <span class="px-3">Home</span>
        </RouterLink>
        <RouterLink to="/about" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:ring-2 ring-inset ring-[#df067f] active:bg-[#df067f] active:text-white dark:ring-white dark:bg-[${constHelper.darkColor}] dark:text-white dark:active:text-black dark:active:bg-white`"
            :active-class="`header__link--active text-white bg-[#df067f] ring-2`" data-link-id="about">
            <span class="px-3">About</span>
        </RouterLink>
        <RouterLink to="/posts" type="button"
            :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:ring-2 ring-inset ring-[#df067f] active:bg-[#df067f] active:text-white dark:ring-white dark:bg-[${constHelper.darkColor}] dark:text-white dark:active:text-black dark:active:bg-white`"
            :active-class="`header__link--active text-white bg-[#df067f] ring-2`" data-link-id="posts">
            <span class="px-3">Post</span>
        </RouterLink>
        <div v-if="!userStore.isLoggedIn" class="flex gap-1">
            <RouterLink to="/login" type="button"
                :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:ring-2 ring-inset ring-[#df067f] active:bg-[#df067f] active:text-white dark:ring-white dark:bg-[${constHelper.darkColor}] dark:text-white dark:active:text-black dark:active:bg-white`"
                :active-class="`header__link--active text-white bg-[#df067f] ring-2`" data-link-id="login">
                <span class="px-3">Log in</span>
            </RouterLink>
            <RouterLink to="/register" type="button"
                :class="`header__link flex justify-center items-center rounded-xl mobile:hidden py-3 px-2 font-bold text-sm text-[#df067f] hover:ring-2 ring-inset ring-[#df067f] active:bg-[#df067f] active:text-white dark:ring-white dark:bg-[${constHelper.darkColor}] dark:text-white dark:active:text-black dark:active:bg-white`"
                :active-class="`header__link--active text-white bg-[#df067f] ring-2`" data-link-id="register">
                <span class="px-3">Sign up</span>
            </RouterLink>
        </div>
        <div class="header__dropdown mobile:hidden relative text-left">
            <div class="header__dropdown-item">
                <button id="menu-button" type="button"
                    :class="`inline-flex w-full justify-center rounded-xl bg-white px-3 py-3 text-sm font-semibold text-[#df067f] shadow-sm ring-[2px] ring-inset ring-[#df067f] hover:bg-[#df067f] hover:text-white hover:ring-0 group dark:ring-white dark:bg-[${constHelper.darkColor}] dark:hover:bg-white dark:text-white dark:hover:text-black`">
                    <span>More</span>
                    <svg :class="`-mr-1 h-5 w-5 text-[#df067f] group-hover:text-white dark:text-white dark:group-hover:text-black`"
                        viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
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
        <div class="other flex justify-end mobile:w-[110px]">
            <div v-on-click-outside="closeDropdown">
                <div v-if="userStore.isLoggedIn" class="profile flex items-center justify-center w-[70px] h-[55px]">
                    <img @click="toggleDropdown"
                        class="profile__img rounded-full border-2 border-[#df067f] w-[55px] h-[55px] dark:border-white"
                        :src="userStore.user?.profilePicture ?? 'https://i.pinimg.com/550x/18/b9/ff/18b9ffb2a8a791d50213a9d595c4dd52.jpg'">
                </div>
                <div id="profile-dropdown"
                    :class="isVisiblePfDropdown === false ? `hidden` : `profile__dropdown-content absolute right-0 z-10 mt-2 w-56 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-[#df067f] ring-opacity-5 focus:outline-none dark:ring-white dark:bg-[${constHelper.darkColor}]`">
                    <div class="py-1 flex flex-col px-2" role="none">
                        <p class="text-[#df067f] font-extrabold px-1 py-2 dark:text-white text-center">{{
                            userStore.user?.displayName }}</p>
                        <hr>
                        <RouterLink to="/user/:userId" type="button" @click="closeDropdown"
                            class="flex items-center gap-1 font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]"
                            data-link-id="userPage">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round"
                                    d="M15.75 6a3.75 3.75 0 11-7.5 0 3.75 3.75 0 017.5 0zM4.501 20.118a7.5 7.5 0 0114.998 0A17.933 17.933 0 0112 21.75c-2.676 0-5.216-.584-7.499-1.632z" />
                            </svg>
                            <span>Profile</span>
                        </RouterLink>
                        <a type="button" @click="closeDropdown"
                            class="flex items-center gap-1 font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round"
                                    d="M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.324.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 011.37.49l1.296 2.247a1.125 1.125 0 01-.26 1.431l-1.003.827c-.293.24-.438.613-.431.992a6.759 6.759 0 010 .255c-.007.378.138.75.43.99l1.005.828c.424.35.534.954.26 1.43l-1.298 2.247a1.125 1.125 0 01-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.57 6.57 0 01-.22.128c-.331.183-.581.495-.644.869l-.213 1.28c-.09.543-.56.941-1.11.941h-2.594c-.55 0-1.02-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 01-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 01-1.369-.49l-1.297-2.247a1.125 1.125 0 01.26-1.431l1.004-.827c.292-.24.437-.613.43-.992a6.932 6.932 0 010-.255c.007-.378-.138-.75-.43-.99l-1.004-.828a1.125 1.125 0 01-.26-1.43l1.297-2.247a1.125 1.125 0 011.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.087.22-.128.332-.183.582-.495.644-.869l.214-1.281z" />
                                <path stroke-linecap="round" stroke-linejoin="round" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                            </svg>
                            <span>Settings</span>
                        </a>
                        <hr>
                        <a type="button"
                            class="flex items-center gap-1 font-bold text-sm text-[#df067f] px-1 py-2 hover:bg-[#ffe9f5] dark:text-white dark:hover:bg-white dark:hover:text-[#000000]"
                            @click="userStore.logoutUser(); closeDropdown();">
                            <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5"
                                stroke="currentColor" class="w-6 h-6">
                                <path stroke-linecap="round" stroke-linejoin="round"
                                    d="M15.75 9V5.25A2.25 2.25 0 0013.5 3h-6a2.25 2.25 0 00-2.25 2.25v13.5A2.25 2.25 0 007.5 21h6a2.25 2.25 0 002.25-2.25V15M12 9l-3 3m0 0l3 3m-3-3h12.75" />
                            </svg>
                            <span>Log out</span>
                        </a>
                    </div>
                </div>
            </div>
            <div class="menu hidden mobile:flex justify-center" type="button">
                <div
                    class="header__menu hidden mobile:flex transition-all duration-500 cursor-pointer w-[50px] h-[50px] items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg"
                        class="text-[#df067f] open transition-all duration-700 dark:text-white" fill="none"
                        viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" width="40" height="40">
                        <path stroke-linecap="round" stroke-linejoin="round"
                            d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" />
                    </svg>
                </div>
            </div>
        </div>
    </nav>
</template>