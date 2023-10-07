<script setup lang="ts">
import WelcomeParticle from '@/components/main/WelcomeParticle.vue';
import WelcomeImgSrc from '../assets/img/all_sunshine.png';
import Newsletter from '@/components/footer/Newsletter.vue';

const welcomeImg = new Image();
welcomeImg.src = WelcomeImgSrc;
</script>

<template>
  <main class="flex justify-center items-center">
    <section class="">
      <div class="">
        <div class="">
          <div class="">
          </div>
        </div>
        <div class="fixed flex items-center justify-center w-full h-full top-0 left-0">
          <img :src="welcomeImg.src" rel="preload" alt="Welcome to LoveLive! Czechia!!" class="w-full max-w-[1024px] relative top-16 mx-0 my-auto md:left-0 md:top-16 light:-z-10" />
          <img id="welcome-logo__center" src="../assets/logo_p.svg" alt="LoveLive! Czechia!!" class="hidden sm:block absolute top-[50%] left-[calc(50%-185px)] bg-white bg-opacity-75 z-10" />
        </div>
      </div>
    </section>
  </main>
  <Newsletter />
</template>
