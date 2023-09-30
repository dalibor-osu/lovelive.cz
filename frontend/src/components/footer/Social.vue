<script setup lang="ts">
import { RouterLink } from "vue-router";
</script>

<template>
    <section id="footer-social" class="w-full h-auto bg-[#df067f] py-12 text-white">
        <div
            class="footer__container max-w-[1280px] tablet:max-w-[720px] mobile:max-w-[320px] mx-auto flex justify-between">
            <div class="footer__items flex gap-48 mobile:flex-col mobile:gap-5 mobile:flex-1">
                <div class="footer__links flex">
                    <div class="flex flex-col">
                        <RouterLink to="/" type="button">
                            Home
                        </RouterLink>
                    </div>
                </div>
                <div class="footer__social flex flex-col gap-2">
                    <h1 class="text-[20px] mobile:text-[17px]">You can find us here:</h1>
                    <div class="footer__social-icons flex gap-4">
                        <a href="https://discord.gg/drpqQfVXQ" class="footer__icon h-8 w-8">
                            <svg class="w-8 h-8" fill="currentColor" viewBox="0 -20 1035 1035"
                                xmlns="http://www.w3.org/2000/svg" stroke="#000000">
                                <g id="SVGRepo_bgCarrier" stroke-width="0"></g>
                                <g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"
                                    stroke="#CCCCCC" stroke-width="2.048"></g>
                                <g id="SVGRepo_iconCarrier">
                                    <circle cx="512" cy="512" r="512" class="text-white"></circle>
                                    <path
                                        d="M689.43 349a422.21 422.21 0 0 0-104.22-32.32 1.58 1.58 0 0 0-1.68.79 294.11 294.11 0 0 0-13 26.66 389.78 389.78 0 0 0-117.05 0 269.75 269.75 0 0 0-13.18-26.66 1.64 1.64 0 0 0-1.68-.79A421 421 0 0 0 334.44 349a1.49 1.49 0 0 0-.69.59c-66.37 99.17-84.55 195.9-75.63 291.41a1.76 1.76 0 0 0 .67 1.2 424.58 424.58 0 0 0 127.85 64.63 1.66 1.66 0 0 0 1.8-.59 303.45 303.45 0 0 0 26.15-42.54 1.62 1.62 0 0 0-.89-2.25 279.6 279.6 0 0 1-39.94-19 1.64 1.64 0 0 1-.16-2.72c2.68-2 5.37-4.1 7.93-6.22a1.58 1.58 0 0 1 1.65-.22c83.79 38.26 174.51 38.26 257.31 0a1.58 1.58 0 0 1 1.68.2c2.56 2.11 5.25 4.23 8 6.24a1.64 1.64 0 0 1-.14 2.72 262.37 262.37 0 0 1-40 19 1.63 1.63 0 0 0-.87 2.28 340.72 340.72 0 0 0 26.13 42.52 1.62 1.62 0 0 0 1.8.61 423.17 423.17 0 0 0 128-64.63 1.64 1.64 0 0 0 .67-1.18c10.68-110.44-17.88-206.38-75.7-291.42a1.3 1.3 0 0 0-.63-.63zM427.09 582.85c-25.23 0-46-23.16-46-51.6s20.38-51.6 46-51.6c25.83 0 46.42 23.36 46 51.6.02 28.44-20.37 51.6-46 51.6zm170.13 0c-25.23 0-46-23.16-46-51.6s20.38-51.6 46-51.6c25.83 0 46.42 23.36 46 51.6.01 28.44-20.17 51.6-46 51.6z"
                                        class="text-[#df067f]"></path>
                                </g>
                            </svg>
                        </a>
                        <a href="https://twitter.com/llczskfunny" class="footer__icon h-8 w-8">
                            <svg xmlns:svg="http://www.w3.org/2000/svg" xmlns="http://www.w3.org/2000/svg" version="1.1"
                                viewBox="350 100 1000 1000" class="h-8 w-8" fill="currentColor" xml:space="preserve">
                                <g>
                                    <circle cx="834.28" cy="610.6" r="481.33" />
                                    <g id="layer1" transform="translate(52.390088,-25.058597)">
                                        <path id="path1009" class="text-[#df067f]"
                                            d="M485.39,356.79l230.07,307.62L483.94,914.52h52.11l202.7-218.98l163.77,218.98h177.32    L836.82,589.6l215.5-232.81h-52.11L813.54,558.46L662.71,356.79H485.39z M562.02,395.17h81.46l359.72,480.97h-81.46L562.02,395.17    z" />
                                    </g>
                                </g>
                            </svg>
                        </a>
                        <a href="https://github.com/dalibor-osu/LLCZ" class="footer__icon h-8 w-8">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-8 w-8" fill="currentColor" viewBox="0 0 24 24">
                                <path
                                    d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z" />
                            </svg>
                        </a>
                        <a href="https://soundcloud.com/matej_records" class="footer__icon h-8 w-8">
                            <svg xmlns="http://www.w3.org/2000/svg" class="h-8 w-8" fill="currentColor"
                                viewBox="60 50 300 430">
                                <path
                                    d="m212.5 51q43.5 0 81.5 16.5t66.25 44.75 44.75 66.25 16.5 81.5-16.5 81.5-44.75 66.5-66.25 45-81.5 16.5-81.5-16.5-66.5-45-45-66.5-16.5-81.5 16.5-81.5 45-66.25 66.5-44.75 81.5-16.5zm-119.5 213q-10.5 9-10.5 22 0 13.5 10.5 21.5zm21.5-6.5h-2.5q-2.5 0-4.25.25t-4.25.75v55q2.5.5 4.25.75t4.25.25h2.5zm22-15q-6.5 8-9 19.5-.5-.5-1-.75t-1-.75v54h11zm21.5-15.5q-3 1-5.75 2.5t-5.25 3v82h11zm22-1.5q-2-.5-3.5-.75t-3.5-.25q-1 0-2 .25t-2 .25v89.5h11zm21.5-1q-1 2-2.5 3.5t-2.5 3q-5.5-3-11-4.5v88h16zm109 90q16-1 23.75-10t7.75-21.5q0-13-8.75-22t-22.25-9q-5.5 0-12 2.5-2.5-20.5-18-34.75t-37-14.25q-11 0-20.25 3.75t-16.75 10.25v95z" />
                            </svg>
                        </a>
                    </div>
                </div>
            </div>
        <div class="footer__logo mobile:flex-1">
            <img src="../../assets/logo_w.svg" alt="LoveLive! Czechia!!" class="logo min-w-[100px] h-[74px]">
        </div>
    </div>
    <div class="footer__copyright mt-10">
        <div
            class="footer__container max-w-[1280px] tablet:max-w-[720px] mobile:max-w-[320px] mx-auto flex justify-center mobile:justify-start">
            <p>© 2023 LoveLive! Czechia!!</p>
        </div>
    </div>
</section></template>