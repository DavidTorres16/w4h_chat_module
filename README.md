# API Work 4 Hours

## Manejo de la API
> ### **Nota** Para comprobar el funcionamiento de la API debe ser probado en aplicaciones de testeo como `Postmam` o `Insomnia` 

### Ruta raiz
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com

## Validar usuario

### Metodo `POST` 
     http://apiwt4aspnet-env.eba-nvbnf3km.us-east-1.elasticbeanstalk.com/api/ingreso

Se envia un objeto el cual tengan el correo y contraseña a validar

    {
        "correoElectronico":"correo@correo.com",
        "contrasenna":"contraseña"
    }
    
  
