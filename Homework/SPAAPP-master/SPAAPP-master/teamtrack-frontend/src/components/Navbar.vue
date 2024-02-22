<template>

    <a href="/">Home</a>
    <a href="/coachEvents">Olen Treener</a>
    <a href="/athleteEvents">Olen Sportlane</a>
</template>

<script lang="ts">

export default {
  props: {
    isAthlete: Boolean,
    hasChosen: Boolean,
  },
};
</script>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}

.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}

.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
