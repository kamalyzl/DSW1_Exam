Create database Solicitud2021

Go

Use Solicitud2021
go

create table tb_categoria(
idcateg int primary key identity(1,1),
descateg varchar(100)
)

go

create table tb_actividad(
idact int primary key identity(1000,1),
desact varchar(255),
idcateg int references tb_categoria,
fecha datetime,
vacantes int default(100)
)
go

create table tb_Solicitud(
nsolicitud int primary key identity(100,10),
fsolicitud datetime default(getdate()),
idact int references tb_actividad,
dni varchar(8),
nombre varchar(150),
email varchar(255)
)
go

INSERT INTO tb_categoria VALUES('Electrodomesticos')
INSERT INTO tb_categoria VALUES('Autos')
INSERT INTO tb_categoria VALUES('Escolar')
go

INSERT INTO tb_actividad VALUES('descripcion de actividad 1', 1, '1969-07-02 00:00:00', 2)
INSERT INTO tb_actividad VALUES('descripcion de actividad 2', 2, '2001-07-02 00:00:00', 3)
INSERT INTO tb_actividad VALUES('descripcion de actividad 3', 3, '2000-07-02 00:00:00', 4)
INSERT INTO tb_actividad VALUES('descripcion de actividad 4', 2, '2020-07-02 00:00:00', 1)
 
go

INSERT INTO tb_Solicitud VALUES( '2010-07-02 00:00:00', 1000, '71306952',  'juan perez', 'juanp@gmail.com' )
INSERT INTO tb_Solicitud VALUES( '2011-07-02 00:00:00', 1001, '71306954',  'Carlos Alvarez', 'calvarez@gmail.com' )
INSERT INTO tb_Solicitud VALUES( '2012-07-02 00:00:00', 1002, '71306955',  'Pedro rodriguez', 'prodriguez@gmail.com' )

go

create proc sp_listado_solicitudes
As
Select s.nsolicitud [N. Solicitud], s.fsolicitud [F. Solicitud], a.desact [Des. Actividad], c.descateg [Des. Categoria], s.dni Dni, s.nombre Nombre, s.email Email 
from tb_categoria c inner join tb_actividad a  on c.idcateg = a.idcateg inner join tb_Solicitud s on s.idact = a.idact 
go

exec sp_listado_solicitudes
go

create proc sp_listado_actividades
As
Select * from tb_actividad;
go

/*procedure  insertar una solicitud*/
 -- select * from tb_Solicitud;
 
create proc sp_agregar_solicitud
@fsolicitud datetime,
@idact int,
@dni  varchar(8),
@nombre varchar(150),
@email varchar(255)
As
Begin
	insert tb_Solicitud Values(@fsolicitud,@idact,@dni,@nombre,@email)
	 
End

go