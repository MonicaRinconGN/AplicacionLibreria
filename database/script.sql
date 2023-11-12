--crear base de datos librería
create database libreria
use libreria

--crear entidad autor (author)
create table author(
    id int not null identity(1,1) primary key,
    name varchar(80) not null
);

--crear entidad libro (book)
create table book(
    id int not null identity(1,1) primary key,
    id_author int not null,
    title varchar(80) not null,
    chapters int not null,
    pages int not null,
    price float not null
    foreign key (id_author) references author(id)
);