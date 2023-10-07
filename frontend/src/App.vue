<script setup lang="ts">
import { RouterView } from "vue-router";
import Header from "./components/header/Header.vue";
import Footer from "./components/footer/Footer.vue";
import Sidenav from "./components/header/Sidenav.vue";
import ArrowDown from "./components/darkmode/ArrowDown.vue"
import { useUserStore } from "./stores/userStore";
import constHelper from "./assets/helper";

const sawDisclaimer = localStorage.getItem("sawDisclaimer");
if (sawDisclaimer === null) {
	alert("Welcome to Love Live! Czechia!!. This is a new version of the website that is still WIP. Things ARE and GONNA BE broken. Keep that in mind :)");
	localStorage.setItem("sawDisclaimer", "true");
}

const userStore = useUserStore();
userStore.getCurrentUser();
</script>

<template>
  <div :class="`min-h-screen flex flex-col justify-between dark:bg-[#343031]`">
    <Header />
    <div class="space" />
    <Sidenav />
    <RouterView />
    <Footer />
    <ArrowDown />
  </div>
</template>./components/header/Header.vue