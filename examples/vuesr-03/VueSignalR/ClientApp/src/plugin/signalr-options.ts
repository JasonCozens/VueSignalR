export default class SignalROptions {
  public hubUrl!: string;

  constructor(hubUrl: string) {
    this.hubUrl = hubUrl;
  }
}
