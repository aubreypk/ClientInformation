<!-- TEMPLATE -->
<template>
    <div class="row justify-content-center">
        <div class="col-md-5">
            <h3 class="text-center">Download Clients as CSV</h3>
            <form @submit.prevent="onFormSubmit">
                <div class="form-group">
                    <button class="btn btn-primary btn-block">Download CSV</button>
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
                clients: []
            }
        },
        methods: {
            onFormSubmit(event) { 
                event.preventDefault()
                ClientDataService.getCSV()
                    .then(response => {
                        console.log(response.data);
                    })
                    .catch(e => {
                        console.log(e);
                    });
            }
        }
    }
</script>

<!-- STYLE -->
<style>
    .btn-primary {
        margin-right: 12px;
    }
</style>
