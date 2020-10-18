<template>
  <div id="app">
    <b-container>
      <b-row>
        <b-col>Waitng for Rain</b-col>
        <b-col>2 of 4</b-col>
        <b-col>3 of 4</b-col>
        <b-col><img alt="Vue logo" src="../public/img/pic000000001.jpg"
                    style="width:75%"></b-col>
      </b-row>
      <b-tabs>
        <b-tab title="First" active>
          <img alt="Vue logo" src="./assets/logo.png">
        </b-tab>
        <b-tab title="Second" style="width:100%;">
          <HelloWorld msg="Welcome to Your Vue.js + TypeScript + SignalR App" />
        </b-tab>
        <b-tab title="Rain" style="margin-top:20px; ">
          <h3>Rain</h3>
          <p>One drop can't save a life</p>
          <p>It gets lost in the ocean of ambivalence</p>
          <p>YET</p>
          <p>One day the drops unite</p>
          <p>And the tides turn</p>
          <p>Sweet relief the clouds break</p>
          <p>For the gift of life is water</p>
        </b-tab>
      </b-tabs>
    </b-container>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from './components/HelloWorld.vue';

@Component({
  components: {
    HelloWorld,
  },
})
export default class App extends Vue {
  public chatHubConnection = Vue.$chatHubConnection;
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
