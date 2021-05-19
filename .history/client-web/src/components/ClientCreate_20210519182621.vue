<!-- TEMPLATE -->
<template>
    <div class="row justify-content-center">
        <div class="col-md-5">
            <h3 class="text-center">New Client</h3>
            <form @submit.prevent="onFormSubmit">
                <div class="form-group">
                    <label>Surname</label>
                    <input type="text" class="form-control" v-model="client.surname" required>
                </div>

                <div class="form-group">
                    <label>Names</label>
                    <input type="text" class="form-control" v-model="client.names" required>
                </div>

                <div class="form-group">
                    <label>Email</label>
                    <input type="email" class="form-control" v-model="client.email" required>
                </div>

                <div class="form-group">
                    <button class="btn btn-primary btn-block">Save Client</button>
                </div>
            </form>
        </div>
    </div>
</template>

<!-- SCRIPT -->
<script>
    import ClientDataService from "../services/ClientDataService";

    export default {
        data() {
            return {
                client: {
                   surname: '',
                   names: '',
                   email: ''
                }
            }
        },
        methods: {
            onFormSubmit(event) { 
                event.preventDefault()
                alert(JSON.stringify(this.client)) 

                ClientDataService.create(this.client)
                    .then(response => {
                        this.client.id = response.data.id;
                        console.log(response.data);
                         alert("User successfully created!");
                         this.surname = ''
                         this.names = ''
                         this.email = ''
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }
</script>