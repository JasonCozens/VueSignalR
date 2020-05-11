# VueSignalR
Vue + TypeScript + BoostrapVue + ASP.NET Core + SignalR

## vuesr-01 - Writing a Vue Plugin

``` powershell
vue create vuesr-01
```

* Manually Select Features
  * Babel
  * TypeScript
  * Linter / Formatter
* Use class-style component syntax? Y
* Use Babel alongside TypeScript for auto-detected polyfills? Y
* ESLint + Airbnb config
* Lint on save
* Where do you prefer placing config for Babel, PostCSS, ESLint, etc.?
  * In dedicated config files
  
### index.html - Entry Point - pre-compilation

``` html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1.0">
    <link rel="icon" href="<%= BASE_URL %>favicon.ico">
    <title><%= htmlWebpackPlugin.options.title %></title>
  </head>
  <body>
    <noscript>
      <strong>We're sorry but . . . </strong>
    </noscript>
    <div id="app"></div>
    <!-- built files will be auto injected -->
  </body>
</html>
```

### main.ts

``` typescript
import Vue from 'vue';
import App from './App.vue';

Vue.config.productionTip = false;

new Vue({
  render: (h) => h(App),
}).$mount('#app');
```
