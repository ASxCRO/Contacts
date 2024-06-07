import axios from "axios";

const API_URL = "http://localhost:5180/api/Contact"; // Adjust the URL as necessary

export default {
	getContacts(
		term = "",
		pageNumber = 1,
		pageSize = 12,
		sortField = "FirstNameAsc"
	) {
		return axios.get(API_URL, {
			params: { term, pageNumber, pageSize, sortField },
		});
	},

	createContact(contact) {
		return axios.post(API_URL, contact);
	},

	editContact(contact) {
		return axios.put(API_URL, contact);
	},

	deleteContact(id) {
		return axios.delete(`${API_URL}/${id}`);
	},
};
