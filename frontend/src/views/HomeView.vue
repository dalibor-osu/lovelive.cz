<script setup lang="ts">
import WelcomeParticle from '@/components/main/WelcomeParticle.vue';
import WelcomeImgSrc from '../assets/img/all_sunshine.png';

const welcomeImg = new Image();
welcomeImg.src = WelcomeImgSrc;
</script>

<template>
  <main class="main flex flex-col justify-center items-center">
    <section
      class="main__welcome relative overflow-hidden flex flex-col items-center justify-center w-full bg-gradient-to-t from-[#df067f] from-5% to-white to-90%">
      <div class="main__container relative z-10 max-w-[1280px] flex flex-col items-center justify-center select-none">
        <div class="main__welcome-title flex flex-col items-center justify-end mt-7">
          <h1
            class="main__welcome-item font-roboto text-5xl tablet:text-4xl mobile:text-3xl w-auto text-[#df067f] font-bold italic">
            Welcome to</h1>
          <div class="main__logo w-full h-full flex justify-end">
            <img src="../assets/logo_p.svg" alt="LoveLive! Czechia!!"
              class="h-[80px] tablet:h-[60px] mobile:h-[40px]">
          </div>
        </div>
        <div class="">
          <img :src="welcomeImg.src" rel="preload" alt="Welcome to LoveLive! Czechia!!"
            class="main__all-sunshine h-[730px] tablet:h-[541px] mobile:h-[341px] object-cover" />
        </div>
      </div>
      <WelcomeParticle class="main__particles absolute grid w-full h-full" />
    </section>
  </main>
</template>
