create schema chat_module_works4hours;
use chat_module_works4hours;

CREATE TABLE usuarios (
  idusuario int(11) NOT NULL primary key auto_increment,
  nombres char(60) NOT NULL,
  apellidos char(60) NOT NULL,
  celular char(30) NOT NULL,
  correo varchar(100) NOT NULL unique,
  contrasenna varchar(45) NOT NULL,
  fnac date NOT NULL,
);

CREATE TABLE mensajes (
  idmensaje int(11) NOT NULL primary key auto_increment,
	mensaje varchar(1000) NOT NULL,
	fecha date NOT NULL,
    idsala int(11) NOT NULL,
    idusuario int(11) NOT NULL
);

CREATE TABLE sala (
idsala int(11) NOT NULL primary key auto_increment,
fechainicio date,
fechafin date,
horainicio char(5),
horafin char(5)
);

CREATE TABLE sala_usuario (
	idsalausuario int(11) NOT NULL primary key auto_increment,
    idsala int(11) NOT NULL,
    idusuario int(11) NOT NULL
);

alter table mensajes add foreign key (idsala) references sala(idsala), add foreign key (idusuario) references usuarios (idusuario);
alter table sala_usuario add foreign key (idsala) references sala(idsala), add foreign key (idusuario) references usuarios (idusuario);



