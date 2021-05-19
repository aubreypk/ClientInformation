<!-- TEMPLATE -->
<template>
    <div class="row justify-content-center">
        <div class="col-md-5">
            <h3 class="text-center">New Client</h3>
            <form @submit.prevent="onFormSubmit">
                <div class="form-group">
                    <label>Surname</label>
                    <input type="text" class="form-control" v-model="user.surname" required>
                </div>

                <div class="form-group">
                    <label>Names</label>
                    <input type="text" class="form-control" v-model="user.names" required>
                </div>

                <div class="form-group">
                    <label>Email</label>
                    <input type="email" class="form-control" v-model="user.email" required>
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
    export default {
        data() {
            return {
                user: {
                   name: '',
                   email: '',
                   phone: ''
                }
            }
        },
        methods: {
            onFormSubmit() { 
               alert(JSON.stringify(this.user)) 
            }
        }
    }
</script>