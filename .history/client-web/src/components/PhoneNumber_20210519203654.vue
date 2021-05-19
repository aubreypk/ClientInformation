<!-- TEMPLATE -->
<template>
    <table>
        <tr v-for="phoneNumber in {{phoneNumbers}}" :key="client.id">
        <h5>
            
            </h5>
            <p>
            </p>
        </tr>
    </table>
</template>

<!-- SCRIPT -->
<script>
export default {
  name: 'PhoneNumber',
  props: {
    phoneNumbers: 
  }
}
</script>