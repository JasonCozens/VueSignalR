import Vue from 'vue';
import App from './App.vue';
import ObjectPlugin from './plugin/object-plugin';
import SignalRConnection from './plugin/signalr-connection';
import SignalROptions from './plugin/signalr-options';

Vue.config.productionTip = false;

Vue.use(ObjectPlugin, 'ObjectPlugin Options.');
Vue.use(SignalRConnection, new SignalROptions());

new Vue({
  render: (h) => h(App),
}).$mount('#app');
