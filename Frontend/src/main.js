import Vue from 'vue';
import App from './App.vue';
import VueResource from 'vue-resource'
import VueNumeric from 'vue-numeric'
//import signalR from '@aspnet/signalr'
const SignalR = require('@aspnet/signalr');

import BootstrapVue from 'bootstrap-vue';

Vue.use(BootstrapVue);
Vue.use(VueResource);
Vue.use(VueNumeric);
Vue.use(SignalR);

Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');
