<template>
  <div class="min-h-screen bg-grey-50 py-12 px-4 sm:px-6 lg:px=8 text-black-300">
    <div class="text-center">
      <h1 class="font-bold">{{ title }}</h1>
      <DataTable :value="eventPeople">
        <Column id="id" field="id" header="Id" />
        <Column id="eventid" field="eventid" header="EventId" />
        <Column id="personid" name="personid" header="PersonId" />
        <Column>
          <template #body="{ data }">
            <button class="details" @click="showDetails(data)">Details</button>
          </template>
        </Column>
      </DataTable>
      <div v-if="!eventPeople || eventPeople.length === 0">Sündmused puuduvad</div>
    </div>
    <div v-if="showPopup" class="popup">
      <div class="popup-inner">
        <h2>Event Details</h2>
        <ul>
          <li v-for="(value, key) in selectedEvent" :key="key">
            {{ key }}: {{ value }}
          </li>
        </ul>
        <button @click="showPopup = false" class="popupClose">X</button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps, ref } from "vue";
import { useEventPeopleStore } from "@/stores/eventPeopleStore";

const showPopup = ref(false);
const selectedEvent = ref({});

defineProps<{ title: String }>();

const showDetails = (event) => {
  selectedEvent.value = event;
  showPopup.value = true;
};

const eventPeopleStore = useEventPeopleStore();
const { eventPeople } = eventPeopleStore;

eventPeopleStore.load();

</script>

<style>
/* Styles */
</style>
