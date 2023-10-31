<script setup lang="ts">

import Logo from "./Logo.vue";
import Nav from "./Nav.vue";
import Animation_header from "../animations/Header_a.vue";
import constHelper from "../../assets/helper";

</script>

<template>
  <header :class="`header w-full h-[82px] flex bg-white fixed top-0 left-0 z-50`">
    <div class="header__container flex w-full h-[72px] relative items-center justify-between mx-[20px]">
      <Logo />
      <Nav />
    </div>
    <Animation_header />
  </header>
</template>