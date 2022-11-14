import { Component, Inject, OnDestroy, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { interval, Observable, Subscription } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({
    'Access-Control-Allow-Origin': '*',
    'Authorization': 'authkey',
    'userid': '1',
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './counter.component.html',
})
export class CounterComponent implements OnInit, OnDestroy {

  private subscription: Subscription = new Subscription;

  public inventory: Inventory | undefined 
  public minutes: number = 0;
  public seconds: number = 0;
  public timeDifference: any;
  public endCountdownMsg: string = "";


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Inventory>("https://localhost:44383/" + 'NextVote/inventory', httpOptions).subscribe(result => {
      this.inventory = result;
      console.log(result)
      console.log(this.inventory)
    }, error => console.error(error));

    http.get<number>("https://localhost:44383/" + 'NextVote/time', httpOptions).subscribe(result => {
      this.minutes = result;
    }, error => console.error(error));
  }

  public getTimeDifference() {
    if (this.seconds == 0) {
      if (this.minutes == 0) {
        this.subscription.unsubscribe();
        const inv = JSON.stringify(this.inventory);
        this.http.post<Inventory>("https://localhost:44344/" + "CountdownEnd/countdownEnd",inv, httpOptions).subscribe(result => {
          this.endCountdownMsg = "Countdown has ended, Inventory Saved";
        }, error => console.error(error));

      } else {
        this.seconds = 60;
        this.minutes = this.minutes - 1
      }
    } else {
      this.seconds = this.seconds - 1
    }



  }
  
  ngOnInit() {
    this.subscription = interval(1000).subscribe(x => { this.getTimeDifference(); });
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  
}

interface Inventory {
  ItemList: Item
}

interface Item {

}
