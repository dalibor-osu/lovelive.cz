/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: 'class',
  content: [
    './public/**/*.html',
    './src/**/*.{js,jsx,ts,tsx,vue}',
  ],
  theme: {
    fontFamily: {
        'roboto': ['Roboto', 'sans-serif'],
    },
    extend: {
      screens: {
        'mobile': { 'min': '0px', 'max': '959.9px' },
        'tablet': { 'min': '959.9px', 'max': '1899.9px' },
      },
      transitionDuration: {
        '2000': '2000ms',
        '2100': '2100ms',
        '2200': '2200ms',
        '2300': '2300ms',
        '2400': '2400ms',
        '2500': '2500ms',
        '2600': '2600ms',
        '2700': '2700ms',
        '2800': '2800ms',
        '2900': '2900ms',
      },
    },
  },
  plugins: [],
}

