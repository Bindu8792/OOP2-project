create database CargoManagementSystem

create table Admin
(
id int not null,
pass varchar(100) not null,
name varchar(100) not null,
email varchar(100) not null,
primary key (id)
);

select *from Admin

insert into Admin (id,pass,name,email)
values (201,7878,'Brownies','brownies@gmail.com');


create table Client
(
name varchar (100) not null,
id int not null,
email varchar(100) not null,
pass varchar(100) not null,
phone int not null,
company_name varchar(100) not null,
primary key (id)
);

select *from Client

insert into Client (name,id,email,pass,phone,company_name)

DELETE FROM Client WHERE id='505';


create table fback
(
id int not null,
feedback varchar(250) not null,
primary key (id)
);

select *from fback

create table cargovan
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

select *from cargovan

DELETE FROM cargovan WHERE bid='789';

create table cargoship
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

select *from cargoship

DELETE FROM cargoship WHERE bid='789';

create table cargoair
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

select *from cargoair

DELETE FROM cargoair WHERE bid='789';


create table appvanorder
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

create table appshiporder
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

create table appairorder
(
id int not null,
bid int not null,
fcity varchar (100),
tcity varchar (100),
t_departure varchar (100),
);

