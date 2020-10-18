<template>
  <div class="hello">
    <h3>Banter</h3>
    <textarea rows="10" cols="50" v-model="conversation"></textarea>
    <br>
    <input placeholder="What do you want to say?"  v-model="message">
    <button id="newMessage" @click="sendMessage">Submit</button>
  </div>
</template>

<script lang="ts">
import {
  Component,
  Vue,
} from 'vue-property-decorator';

@Component
export default class HelloWorld extends Vue {
  public conversation = 'Start of conversation . . .';

  public message = '';

  public created() {
    this.conversation = '';
    Vue.$chatHubConnection.on('newMessage', (name, message) => this.onNewMessage(name, message));
  }

  public sendMessage() {
    Vue.$chatHubConnection.invoke('Broadcast', 'Me', this.message);
  }

  public onNewMessage(name: string, message: string) {
    console.log(`${name} - ${message}<br>`);
    this.conversation += `${name} - ${message}\n`;
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
