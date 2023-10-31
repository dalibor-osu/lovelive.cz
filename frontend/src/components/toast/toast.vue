<template>
    <div
      :id="toastId"
      class="fixed top-24 left-0 right-0 mx-auto z-50 flex items-center w-full max-w-xs p-4 mb-4 text-gray-500 bg-white rounded-lg shadow"
      role="alert"
    >
      <component :is="componentMap[label]"></component>
      <div class="ml-3 text-sm font-normal break-words w-4/6">
        {{ msg }}
      </div>
      <button
        type="button"
        class="ml-auto -mx-1.5 -my-1.5 bg-white text-gray-400 hover:text-gray-900 rounded-lg focus:ring-2 focus:ring-gray-300 p-1.5 hover:bg-gray-100 inline-flex items-center justify-center h-8 w-8"
        data-dismiss-target="#"
        aria-label="Zavřít"
        @click="closeToast(toastId)"
      >
        <span class="sr-only">Zavřít</span>
        <svg
          class="w-3 h-3"
          aria-hidden="true"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 14 14"
        >
          <path
            stroke="currentColor"
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="m1 1 6 6m0 0 6 6M7 7l6-6M7 7l-6 6"
          />
        </svg>
      </button>
    </div>
  </template>
  
  <script setup lang="ts">
  import { ref } from 'vue';
  import Success from './types/success.vue';
  import Danger from './types/danger.vue';
  import Information from './types/information.vue';
  import Warning from './types/warning.vue';
  
  const { msg, label } = defineProps(["msg", "label"]);
  
  const generateUniqueId = () => {
    return Math.random().toString(36).substring(2) + Date.now().toString(36);
  };
  
  const toastId = ref(generateUniqueId());
  
  const closeToast = (id: any) => {
    const toast = document.getElementById(id);
    if (toast) {
      toast.remove();
    }
  };
  
  const componentMap: any = {
    'success': Success,
    'danger': Danger,
    'information': Information,
    'warning': Warning
  };
  </script>
  