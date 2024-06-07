<template>
	<div id="app">
		<b-navbar
			toggleable="lg"
			type="dark"
			variant="dark"
		>
			<b-navbar-brand href="#">Contacts App</b-navbar-brand>
		</b-navbar>
		<b-container class="mt-3">
			<router-view />
		</b-container>
	</div>
</template>

<script>
export default {
	name: "App",
};
</script>
