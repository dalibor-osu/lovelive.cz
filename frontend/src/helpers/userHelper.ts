import type { BasicUser } from "@/interfaces/user/basicUser";
import defaultAvatar from "@/assets/img/default_avatar.webp";

const getUserAttachmentPath = (user: BasicUser) => {
	return `${window.location.origin}/files/${user.id}`;
};


const getUserAvatarPath = (user: BasicUser) => {
	if (user.profilePicture == null) {
		return defaultAvatar;
	}
	return `${getUserAttachmentPath(user)}/${user.profilePicture}}`;
};

const userHelper = {
	getUserAttachmentPath,
	getUserAvatarPath,
};

export default userHelper;