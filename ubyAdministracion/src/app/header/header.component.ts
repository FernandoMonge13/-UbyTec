import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  logged:boolean = false
  id!:string|number;
  constructor(private cookie:CookieService, private router:Router) {
    console.log(cookie.get("tokenAdministrador"));
    this.logged = !(cookie.get("tokenAdministrador")=="")
    this.id = cookie.get("tokenAdministrador")
    console.log(this.logged)
  }
    /*
    * Redirige a la gestion indicada
    * @param: Tipo:string
    * return: void
     */
  recargar(Tipo:string){
    this.router.navigate(['gestion/'+Tipo])
    .then(() => {
      window.location.reload();
    });

  }

    reloadComponent(self:boolean,urlToNavigateTo ?:string){
      //skipLocationChange:true means dont update the url to / when navigating
    console.log("Current route I am on:",this.router.url);
    const url=self ? this.router.url :urlToNavigateTo;
    this.router.navigateByUrl('/',{skipLocationChange:true}).then(()=>{
      this.router.navigate([`/${url}`]).then(()=>{
        console.log(`After navigation I am on:${this.router.url}`)
      })
    })
  }
  /*Recarga la página*/
    reloadPage(){
      window.location.reload()
    }
    /*Borra cookie de vista especifica y recarga pagina*/
    logout(){
      this.cookie.delete("tokenAdministrador")
      this.reloadPage()
    }

  ngOnInit(): void {
  }

}
