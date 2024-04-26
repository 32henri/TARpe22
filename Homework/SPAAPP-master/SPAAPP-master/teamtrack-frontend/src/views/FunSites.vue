<template> 
    <navbar />
    <SitesList :title="title"/>
</template>
  
<script setup lang="ts">
import SitesList from "../components/FunSites.vue"
    import { defineProps } from "vue";
    import navbar from "../components/Navbar.vue"
  </script>