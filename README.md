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

## Add a PluginObject

The Vue API documentation for adding a plugin states:

\# Vue.use( plugin )

* **Arguments:**

  * {Object | Function} plugin

* **Usage:**

> Install a Vue.js plugin. If the plugin is an Object, it must expose an install method. If it is a function itself, it will be treated as the install method. The install method will be called with Vue as the argument.

> This method has to be called before calling new Vue()

> When this method is called on the same plugin multiple times, the plugin will be installed only once.

* See also: Plugins

### TypeScript Signature

The TypeScript signature for the Vue.use function is:

``` typescript
use<T>(plugin: PluginObject<T> | PluginFunction<T>, options?: T): VueConstructor<V>;
use(plugin: PluginObject<any> | PluginFunction<any>, ...options: any[]): VueConstructor<V>;
```

PluginObject and PluginFunction are defined in plugin.d.ts.

``` typescript
import { Vue as _Vue } from "./vue";

export type PluginFunction<T> = (Vue: typeof _Vue, options?: T) => void;

export interface PluginObject<T> {
  install: PluginFunction<T>;
  [key: string]: any;
}
```

### Create the Plugin

``` typescript
import Vue from 'vue';

export default class ObjectPlugin {
  public static install(vue: typeof Vue, options?: any): void {
    console.log('Installing ObjectPlugin.');
  }
}
```

### Install the Plugin

``` typescript
import Vue from 'vue';
import App from './App.vue';
import ObjectPlugin from './plugins/object-plugin';

Vue.config.productionTip = false;

Vue.use(ObjectPlugin);

new Vue({
  render: (h) => h(App),
}).$mount('#app');
```

### Run the Application

```
npm run serve
```

Look at the console output.

## Add a PluginObject with Options

### Modify ObjectPlugin

``` typescript
import _Vue from 'vue';

export default class ObjectPlugin {
  static install(Vue: typeof _Vue, options?: any): void {
    console.log('Installing ObjectPlugin.');
    console.log(options);
  }
}
```

### Amend Vue.use

``` typescript
import Vue from 'vue';
import App from './App.vue';
import ObjectPlugin from './object-plugin';

Vue.config.productionTip = false;

Vue.use(ObjectPlugin, 'ObjectPlugin Options.');

new Vue({
  render: (h) => h(App),
}).$mount('#app');
```

## Augmenting Types for Use with Plugins

Now we can add the plugin we want to be able to share objects with the Vue components.

``` typescript
// hub-connection.d.ts
import Vue from 'vue'

declare module 'vue/types/vue' {

  interface VueConstructor {
    $hubConnection: string
  }
}
```

We can no assign a value to the global Vue variable.

``` typescript
import _Vue from 'vue';
import SignalROptions from './signalr-options';

export default class SignalRConnection {
  static install(Vue: typeof _Vue, options?: SignalROptions): void {
    console.log('Installing SignalRConnection.');
    console.log(options);

    _Vue.$hubConnection = 'SignalR Hub Connection';
  }
}
```

### App.vue

We can use this vue in the Vue components.

``` html
<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <h1>{{ hubConnection }}</h1>
    <HelloWorld msg="Welcome to Your Vue.js + TypeScript App"/>
  </div>
</template>
```

``` typescript
@Component({
  components: {
    HelloWorld,
  },
})
export default class App extends Vue {
  public hubConnection = Vue.$hubConnection;
}
</script>
```

And similarly in any other Vue component.
