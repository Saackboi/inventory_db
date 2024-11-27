create database inventario;
use inventario;


create table equipo(
	id_equipo nvarchar(5) primary key,
	nombre nvarchar(100),
	modelo nvarchar(100),
	serie nvarchar(100),
	id_departamento int foreign key references departamento(id_departamento),
	estado nvarchar(100),
	id_usuario int foreign key references usuario(id_usuario)
);

create table departamento(
	id_departamento int identity(1,1) primary key,
	nombre nvarchar (100)
);

create table usuario(
	id_usuario int primary key identity(1,1),
	nombre nvarchar(100)
);

create table equipo_movimiento(
	id_movimiento int identity(1,1) primary key,
	id_equipo nvarchar(5) foreign key references equipo(id_equipo),
	motivo nvarchar(25),
	lugar_movimiento nvarchar(50),
	fecha datetime,
	observacion nvarchar(50)
);


insert into departamento(nombre) values ('Informática');
insert into usuario(nombre) values ('Koji');
select * from departamento;
select * from equipo;
select * from usuario;
select * from equipo_movimiento;
drop table equipo;
drop table departamento;