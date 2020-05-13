import Vue from 'vue';
import App from './App.vue';
import ObjectPlugin from './plugin/object-plugin';

Vue.config.productionTip = false;

Vue.use(ObjectPlugin, 'ObjectPlugin Options.');

new Vue({
  render: (h) => h(App),
}).$mount('#app');
