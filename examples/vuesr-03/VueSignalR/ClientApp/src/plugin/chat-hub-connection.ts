import _Vue from 'vue';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import SignalROptions from './signalr-options';

export default class ChatHubConnection {
  static install(Vue: typeof _Vue, options: SignalROptions): void {
    console.log('Installing SignalRConnection.');
    console.log(options);

    Vue.$chatHubConnection = new HubConnectionBuilder()
      .withUrl(options.hubUrl)
      .build();
  }
}
