import Vue from 'vue';
import App from './App.vue';
import ChatHubConnection from './plugin/chat-hub-connection';
import SignalROptions from './plugin/signalr-options';

Vue.config.productionTip = false;

Vue.use(ChatHubConnection, new SignalROptions('/chat'));

new Vue({
  render: (h) => h(App),
}).$mount('#app');
