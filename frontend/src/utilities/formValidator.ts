import type { Form } from "@/interfaces/form/form";
import type { PasswordCarrier } from "../interfaces/form/passwordCarrier";
import type { UsernameCarrier } from "@/interfaces/form/usernameCarrier";
import type { EmailCarrier } from "@/interfaces/form/emailCarrier";
import type { DisplayNameCarrier } from "@/interfaces/form/displayNameCarrier";

interface FieldValidator {
	carrierChecker: {(obj: any): boolean},
	validator: {(obj: any): boolean},
	errorMessage: string,
}

const validators: Array<FieldValidator> = [
	{
		carrierChecker: (obj: any): obj is EmailCarrier => {
			return "email" in obj;
		},
		validator: (obj: any): boolean => {
			const emailCarrier = obj as EmailCarrier;
			return /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(emailCarrier.email);
		},
		errorMessage: "Invalid email.",
	},
	{
		carrierChecker: (obj: any): obj is UsernameCarrier => {
			return "username" in obj;
		},
		validator: (obj: any): boolean => {
			const usernameCarrier = obj as UsernameCarrier;
			return /^[a-z0-9_]{3,16}$/.test(usernameCarrier.username);
		},
		errorMessage: "Invalid username. Username must be 3 - 16 letters long and can only contain lower case letters, numbers and underscores.",
	},
	{
		carrierChecker: (obj: any): obj is DisplayNameCarrier => {
			return "displayName" in obj;
		},
		validator: (obj: any): boolean => {
			const displayNameCarrier = obj as DisplayNameCarrier;
			return /^.{1,20}$/.test(displayNameCarrier.displayName);
		},
		errorMessage: "Invalid Display name. Display name must be 1 - 20 letters long.",
	},
	{
		carrierChecker: (obj: any): obj is PasswordCarrier => {
			return "password" in obj;
		},
		validator: (obj: any): boolean => {
			const passwordCarrier = obj as PasswordCarrier;
			return /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/.test(passwordCarrier.password);
		},
		errorMessage: "Invalid password. Password must be at least 8 letters long and must contain at least 1 number and letter",
	},
];

export const validateForm = (form: Form): boolean => {
	for (const validator of validators) {
		if (!validator.carrierChecker(form)) {
			continue;
		}

		if (!validator.validator(form)) {
			alert(validator.errorMessage);
			return false;
		}
	}
	return true;
};