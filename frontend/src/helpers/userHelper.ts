import type { BasicUser } from "@/interfaces/user/basicUser";
import type { User } from "@/interfaces/user/user";
import defaultAvatar from "@/assets/img/default_avatar.webp";
import defaultBanner from "@/assets/img/default_banner.webp";

const filesPath = `${window.location.origin}/files`;
const avatarPath = "avatar.webp";
const bannerPath = "banner.webp";

const getUserAttachmentPath = (user: BasicUser) => {
	return `${filesPath}/${user.id}`;
};

const getUserAvatarPath = (user: BasicUser) => {
	if (user.hasCustomAvatar === false) {
		return defaultAvatar;
	}
	return `${getUserAttachmentPath(user)}/${avatarPath}`;
};

const getUserBannerPath = (user: User) => {
	if (user.hasCustomAvatar === false) {
		return defaultBanner;
	}
	return `${getUserAttachmentPath(user)}/${bannerPath}`;
};

const userHelper = {
	getUserAttachmentPath,
	getUserAvatarPath,
	getUserBannerPath,
};

export default userHelper;