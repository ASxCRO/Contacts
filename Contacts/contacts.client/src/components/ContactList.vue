<template>
	<div>
		<h2>Contact List</h2>
		<b-input
			v-model="searchTerm"
			@input="fetchContacts"
			placeholder="Search..."
			class="mb-3"
		/>
		<b-table
			striped
			hover
			:items="contacts"
			:fields="fields"
			responsive
			@sort-changed="onSortChanged"
		>
			<template #cell(actions)="data">
				<b-button
					size="sm"
					@click="editContact(data.item)"
					class="mr-2"
					>Edit</b-button
				>
				<b-button
					size="sm"
					variant="danger"
					@click="deleteContact(data.item.id)"
					>Delete</b-button
				>
			</template>
		</b-table>
		<b-pagination
			v-if="totalPages > 1"
			:total-rows="totalItemsNumber"
			:per-page="pageSize"
			v-model="pageNumber"
			@change="fetchContacts"
		></b-pagination>
	</div>
</template>

<script>
import contactService from "@/services/contactService";

export default {
	data() {
		return {
			contacts: [],
			searchTerm: "",
			pageNumber: 1,
			pageSize: 12,
			sortField: "FirstNameAsc",
			totalPages: 0,
			totalItemsNumber: 0,
			fields: [
				{ key: "id", label: "id", thClass: "d-none", tdClass: "d-none" },
				{ key: "firstName", label: "First Name", sortable: true },
				{ key: "lastName", label: "Last Name", sortable: true },
				{ key: "email", label: "Email", sortable: true },
				{ key: "actions", label: "Actions", sortable: false },
			],
		};
	},
	methods: {
		fetchContacts() {
			contactService
				.getContacts(
					this.searchTerm,
					this.pageNumber,
					this.pageSize,
					this.sortField
				)
				.then((response) => {
					this.contacts = response.data.contacts;
					this.totalPages = response.data.totalPages;
					this.totalItemsNumber = response.data.totalItemsNumber;
				});
		},
		editContact(contact) {
			this.$emit("edit-contact", contact);
		},
		deleteContact(id) {
			contactService.deleteContact(id).then(() => {
				this.fetchContacts();
			});
		},
		onSortChanged(ctx) {
			this.sortField = ctx.sortBy + (ctx.sortDesc ? "Desc" : "Asc");
			this.fetchContacts();
		},
	},
	created() {
		this.fetchContacts();
	},
};
</script>
