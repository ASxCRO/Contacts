<template>
	<b-container>
		<h2>{{ isEdit ? "Edit Contact" : "Add Contact" }}</h2>
		<b-form @submit.prevent="saveContact">
			<b-form-group label="First Name">
				<b-form-input
					v-model="firstName"
					required
				/>
			</b-form-group>
			<b-form-group label="Last Name">
				<b-form-input
					v-model="lastName"
					required
				/>
			</b-form-group>
			<b-form-group label="Email">
				<b-form-input
					type="email"
					v-model="email"
					required
				/>
			</b-form-group>
			<b-button
				type="submit"
				variant="primary"
			>
				{{ isEdit ? "Update" : "Add" }}
			</b-button>
			<b-button
				@click="$emit('cancel')"
				variant="secondary"
			>
				Cancel
			</b-button>
		</b-form>
	</b-container>
</template>

<script>
import contactService from "@/services/contactService";

export default {
	props: ["contact", "isEdit"],
	data() {
		return {
			firstName: "",
			lastName: "",
			email: "",
			id: 0,
		};
	},
	watch: {
		contact: {
			handler(newVal) {
				this.firstName = newVal.firstName || "";
				this.lastName = newVal.lastName || "";
				this.email = newVal.email || "";
				this.id = newVal.id || 0;
			},
			deep: true,
			immediate: true,
		},
	},
	methods: {
		saveContact() {
			const newContact = {
				firstName: this.firstName,
				lastName: this.lastName,
				email: this.email,
				id: this.id,
			};
			if (this.isEdit) {
				contactService.editContact(newContact).then(() => {
					this.$emit("contact-saved");
				});
			} else {
				contactService.createContact(newContact).then(() => {
					this.$emit("contact-saved");
				});
			}
		},
	},
};
</script>
