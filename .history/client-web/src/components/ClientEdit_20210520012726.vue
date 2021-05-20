<!-- TEMPLATE -->
<template>
    <div class="row justify-content-center">
        <div class="col-md-5">
            <h3 class="text-center">Update Client</h3>
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
                    <button class="btn btn-primary btn-block">Update Client</button>
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
        created() {
            ClientDataService.get(this.$route.params.id)
                .then(response => {
                    this.client = response.data;
                    console.log(response.data);
                })
                .catch(e => {
                console.log(e);
            });
        },
        methods: {
            onFormSubmit(event) { 
                event.preventDefault()
                ClientDataService.update(this.$route.params.id, this.client)
                    .then(response => {
                        console.log(response.data);
                        this.$router.push('/')
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }
</script>