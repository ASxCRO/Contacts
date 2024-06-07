<template>
	<b-container>
		<b-row>
			<b-col>
				<contact-form
					v-if="showForm"
					:contact="selectedContact"
					:isEdit="isEdit"
					@contact-saved="handleContactSaved"
					@cancel="showForm = false"
				/>
				<contact-list
					v-else
					@edit-contact="editContact"
					ref="contactList"
				/>
				<b-button
					v-if="!showForm"
					@click="addContact"
					variant="primary"
					class="mt-3"
					>Add Contact</b-button
				>
			</b-col>
		</b-row>
	</b-container>
</template>

<script>
import ContactList from "@/components/ContactList.vue";
import ContactForm from "@/components/ContactForm.vue";

export default {
	components: {
		ContactList,
		ContactForm,
	},
	data() {
		return {
			showForm: false,
			selectedContact: null,
			isEdit: false,
		};
	},
	methods: {
		addContact() {
			this.selectedContact = {};
			this.isEdit = false;
			this.showForm = true;
		},
		editContact(contact) {
			this.selectedContact = { ...contact };
			this.isEdit = true;
			this.showForm = true;
		},
		handleContactSaved() {
			this.showForm = false;
			this.$refs.contactList.fetchContacts();
		},
	},
};
</script>
