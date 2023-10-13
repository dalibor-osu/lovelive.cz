import type { BasicUser } from "@/interfaces/user/basicUser";

const getUserAttachmentPath = (user: BasicUser) => {
	return `${window.location.origin}/files/${user.id}`;
};


const getUserAvatarPath = (user: BasicUser) => {
	if (user.profilePicture == null) {
		return `${window.location.origin}/src/assets/img/default_avatar.webp`;
	}
	return `${getUserAttachmentPath(user)}/${user.profilePicture}}`;
};

const userHelper = {
	getUserAttachmentPath,
	getUserAvatarPath,
};

export default userHelper;