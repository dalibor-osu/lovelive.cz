<script setup lang="ts">
import { loadFull } from "tsparticles"; // if you are going to use `loadFull`, install the "tsparticles" package too.
//import { loadSlim } from "tsparticles-slim"; // if you are going to use `loadSlim`, install the "tsparticles-slim" package too.

const particlesInit = async (engine: any) => {
    await loadFull(engine);
    //await loadSlim(engine);
};

const particlesLoaded = async (container: any) => {
    console.log("Particles container loaded", container);
};
</script>


<template>
    <div>
        <vue-particles id="tsparticles" :particlesInit="particlesInit" :particlesLoaded="particlesLoaded" :options="{
            backgroundMode: false,
            background: {
                color: {
                    value: 'transparent'
                }
            },
            fpsLimit: 185,
            interactivity: {
                events: {
                    onClick: {
                        enable: true,
                        //attract, bubble, pause, push, remove, repulse, trail, absorber, emitter
                        mode: 'attract'
                    },
                    onHover: {
                        enable: true,
                        //attract, bubble, connect, grab, light, repulse, slow, trail
                        mode: 'bubble'
                    },
                    resize: true
                },
                modes: {
                    bubble: {
                        distance: 150,
                        duration: 3,
                        opacity: 1,
                        size: 25
                    },
                    // push: {
                    //     quantity: 4
                    // },
                    repulse: {
                        distance: 200,
                        duration: 0.4
                    }
                }
            },
            particles: {
                color: {
                    value: '#ffffff'
                },
                links: {
                    //links are disable
                    color: '#ffffff',
                    distance: 150,
                    enable: false,
                    opacity: 0.5,
                    width: 1
                },
                move: {
                    direction: 'bottom-right',
                    enable: true,
                    outMode: 'out',
                    random: false,
                    speed: 3,
                    straight: false
                },
                number: {
                    density: {
                        enable: true,
                        area: 900
                    },
                    value: 50
                },
                opacity: {
                    //opacity is disable, with stroke = circle
                    value: 0
                },
                shape: {
                    type: 'circle',
                    stroke: {
                        width: 1,
                        color: '#ffffff'
                    },
                },
                size: {
                    random: true,
                    value: 20
                }
            },
            detectRetina: false
        }" />
    </div>
</template>