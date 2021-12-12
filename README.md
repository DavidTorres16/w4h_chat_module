# API Work 4 Hours

## Manejo de la API
> ### **Nota** Para comprobar el funcionamiento de la API debe ser probado en aplicaciones de testeo como `Postmam` o `Insomnia` 

### Ruta raiz
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com

## Controlador ingreso
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/ingreso

### Metodo `POST` 

Se envia un objeto el cual tengan el correo y contraseña a validar, En caso de que exista se retorna un objeto con la informacion de ese usuario, de lo contrario devolbera un areglo vacio

    {
        "correoElectronico":"correo@correo.com",
        "contrasenna":"contraseña"
    }
    
  
## Controlador usuarios 
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/usuarios

### Metodo `POST` 

Este metodo registra a un usuario, se debe enviar un objeto con la siguiente estrctura

    {
          "nombres":"Ejemplo",
          "apellidos":"Ejemplo",
          "celular":"0000000000",
          "correoElectronico":"correo@correo.com",
          "contrasenna":"contraseña",
          "fecNac":"000-00-00"
    }
    
### Respuesta

`True` Registro exitoso

`False` Registro fallido

## Controlador salas 
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/salas
    
### Metodo `GET`

Este metodo responde con un areglo de todos los usuarios registrados

### Respuesta

     [
          {
               "idusuario": 1,
               "nombres": "David",
               "apellidos": null,
               "celular": null,
               "correoElectronico": null,
               "contrasenna": null,
               "fecNac": null
          },
          {
               "idusuario": 2,
               "nombres": "Juan",
               "apellidos": null,
               "celular": null,
               "correoElectronico": null,
               "contrasenna": null,
               "fecNac": null
          }
     ]
    
    
### Metodo `POST`

Este metodo crea una nueva sala, se debe enviar un objeto con la siguiente estrctura

    {
          "fechainicio":"",
          "fechafin":"",
          "horainicio":"",
          "horafin":""
    }
    
### Respuesta

`1` Id de la sala que se acaba de crear
    
## Controlador chat 
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/chat
     
### Metodo `GET`
    http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/chat/1
    
Este metodo retorna todos los mensajes que correspondan al `id` de la sala, que se agrega a la `URL`

## Respuesta

     [
          {
               "idmensaje": 1,
               "mensaje": "Mensaje de ejemplo",
               "fecha": "12/12/2021 12:00:00 AM",
               "idsala": 1,
               "idusuario": 1
          },
          {
               "idmensaje": 2,
               "mensaje": "Mensaje de ejemplo",
               "fecha": "12/12/2021 12:00:00 AM",
               "idsala": 1,
               "idusuario": 2
          }
     ]


### Metodo `POST`

Se debe enviar por medio de este metodo un objeto con esta estrcutura

     {
          "fechainicio":"",
          "fechafin":"",
          "horainicio":"",
          "horafin":"",
          "mensajes":[
               {
                    "mensaje":"Mensaje de ejemplo",
                    "fecha":"",
                    "idsala":1,
                    "idusuario":2
               }
          ],
          "salaUsuarios": [
               {
                    "idsala":1,
                    "idusuario":2
               }
          ]
     }
     
### Respuesta 

`True` Registro de mensaje exitoso

`False` Registro fallido
