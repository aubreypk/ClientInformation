<!-- TEMPLATE -->
<template>
    <div class="row">
        <div class="col-md-12">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Surname</th>
                        <th>Names</th>
                        <th>Email</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="client in Clients" :key="client.id">
                        <td>{{ client.surname }}</td>
                        <td>{{ client.names }}</td>
                        <td>{{ client.email }}</td>
                        <td>
                            <router-link :to="{client: 'edit', params: { id: client.id }}" class="btn btn-primary">Edit
                            </router-link>
                            <button @click.prevent="deleteClient(client.id)" class="btn btn-danger">Delete</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<!-- SCRIPT -->
<script>
    import ClientDataService from "../services/ClientDataService";
    
    export default {
        data() {
            return {
                clients: []
            }
        },
        methods: {
            retrieveClients() {
                TutorialDataService.getAll()
                    .then(response => {
                    this.tutorials = response.data;
                    console.log(response.data);
                    })
                    .catch(e => {
                    console.log(e);
                    });
                },
        },
        mounted() {
            this.retrieveClients();
        }
    }
</script>

<!-- STYLE -->
<style>
    .btn-primary {
        margin-right: 12px;
    }
</style>
