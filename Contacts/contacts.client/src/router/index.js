import Vue from "vue";
import Router from "vue-router";
import Contacts from "@/views/ContactView.vue";

Vue.use(Router);

export default new Router({
	routes: [
		{
			path: "/",
			name: "contacts",
			component: Contacts,
		},
	],
});
