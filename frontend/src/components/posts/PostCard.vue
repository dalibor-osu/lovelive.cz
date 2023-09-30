<template>
  <div :id="post.id"
    class="post__card relative bg-gradient-to-br from-[#df067f] to-[#df067f] text-white rounded-xl shadow-xl w-[720px] tablet:w-[600px] mobile:w-[320px]">
    <div class="post__container-card px-4 py-2">
      <div class="flex justify-between items-center">
        <span class="post__profile-name font-bold text-lg break-words mobile:w-[220px] py-2">
          {{ post.user.displayName }}
        </span>
        <img :src="post.user.profilePicture ?? 'https://i.pinimg.com/550x/18/b9/ff/18b9ffb2a8a791d50213a9d595c4dd52.jpg'"
          alt="avatar"
          class="post__profile-image absolute mobile:relative -top-7 -right-7 mobile:-top-0 mobile:-right-0 mobile:rounded-xl mobile:border-0 mobile:ring-0 rounded-full border-[3px] ring-2 ring-[#df067f] border-white w-[64px] h-[64px] mobile:w-[38px] mobile:h-[38px] ">
      </div>
      <hr>
      <p class="break-words py-1">{{ post.text }}</p>
    </div>
    <ul>
      <li v-for="attachment in post.attachments" :key="attachment.id">
        <img :src="getAttachmentPath(attachment, post.user.id)" alt="picture" class="w-full h-auto">
      </li>
    </ul>
    <div class="post__container-card px-4 py-2 flex justify-between">
      <div class="flex gap-3 items-center">
        <button type="button" class="post__like has-tooltip hover:text-[#df067f] hover:bg-white rounded-2xl p-1">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
            class="w-6 h-6">
            <path stroke-linecap="round" stroke-linejoin="round"
              d="M21 8.25c0-2.485-2.099-4.5-4.688-4.5-1.935 0-3.597 1.126-4.312 2.733-.715-1.607-2.377-2.733-4.313-2.733C5.1 3.75 3 5.765 3 8.25c0 7.22 9 12 9 12s9-4.78 9-12z" />
          </svg>
          <span class='tooltip rounded shadow-lg p-1 bg-white text-[#df067f] -mt-[65px] -ml-[18px]'>Like</span>
        </button>
        <span class="post__count-likes text-lg"></span>
      </div>
      <div class="post__other flex gap-5">
        <button class="post__share-btn has-tooltip hover:text-[#df067f] hover:bg-white rounded-2xl p-1 hidden">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
            class="w-6 h-6">
            <path stroke-linecap="round" stroke-linejoin="round"
              d="M7.217 10.907a2.25 2.25 0 100 2.186m0-2.186c.18.324.283.696.283 1.093s-.103.77-.283 1.093m0-2.186l9.566-5.314m-9.566 7.5l9.566 5.314m0 0a2.25 2.25 0 103.935 2.186 2.25 2.25 0 00-3.935-2.186zm0-12.814a2.25 2.25 0 103.933-2.185 2.25 2.25 0 00-3.933 2.185z" />
          </svg>
          <span class='tooltip rounded shadow-lg p-1 bg-white text-[#df067f] -mt-[65px] -ml-[24px]'>Share</span>
        </button>
        <button class="post__reply-btn has-tooltip hover:text-[#df067f] hover:bg-white rounded-2xl p-1 hidden">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
            class="w-6 h-6">
            <path stroke-linecap="round" stroke-linejoin="round"
              d="M8.625 12a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0H8.25m4.125 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0H12m4.125 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0h-.375M21 12c0 4.556-4.03 8.25-9 8.25a9.764 9.764 0 01-2.555-.337A5.972 5.972 0 015.41 20.97a5.969 5.969 0 01-.474-.065 4.48 4.48 0 00.978-2.025c.09-.457-.133-.901-.467-1.226C3.93 16.178 3 14.189 3 12c0-4.556 4.03-8.25 9-8.25s9 3.694 9 8.25z" />
          </svg>
          <span class='tooltip rounded shadow-lg p-1 bg-white text-[#df067f] -mt-[65px] -ml-[24px]'>Reply</span>
        </button>
        <button class="post__share-btn has-tooltip hover:text-[#df067f] hover:bg-white rounded-2xl p-1 hidden">
          <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor"
            class="w-6 h-6">
            <path stroke-linecap="round" stroke-linejoin="round"
              d="M19.5 12c0-1.232-.046-2.453-.138-3.662a4.006 4.006 0 00-3.7-3.7 48.678 48.678 0 00-7.324 0 4.006 4.006 0 00-3.7 3.7c-.017.22-.032.441-.046.662M19.5 12l3-3m-3 3l-3-3m-12 3c0 1.232.046 2.453.138 3.662a4.006 4.006 0 003.7 3.7 48.656 48.656 0 007.324 0 4.006 4.006 0 003.7-3.7c.017-.22.032-.441.046-.662M4.5 12l3 3m-3-3l-3 3" />
          </svg>
          <span class='tooltip rounded shadow-lg p-1 bg-white text-[#df067f] -mt-[65px] -ml-[30px]'>Repost</span>
        </button>
      </div>
    </div>
    <div class="px-4">
      <hr>
    </div>
    <div class="post__container-card px-4 py-2 flex justify-center text-sm">
      <p>{{ (new Date(post.created)).toLocaleString() }}</p>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import type { Post } from "../../interfaces/post/post";
import type { Attachment } from "../../interfaces/post/attachment";

export default defineComponent({
  props: {
    post: {
      type: Object as () => Post,
      required: true,
    },
  },
  methods: {
    getAttachmentPath(attachment: Attachment, userId: string): string {
      return `${window.location.origin}/files/${userId}/${attachment.id}_${attachment.name}`;
    },
  },
});
</script>