<template>
  <div
    class="min-h-screen bg-grey-50 py-12 px-4 sm:px-6 lg:px=8 text-black-300"
  >
      <div class="text-center">
          <div class="hidden md:block">
          </div>
          <h1 class="font-bold">{{ title }}</h1>
          <DataTable :value="events" v-if="events.length > 0">
              <Column field="id" header="ID" />
              <Column field="eventid" header="Event Id" />
              <Column field="personid" header="Person Id" />
          </DataTable>
          <div v-else>Sündmused puuduvad</div>
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
import { EventPeople } from '@/models/eventPeople';
import { useEventPeopleStore } from "@/stores/eventPeopleStore";
import { storeToRefs } from "pinia";
import { defineProps, onMounted, ref, watch } from "vue";
import { useRoute } from "vue-router";


const route = useRoute();

watch(route, (to, from) => {
  // Check if the route has changed meaningfully before calling load.
  if (to.path !== from.path || to.query !== from.query) {
    eventsStore.load();
  }
}, { deep: true });

defineProps<{ title: String, isAthlete: Boolean }>();

const showPopup = ref(false);
const selectedEvent = ref({});

const showDetails = (event: EventPeople) => {
  selectedEvent.value = event;
  showPopup.value = true;
};

const eventsStore = useEventPeopleStore();
const { events } = storeToRefs(eventsStore);

onMounted(() => {
  eventsStore.load();
});

const showDate = (isoString: string) =>{
  const dateTime = new Date(isoString);
  const timeZone = "UTC";
  const optionsDate: Intl.DateTimeFormatOptions = { year: "numeric", month: "2-digit", day: "2-digit", timeZone: timeZone};
  const optionsTime: Intl.DateTimeFormatOptions = { hour: "2-digit", minute: "2-digit", hour12: false, timeZone: timeZone};

  return{
    date: dateTime.toLocaleDateString(undefined, optionsDate),
    time: dateTime.toLocaleTimeString(undefined, optionsTime)
  };
};
const remove = (event: EventPeople) => {
  eventsStore.deleteEvent(event);
};

</script>

<style>
/* General styles */
body{
  background-color: #F7F3F4;
}
.details{
font-weight: bold;
color: white;
background-color: rgb(37, 179, 37);
padding: 0.00000005rem 0.5rem;
}
.details:hover{
  animation: colorchange3 1s infinite;
}
/* Typography and spacing */
h1 {
  padding: 1rem 0; /* More vertical padding */
  font-size: 2.25rem; /* Larger size for title */
  line-height: 2.5rem;
  margin-bottom: 2rem; /* Space below the title */
}
/* Media queries for responsiveness */
@media (min-width: 768px) {
  .min-h-screen {
    padding: 2rem; /* More padding on larger screens */
  }
}
@keyframes colorchange{
  0% {color: red;}
  100% {color: rgb(76, 202, 76);}

}

@keyframes colorchange1{
  0% {color: blue}
  100% {color: lightskyblue}

}
@keyframes colorchange2{
  0% {color: red}
  100% {color: white;}

}
@keyframes colorchange3{
  0% {color: rgb(37, 179, 37)}
  100% {color: white;}

}
</style>

