import { BootstrapVue, IconsPlugin } from 'bootstrap-vue';
import Vue from 'vue';
import App from './App.vue';
import ChatHubConnection from './plugin/chat-hub-connection';
import SignalROptions from './plugin/signalr-options';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-vue/dist/bootstrap-vue.css';

Vue.config.productionTip = false;

Vue.use(BootstrapVue);
Vue.use(IconsPlugin);
Vue.use(ChatHubConnection, new SignalROptions('/chat'));

new Vue({
  render: (h) => h(App),
}).$mount('#app');
