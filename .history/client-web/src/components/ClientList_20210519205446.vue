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
                        <th>Phone Numbers</th>
                        <th>Address</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="client in clients" :key="client.id">
                        <td>{{ client.surname }}</td>
                        <td>{{ client.names }}</td>
                        <td>{{ client.email }}</td>
                        <td>
                            <span v-for="number in client.phoneNumbers" :key="number.id">
                                <span class="">
                                    <strong>{{number.type}}</strong><br />
                                    {{number.number}}
                                </span>
                                <br />
                            </span>
                        </td>
                        <td>
                            <span v-for="address in client.addresses" :key="address.id">
                                <span>
                                    <strong>{{address.type}}</strong><br />
                                    {{address.line1}}, {{address.line2}} <br />
                                    {{address.city}}, {{address.country}} <br />
                                    {{address.code}} <br />
                                </span>
                            </span>
                        </td>
                        <td>
                            <router-link :to="{client: 'edit', params: { id: client.id }}" class="btn btn-primary">Edit</router-link>
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
                ClientDataService.getAll()
                    .then(response => {
                    this.clients = response.data;
                    console.log(response.data);
                })
                .catch(e => {
                console.log(e);
                });
            },
            deleteClient(id){
              if (window.confirm("Are you sure you want to delete client?")) {
                ClientDataService.delete(id).then(() => {
                    console.log("Client deleted!");
                })
                .catch((error) => {
                    console.error(error);
                })
              }
            }
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
