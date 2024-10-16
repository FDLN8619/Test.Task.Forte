# Task.Force
Instrucciones: 
Paso 1: clonar el repositorio completo

Paso 2:
se crearon dos soluciones:
 - Api : contiene el Backend (Test.Task.Api)
 - WebApp_Angular: Contiene el FronEnd(TaskWebApp)

Api:
 - Paso 1: Abrir Api con Visual Studio xxx o Visual Studio Code
 - Paso 2: si se abre con Visual studio (Ejuecutar(f5)) si es con Visual Studio Code(Abrir terminal, posicionarse en la subcarpeta (Test.Task.Api con "cd Test.Task.Api")y ejecutar dotnet run)
   - Nota:
    - se debe configurar en la API la cadena de conexion de SqlServer
    - la BD se creara automaticamenta si es que no existe ya que se tienen las migraciones en el cual contiene los objetos y el nombre de la BD que se va grear

WebApp_Angular
  - Paso 1: Abrir WebApp con Visual Studio Code
  - Paso 2: abrir una terminal
  - Paso 3: Ejecutar "npm install"
  - Paso 4: Ejecutar webApp con "ng serve"
     - Nota:
        - Debe estar corriendo primero la Api para el correcto funcionamiento de la WebApp
