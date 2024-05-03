<template>
      <div class="text-center">
          <div class="hidden md:block">
          </div>
          <h1 class="font-bold">{{ title }}</h1>
          <div class="moving-text-container0">
                  <template>
                      <button class="details"
                              @click="Link(data)">
                          Link
                      </button>
                  </template>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">Vue link 123</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          </div>
          <div class="moving-text-container1">
                  <template>
                      <button class="details"
                              @click="Link(data)">
                          Link
                      </button>
                  </template>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">Vue link 12311111</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          </div>
          <div class="moving-text-container2">
                  <template>
                      <button class="details"
                              @click="Link(data)">
                          Link
                      </button>
                  </template>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">Vue link 1232222222</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          </div>
          <div class="moving-text-container3">
                  <template>
                      <button class="details"
                              @click="Link(data)">
                          Link
                      </button>
                  </template>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">Vue link 12333333</a>
          <a href="https://vuejs.org/guide/essentials/conditional.html">-</a>
          </div>
        
      </div>
</template>

<script setup lang="ts">
import { Sites } from '@/models/funSites';
import { useSitesStore } from "@/stores/funSitesStore";
import { storeToRefs } from "pinia";
import { defineProps, onMounted, ref, watch } from "vue";
import { useRoute } from "vue-router";


</script>

<style>
.popup {
  /* ... existing styles ... */
  display: flex; /* Keep this to align the popup */
  align-items: center;
  justify-content: center;
  transition: opacity 0.3s ease-in-out; /* Smooth fade transition */
  z-index: 100; /* High z-index to ensure visibility above other content */
}

.popup-inner {
  background-color: rgb(76, 202, 76); /* White background for the popup */
  padding: 40px; /* More padding for a spacious look */
  border-radius: 15px; /* Rounded corners */
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.2); /* Softer shadow for depth */
  position: relative; /* For absolute positioning of close button */
  width: 90%; /* Max width to support responsiveness */
  max-width: 500px; /* Maximum width of the popup */
  transition: transform 1.3s ease-in-out; /* Transform transition for a pop effect */
  transform: scale(1.05); /* Start slightly larger */
}

.popup-inner h2 {
  margin-top: 0; /* Remove margin at the top of the h2 */
  margin-bottom: 1rem; /* Space below the title */
  color: #333; /* Dark color for the title */
  font-size: 1.75rem; /* Larger size for the title */
}

.popup-inner ul {
  list-style: none; /* Remove list styles */
  padding: 0; /* Remove padding */
  margin: 0; /* Remove margins for a clean look */
}

.popup-inner ul li {
  padding: 0.5rem 0; /* Padding for each list item */
  border-bottom: 1px solid #eee; /* Separator for items */
}

.popup-inner ul li:last-child {
  border-bottom: none; /* No border for the last item */
}

.popupClose {
  position: absolute;
  top: 10px;
  right: 10px;
  width: 30px; /* Width and height should be the same for a circle */
  height: 30px;
  line-height: 30px; /* Line height equal to height to center the text vertically */
  text-align: center; /* Center the text horizontally */
  border-radius: 50%; /* Perfect circle */
  font-size: 16px; /* Adjust the font size as needed */
  transition: background-color 0.2s, transform 0.2s;
  cursor: pointer;
  display: flex; /* Use flexbox to center content */
  align-items: center; /* Center vertically */
  justify-content: center; /* Center horizontally */
  padding: 0; /* Remove padding to prevent misalignment */
}

.popupClose:hover,
.popupClose:focus {
  animation: colorchange 1s infinite; /* Darker shade for hover effect */
  outline: none; /* Remove outline on focus for a cleaner look */
}

/* Showing and hiding the popup */
.popup-enter-active, .popup-leave-active {
  transition: opacity 0.3s ease-in-out;
}

.popup-enter, .popup-leave-to /* .popup-leave-active below version 2.1.8 */ {
  opacity: 0;
  transform: scale(1);
}

/* DataTable styling */
.DataTable {
  /* Assuming you have a custom class to target */
  width: 100%; /* Full width */
  border-collapse: collapse; /* Collapsed borders for a clean look */
  margin-top: 1rem; /* Space above the table */
}

.Column {
  /* Assuming custom classnames for Column */
  text-align: right; /* Align text to the left for readability */
  padding: 0.75rem 1rem; /* Padding within cells */
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

.moving-text-container0 {
    animation: moveText0 9s linear infinite;
}
.moving-text-container1 {
    animation: moveText1 4s linear infinite;
}
.moving-text-container2 {
    animation: moveText2 4s linear infinite;
}
.moving-text-container3 {
    animation: moveText3 4s linear infinite;
}
@keyframes moveText0 {
0% {
    transform: translateX(-400px) translateY(0px);
}
10% {
    transform: translateX(-100px) translateY(1100px);
}
20% {
    transform: translateX(100px) translateY(0px);
}
30% {
    transform: translateX(500px) translateY(300px);
}
40% {
    transform: translateX(0px) translateY(1100px);
}
50% {
    transform: translateX(-600px) translateY(0px);
}
60% {
    transform: translateX(-100px) translateY(0px);
}
70% {
    transform: translateX(0px) translateY(200px);
}
80% {
    transform: translateX(100px) translateY(0px);
}
90% {
    transform: translateX(0px) translateY(210px);
}
100% {
    transform: translateX(-400px) translateY(0px);
}
}

@keyframes moveText1 {
0% {
    transform: translateX(0px) translateY(0px);
}
10% {
    transform: translateX(0px) translateY(0px);
}
20% {
    transform: translateX(-400px) translateY(300px);
}
30% {
    transform: translateX(200px) translateY(900px);
}
40% {
    transform: translateX(-400px) translateY(-100px);
}
50% {
    transform: translateX(-400px) translateY(-100px);
}
60% {
    transform: translateX(300px) translateY(600px);
}
70% {
    transform: translateX(-100px) translateY(0px);
}
80% {
    transform: translateX(0px) translateY(210px);
}
90% {
    transform: translateX(100px) translateY(0px);
}
100% {
    transform: translateX(0px) translateY(0px);
}
}
@keyframes moveText2 {
0% {
    transform: translateX(200px) translateY(500px);
}
10% {
    transform: translateX(-600px) translateY(600px);
}
20% {
    transform: translateX(600px) translateY(700px);
}
30% {
    transform: translateX(-600px) translateY(800px);
}
40% {
    transform: translateX(600px) translateY(900px);
}
50% {
    transform: translateX(-600px) translateY(1000px);
}
60% {
    transform: translateX(600px) translateY(500px);
}
70% {
    transform: translateX(-200px) translateY(200px);
}
80% {
    transform: translateX(100px) translateY(600px);
}
90% {
    transform: translateX(0px) translateY(210px);
}
100% {
    transform: translateX(200px) translateY(500px);
}
}

@keyframes moveText3 {
0% {
    transform: translateX(100px) translateY(0px);
}
10% {
    transform: translateX(0px) translateY(210px);
}
20% {
    transform: translateX(-100px) translateY(0px);
}
30% {
    transform: translateX(0px) translateY(200px);
}
40% {
    transform: translateX(100px) translateY(0px);
}
50% {
    transform: translateX(0px) translateY(210px);
}
60% {
    transform: translateX(0px) translateY(200px);
}
70% {
    transform: translateX(-100px) translateY(0px);
}
80% {
    transform: translateX(0px) translateY(210px);
}
90% {
    transform: translateX(100px) translateY(0px);
}
100% {
    transform: translateX(100px) translateY(0px);
}
}
</style>

