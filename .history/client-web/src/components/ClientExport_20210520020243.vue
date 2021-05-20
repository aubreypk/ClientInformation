<!-- TEMPLATE -->
<template>
    <div class="row">
        <div class="col-md-12">
            
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
            onFormSubmit(event) { 
                event.preventDefault()
                ClientDataService.getCSV(clients)
                    .then(response => {
                        console.log(response.data);
                    })
                    .catch(e => {
                        console.log(e);
                    });
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
