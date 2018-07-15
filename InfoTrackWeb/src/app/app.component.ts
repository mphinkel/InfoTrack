import { Component } from '@angular/core';
import { GoogleSearchService } from './google-search.service'

@Component({
  selector: 'app-root',
  providers: [GoogleSearchService],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  model: any = {};
  result: string;

  constructor(private googleService: GoogleSearchService) { }

  onSubmit() {
    this.result = "loading";
    this.googleService.getResult(this.model.keywords, this.model.url).toPromise().then(result => {
      this.result = result.toString();
    });
  }
}
