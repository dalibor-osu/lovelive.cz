<template>
    <section id="footer-social" class="w-full absolute -bottom-[193px] mobile:-bottom-[329px] py-[71px] bg-[#efe8d8] font-sans font-bold dark:bg-[#918f89] z-10">
        <div class="footer__container max-w-[1280px] tablet:max-w-[720px] mobile:max-w-[320px] mx-auto flex justify-center mobile:justify-start">
            <form class="newsletter__form flex justify-center items-center gap-7 flex-wrap mobile:justify-start">
                <div class="newsletter__form-checkbox">
                    <h2 class="text-[#cf888d] text-[20px] border-[#cf888d] dark:text-white">Subscribe to our newsletter</h2>
                    <div class="flex items-center gap-2">
                        <input type="checkbox" id="consent" name="consent"
                            class="w-4 h-4 rounded-xl ring-2 ring-[#cf888d] appearance-none checked:bg-[#fff] dark:ring-white" />
                        <label for="consent" class="text-[#cf888d] text-[14px] dark:text-white">
                            I agree to the processing of personal data
                        </label>
                    </div>
                </div>
                <div class="newsletter__form-email flex gap-7 flex-wrap">
                    <input autocomplete="off"
                        class="newsletter__input w-60 h-10 pl-4 rounded-xl placeholder-[#888] placeholder:text-[15px] text-[#fff] focus:outline-none bg-gradient-to-br bg-[#343031] to-90% shadow-xl"
                        type="email" id="email" name="email" placeholder="Your E-mail" />
                    <button id="menu-button" type="button"
                        class= "flex justify-center items-center w-24 h-10 rounded-xl  text-sm font-semibold text-[#fff] bg-[#343031] shadow-xl">
                        <span class="font-bold">Submit</span>
                    </button>
                </div>
            </form>
        </div>
    </section>
</template>