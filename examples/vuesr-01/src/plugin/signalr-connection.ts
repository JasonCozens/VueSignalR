import _Vue from 'vue';
import SignalROptions from './signalr-options';

export default class SignalRConnection {
  static install(Vue: typeof _Vue, options?: any): void {
    console.log('Installing SignalRConnection.');
    console.log(options);
  }
}
