import _Vue from 'vue';

export default class ObjectPlugin {
  static install(Vue: typeof _Vue, options?: any): void {
    console.log('Installing ObjectPlugin.');
    console.log(options);
  }
}
