<script setup lang="ts">
import { defineProps, onMounted } from 'vue';

// Definition of available themes
const themeNames = {
    default: 'default',
    light: 'light',
    dark: 'dark',
    muse: 'muse',
    aqours: 'aqours',
    nijigasaki: 'nijigasaki',
    liella: 'liella',
    hasunosora: 'hasunosora',
} as const;

type ThemeName = typeof themeNames[keyof typeof themeNames];

// Get the 'label' property from props
const { label } = defineProps<{ label: ThemeName }>();
const name = 'themes';

// Function for toggling themes
const toggleDark = (newTheme: ThemeName) => {
    // Save the new theme and active radio input in localStorage
    localStorage.setItem('selectedTheme', newTheme);
    localStorage.setItem('activeRadioInput', label);
    applyTheme(newTheme);
};

const applyTheme = (theme: ThemeName) => {
    // Remove current themes
    for (const theme of Object.values(themeNames)) {
        document.documentElement.classList.remove(`theme--${theme}`);
    }
    // Add the new theme
    document.documentElement.classList.add(`theme--${theme}`);
};

// Load the selected theme and active radio input on the initial component load
onMounted(() => {
    const selectedTheme = localStorage.getItem('selectedTheme') as ThemeName | null;
    if (selectedTheme) {
        applyTheme(selectedTheme);
    }

    const activeRadioInput = localStorage.getItem('activeRadioInput');
    if (activeRadioInput === label) {
        // Check if the stored radio input matches the current label
        const radioInput = document.getElementById(label) as HTMLInputElement;
        if (radioInput) {
            radioInput.checked = true;
        }
    }
});
</script>

<template>
    <div class="flex flex-col gap-2">
        <label :for="label" class="bg-[#df067f] text-white w-32 h-32 rounded-xl">
            <div class="flex gap-2 items-center">
                <!-- You can place theme-specific content here -->
            </div>
        </label>
        <div class="flex gap-2">
            <input class="w-6 h-6 accent-[#df067f]" type="radio" :name="name" :id="label" :value="label"
                @click="toggleDark(label)" />
            <span class="text-lg first-letter:uppercase">{{ label }}</span>
        </div>
    </div>
</template>