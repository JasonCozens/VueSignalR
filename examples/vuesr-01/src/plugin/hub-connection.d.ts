import Vue from 'vue'

declare module 'vue/types/vue' {

  interface VueConstructor {
    $hubConnection: string
  }
}
