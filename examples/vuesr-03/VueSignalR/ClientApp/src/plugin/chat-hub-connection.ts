import _Vue from 'vue';
import { HubConnectionBuilder } from '@microsoft/signalr';
import SignalROptions from './signalr-options';

export default class ChatHubConnection {
  static install(Vue: typeof _Vue, options: SignalROptions): void {
    console.log('Installing SignalRConnection.');
    console.log(options);

    Vue.$chatHubConnection = new HubConnectionBuilder()
      .withUrl(options.hubUrl)
      .build();

    const manuallyClosed = false;

    function start() {
      const startedPromise: Promise<void> = Vue.$chatHubConnection.start()
        .catch((err) => {
          console.error('Failed to connect with hub', err);
          return new Promise((resolve, reject) => setTimeout(
            () => start().then(resolve).catch(reject), 5000,
          ));
        });
      return startedPromise;
    }
    Vue.$chatHubConnection.onclose(() => {
      if (!manuallyClosed) start();
    });

    // Start everything
    start();
  }
}
