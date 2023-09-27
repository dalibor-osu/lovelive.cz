<script setup lang="ts">
import { RouterLink } from "vue-router";
</script>

<template>
  <div class="header__logo w-2/12 mobile:min-w-[150px] flex items-center justify-start">
    <RouterLink to="/" data-link-id="home">
      <img src="../../assets/logo_p.svg" alt="LoveLive! Czechia!!" class="logo w-[190px] h-[74px]">
    </RouterLink>
  </div>
</template>