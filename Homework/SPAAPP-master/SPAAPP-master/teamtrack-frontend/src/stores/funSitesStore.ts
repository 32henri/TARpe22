import { Sites } from "@/models/funSites";
import { ref } from "vue";
import { defineStore } from "pinia";
import useApi, { useApiRawRequest } from "@/models/api";

export const useSitesStore = defineStore('sitesStore', () => {
  const apiGetEvents = useApi<Sites[]>('sites');
  const events = ref<Sites[]>([]);
  let allEvents: Sites[] = [];

  const loadEvents = async () => {
    await apiGetEvents.request();

    if (apiGetEvents.response.value) {
      return apiGetEvents.response.value;
    }
    return [];
  };

  const load = async () => {
    allEvents = await loadEvents();
    events.value = allEvents;
  };
  const getEventById = (id: number) => {
    return allEvents.find((event) => event.id === id);
  };


  const addEvent = async (event: Sites) => {
    const apiAddEvent = useApi<Sites>('sites', {
      method: 'POST',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(event),
    }); 
    
    await apiAddEvent.request();
    if (apiAddEvent.response.value) {
      load();      
    }
  };
  const updateEvent = async (event: Sites) => {
    const apiUpdateEvent = useApi<Sites>('sites/' + event.id, {
      method: 'PUT',
      headers: {
        Accept: 'application/json',
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(event),
    });

    await apiUpdateEvent.request();
    if (apiUpdateEvent.response.value) {
      load();
    }    
  };


  const deleteEvent = async (event: Sites) => {
    const deleteEventRequest = useApiRawRequest(`sites/${event.id}`, {
      method: 'DELETE',
    });

    const res = await deleteEventRequest();

    if (res.status === 204) {
      let id = events.value.indexOf(event);

      if (id !== -1) {
        events.value.splice(id, 1);
      }

      id = events.value.indexOf(event);

      if (id !== -1) {
        events.value.splice(id, 1);
      }
    }
  };

  return { events, load, getEventById, addEvent, updateEvent, deleteEvent };
});





