<template>
    <section id="footer-social" class="w-full h-auto py-[71px] bg-white font-sans font-bold">
        <div class="footer__container max-w-[1280px] tablet:max-w-[720px] mobile:max-w-[320px] mx-auto flex justify-center mobile:justify-start">
            <form class="newsletter__form flex justify-center items-center gap-7 flex-wrap mobile:justify-start">
                <div class="newsletter__form-checkbox">
                    <h2 class="text-[#df067f] text-[20px] border-[#df067f]">Subscribe to our newsletter</h2>
                    <div class="flex items-center gap-2">
                        <input type="checkbox" id="consent" name="consent"
                            class="w-4 h-4 rounded-xl ring-2 ring-[#df067f] appearance-none checked:bg-gradient-to-br checked:from-[#960052] checked:to-[#f53aa1] checked:ring-0" />
                        <label for="consent" class="text-[#df067f] text-[14px]">
                            I agree to the processing of personal data
                        </label>
                    </div>
                </div>
                <div class="newsletter__form-email flex gap-7 flex-wrap">
                    <input autocomplete="off"
                        class="newsletter__input w-60 h-10 pl-4 rounded-xl placeholder-white placeholder:text-[15px] text-white focus:outline-none bg-gradient-to-br from-[#960052] from-10% via-[#b30765] via-30% to-[#f53aa1] to-90% shadow-xl"
                        type="email" id="email" name="email" placeholder="Your E-mail" />
                    <button id="menu-button" type="button"
                        class= "flex justify-center items-center w-24 h-10 rounded-xl bg-gradient-to-br from-[#f53aa1] from-10% via-[#b30765] via-70% to-[#960052] to-90% mobile:from-[#960052] mobile:to-[#f53aa1] text-sm font-semibold text-white shadow-xl">
                        <span class="font-bold">Submit</span>
                    </button>
                </div>
            </form>
        </div>
    </section>
</template>