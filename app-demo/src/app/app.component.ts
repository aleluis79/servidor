import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UtilService } from './util.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'app-demo';

  datosFormGroup: FormGroup;

  constructor(
    private utilService: UtilService,
    private formBuilder: FormBuilder
  ) {
    this.datosFormGroup = this.formBuilder.group({
      accion: ['', [Validators.required]],
      valor: ['', [Validators.required]]
    })
  }

  ngOnInit(): void {
  }

  enviarDatos() {
    if (this.datosFormGroup.valid) {
      this.utilService.save({Accion: this.datosFormGroup.controls.accion.value, Valor: this.datosFormGroup.controls.valor.value}).subscribe(
        rta => {
          console.log('El servicio respondió: ', rta);
        }
      )
    }
  }

}
