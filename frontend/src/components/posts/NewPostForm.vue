<template>
  <form enctype="multipart/form-data" method="post" name="newPostForm"
        class="new-post flex justify-center w-[720px] tablet:w-[600px] mobile:w-[320px] rounded-lg">
    <div class="new-post__block flex flex-col gap-2 w-full">
      <div class="w-full border border-[#e0007c] rounded-lg bg-white shadow-xl">
        <div class="flex items-center justify-between px-3 py-2 border-b">
          <div class="flex flex-wrap items-center divide-x-[#ffb7df] sm:divide-x mobile:divide-x-0">
            <div class="flex items-center flex-wrap space-x-1 sm:pr-4 mobile:sm:pr-0">
              <label
                class="p-2 text-[#e0007c] rounded cursor-pointer hover:text-[#960052] hover:bg-[#ffeff8]">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                     viewBox="0 0 12 20">
                  <path stroke="currentColor" stroke-linejoin="round" stroke-width="2"
                        d="M1 6v8a5 5 0 1 0 10 0V4.5a3.5 3.5 0 1 0-7 0V13a2 2 0 0 0 4 0V6" />
                </svg>
                <span class="sr-only">Attach file</span>
                <input id="dropzone-file" type="file" name="File" multiple="true"
                       accept="image/jpeg, image/png, image/gif, image/svg" class="hidden">
              </label>
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                     fill="currentColor" viewBox="0 0 16 20">
                  <path
                    d="M8 0a7.992 7.992 0 0 0-6.583 12.535 1 1 0 0 0 .12.183l.12.146c.112.145.227.285.326.4l5.245 6.374a1 1 0 0 0 1.545-.003l5.092-6.205c.206-.222.4-.455.578-.7l.127-.155a.934.934 0 0 0 .122-.192A8.001 8.001 0 0 0 8 0Zm0 11a3 3 0 1 1 0-6 3 3 0 0 1 0 6Z" />
                </svg>
                <span class="sr-only">Embed map</span>
              </button>
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                     fill="currentColor" viewBox="0 0 16 20">
                  <path d="M5 5V.13a2.96 2.96 0 0 0-1.293.749L.879 3.707A2.96 2.96 0 0 0 .13 5H5Z" />
                  <path
                    d="M14.067 0H7v5a2 2 0 0 1-2 2H0v11a1.969 1.969 0 0 0 1.933 2h12.134A1.97 1.97 0 0 0 16 18V2a1.97 1.97 0 0 0-1.933-2ZM6.709 13.809a1 1 0 1 1-1.418 1.409l-2-2.013a1 1 0 0 1 0-1.412l2-2a1 1 0 0 1 1.414 1.414L5.412 12.5l1.297 1.309Zm6-.6-2 2.013a1 1 0 1 1-1.418-1.409l1.3-1.307-1.295-1.295a1 1 0 0 1 1.414-1.414l2 2a1 1 0 0 1-.001 1.408v.004Z" />
                </svg>
                <span class="sr-only">Format code</span>
              </button>
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                     fill="currentColor" viewBox="0 0 20 20">
                  <path
                    d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM13.5 6a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3Zm-7 0a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3Zm3.5 9.5A5.5 5.5 0 0 1 4.6 11h10.81A5.5 5.5 0 0 1 10 15.5Z" />
                </svg>
                <span class="sr-only">Add emoji</span>
              </button>
            </div>
            <div class="flex flex-wrap items-center space-x-1 sm:pl-4 mobile:sm:pl-0">
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none"
                     viewBox="0 0 21 18">
                  <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round"
                        stroke-width="2"
                        d="M9.5 3h9.563M9.5 9h9.563M9.5 15h9.563M1.5 13a2 2 0 1 1 3.321 1.5L1.5 17h5m-5-15 2-1v6m-2 0h4" />
                </svg>
                <span class="sr-only">Add list</span>
              </button>
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                     fill="currentColor" viewBox="0 0 20 20">
                  <path
                    d="M18 7.5h-.423l-.452-1.09.3-.3a1.5 1.5 0 0 0 0-2.121L16.01 2.575a1.5 1.5 0 0 0-2.121 0l-.3.3-1.089-.452V2A1.5 1.5 0 0 0 11 .5H9A1.5 1.5 0 0 0 7.5 2v.423l-1.09.452-.3-.3a1.5 1.5 0 0 0-2.121 0L2.576 3.99a1.5 1.5 0 0 0 0 2.121l.3.3L2.423 7.5H2A1.5 1.5 0 0 0 .5 9v2A1.5 1.5 0 0 0 2 12.5h.423l.452 1.09-.3.3a1.5 1.5 0 0 0 0 2.121l1.415 1.413a1.5 1.5 0 0 0 2.121 0l.3-.3 1.09.452V18A1.5 1.5 0 0 0 9 19.5h2a1.5 1.5 0 0 0 1.5-1.5v-.423l1.09-.452.3.3a1.5 1.5 0 0 0 2.121 0l1.415-1.414a1.5 1.5 0 0 0 0-2.121l-.3-.3.452-1.09H18a1.5 1.5 0 0 0 1.5-1.5V9A1.5 1.5 0 0 0 18 7.5Zm-8 6a3.5 3.5 0 1 1 0-7 3.5 3.5 0 0 1 0 7Z" />
                </svg>
                <span class="sr-only">Settings</span>
              </button>
              <button type="button"
                      class="p-2 text-[#e0007c] rounded cursor-pointer hover:hover:text-[#960052] hover:bg-[#ffeff8] hidden">
                <svg class="w-4 h-4" aria-hidden="true" xmlns="http://www.w3.org/2000/svg"
                     fill="currentColor" viewBox="0 0 20 20">
                  <path
                    d="M18 2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V4a2 2 0 0 0-2-2ZM2 18V7h6.7l.4-.409A4.309 4.309 0 0 1 15.753 7H18v11H2Z" />
                  <path
                    d="M8.139 10.411 5.289 13.3A1 1 0 0 0 5 14v2a1 1 0 0 0 1 1h2a1 1 0 0 0 .7-.288l2.886-2.851-3.447-3.45ZM14 8a2.463 2.463 0 0 0-3.484 0l-.971.983 3.468 3.468.987-.971A2.463 2.463 0 0 0 14 8Z" />
                </svg>
                <span class="sr-only">Timeline</span>
              </button>
            </div>
          </div>
        </div>
        <div class="px-2 pb-1 pt-2 bg-white rounded-b-lg">
          <label for="editor" class="sr-only">Publish post</label>
          <textarea id="editor" v-model="text" rows="3" name="Text" maxlength="5000"
                    minlength="2"
                    class="rounded-lg w-full px-2 py-2 text-sm placeholder:text-[#e0007c] focus:outline-[#e0007c] text-[#e0007c]"
                    placeholder="Write something..." required />
        </div>
      </div>
      <button type="button" class="flex justify-center items-center w-full h-10 rounded-xl bg-[#e0007c] hover:bg-white hover:text-[#e0007c] hover:border-[#e0007c] text-sm text-white shadow-xl border-2 border-white font-bold"
              @click="createPost">
        Post
      </button>
    </div>
  </form>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import { usePostStore } from "../../stores/postStore";

export default defineComponent({
	data() {
		return {
			files: null as Array<HTMLInputElement> | null,
			text: "" as string,
		};
	},

	methods: {
		async createPost(): Promise<void> {
			const form = document.forms.namedItem("newPostForm");
			const formData = new FormData(form as HTMLFormElement);
			const postStore = usePostStore();
			postStore.createPost(formData);
			form?.reset();
		},
	},
});
</script>