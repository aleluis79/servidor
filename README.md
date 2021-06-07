* Para empaquetar la aplicación:

dotnet publish -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeAllContentForSelfExtract=true


* Llamada desde el browser:

fetch('http://localhost:9999/', {
  method: 'post',
  headers: {
    'Accept': 'application/json, text/plain, */*',
    'Content-Type': 'application/json'
  },
  body: JSON.stringify({Accion: 'agregar', Valor: 'idCausa=1&issue=5'})
}).then(res => res.text())
  .then(res => console.log(res));