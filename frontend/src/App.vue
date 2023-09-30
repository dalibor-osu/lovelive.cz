<script setup lang="ts">
import { RouterView } from "vue-router";
import Header from "./components/header/Header.vue";
import Footer from "./components/footer/Footer.vue";
import Sidenav from "./components/header/Sidenav.vue";
import { useUserStore } from "./stores/userStore";
import { darkColor } from "./assets/helper";

const userStore = useUserStore();
userStore.getCurrentUser();
</script>

<template>
  <div :class="`min-h-screen flex flex-col justify-between dark:bg-[${darkColor}]`">
    <Header />
    <div class="space" />
    <Sidenav />
    <RouterView />
    <Footer />
  </div>
</template>./components/header/Header.vue