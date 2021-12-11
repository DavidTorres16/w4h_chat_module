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

Este metodo response con un areglo de todos los usuarios registrados

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

