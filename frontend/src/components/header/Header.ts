export function toggleClassesSingle(element: HTMLElement | null, ...args: string[]) {
	if (!element) return;
	for (const arg of args) {
		element?.classList.toggle(arg);
	}
}

export function toggleClassesCollection(collection: NodeListOf<HTMLElement> | null, ...args: string[]) {
	if (!collection) return;
	collection.forEach(element => {
		for (const arg of args) {
			element?.classList.toggle(arg);
		}
	});
}

// header links
document.addEventListener("DOMContentLoaded", () => {

	const links: NodeListOf<HTMLLinkElement> | null = document.querySelectorAll("a.header__link");
	const dropdown: HTMLDivElement | null = document.querySelector("div.header__dropdown-item");
	const linkContainer: HTMLElement | null = document.querySelector("nav.header__nav");
	const dropdownContent: HTMLElement | null = document.querySelector("#dropdown-content");
	const dropdownLinks: NodeListOf<HTMLLinkElement> | null = document.querySelectorAll("a.header__link-dropdown-item");

	let widthContainer: number;

	function hideLinks() {
		dropdown?.classList.add("hidden");
		widthContainer = linkContainer!.offsetWidth;
		let sumWidthLinks: number = 0;
		for (let i = 0; i < links!.length; i++) {
			links![i].classList.remove("hidden");
			dropdownLinks![i].classList.add("hidden");
			dropdown?.classList.add("hidden");
			// postupne se scitaji sirky tlacitek
			sumWidthLinks += links![i].offsetWidth;
			// podminka pokud je soucet vetsi nez kontejner,
			// budou se posledni tlacitka schovavat
			if (sumWidthLinks + 613 >= widthContainer) {
				links![i].classList.add("hidden");
				dropdown?.classList.remove("hidden");
				dropdownLinks![i].classList.remove("hidden");
			}
		}
	}

	hideLinks();

	document.addEventListener("reload", () => {
		hideLinks();
	})

	window.addEventListener("resize", () => {
		hideLinks();
		dropdownContent?.classList.add("hidden");
	});

	dropdownLinks?.forEach((link) => {
		link?.addEventListener("click", () => {
			hideLinks();
		});
	});

	links?.forEach((link) => {
		link?.addEventListener("click", () => {
			hideLinks();
		});
	});

	dropdown?.addEventListener("click", () => {
		if (dropdown && dropdownContent) {
			toggleClassesSingle(dropdownContent, "hidden");
		}
	});

	window.addEventListener("click", (event) => {
		const target: Node | null = event.target as Node;

		// kliknutí mimo dropdown se skryje
		if (!dropdown?.contains(target) && !dropdownContent?.contains(target)) {
			dropdownContent?.classList.add("hidden");
		}
	});
});

// menu rotate & sidenav
document.addEventListener("DOMContentLoaded", () => {
	const menu: HTMLDivElement | null = document.querySelector("div.header__menu");
	const nav: HTMLElement | null = document.querySelector("nav.sidenav");
	const close: HTMLButtonElement | null = document.querySelector("button.sidenav__close");
	const links: NodeListOf<HTMLLinkElement> | null = document.querySelectorAll("a.sidenav__link-item");

	// menu && nav
	if (menu && nav && close && links) {
		menu?.addEventListener("click", () => {
			toggleClassesSingle(menu, "rotate-90");
			toggleClassesSingle(nav, "w-0", "w-60");
			links?.forEach((link) => {
				if (link.classList.contains("text-white") && link.classList.contains("duration-2000")) {
					link?.classList.add("text-[#df067f]");
					link?.classList.remove("text-white");
					link?.classList.remove("duration-2000");
				}
				else {
					link?.classList.remove("text-[#df067f]");
					link?.classList.add("text-white");
					link?.classList.add("duration-2000");
				}
			});
		});

		window.addEventListener("resize", () => {
			menu?.classList.remove("rotate-90");
			nav?.classList.add("w-0");
			nav?.classList.remove("w-60");
			links?.forEach((link) => {
				link?.classList.add("text-[#df067f]");
				link?.classList.remove("text-white");
				link?.classList.remove("duration-2000");
			});
		});

		close?.addEventListener("click", () => {
			toggleClassesSingle(menu, "rotate-90");
			toggleClassesSingle(nav, "w-0", "w-60");
			links?.forEach((link) => {
				link?.classList.add("text-[#df067f]");
				link?.classList.remove("text-white");
				link?.classList.remove("duration-2000");
			});
		});
		links?.forEach((link) => {
			link?.addEventListener("click", () => {
				toggleClassesSingle(menu, "rotate-90");
				toggleClassesSingle(nav, "w-0", "w-60");
				links?.forEach((link) => {
					link?.classList.add("text-[#df067f]");
					link?.classList.remove("text-white");
					link?.classList.remove("duration-2000");
				});
			});
		});
	}
});