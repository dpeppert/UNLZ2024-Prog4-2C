/*Crear una tabla*/

CREATE TABLE Container (
	IdContainer int identity(1,1) not null primary key,
	DescripcionContainer varchar(100) not null, 
	EstaCargado bit not null,
	IdUsuarioAlta int not null, 
	FechaAlta datetime not null, 
	IdUsuarioModificacion int null, 
	FechaModificacion datetime null, 
	IdUsuarioBaja int null,
	FechaBaja datetime null
)

go 

/*Consulta con filtros (Where)*/
select * from Container 
where FechaBaja is null 

go 

/*Inserts en una tabla*/
insert into Container (DescripcionContainer, EstaCargado, IdUsuarioAlta, FechaAlta) values ('Container-12231-1', 1, 1, getdate())
insert into Container (DescripcionContainer, EstaCargado, IdUsuarioAlta, FechaAlta) values ('Container-34234-2', 0, 1, getdate())
go 
/*Actualizacion de informacion*/
update Container set EstaCargado = 1 where idContainer = 2 

go 
update Container set FechaBaja = getdate(), IdUsuarioBaja = 1 where idContainer = 2 
go 
update Container set FechaBaja = null, IdUsuarioBaja = null where idContainer = 2 


go 

/*Modificacion de estructura*/

Alter table Container drop column EstaCargado


Alter table Container add IdEstadoContainer int 

go 
/*Creo segunda tabla*/

Create table EstadosContainer 
(IdEstadoContainer int identity(1,1) not null primary key, 
	Descripcion varchar(100) ,
	IdUsuarioAlta int not null, 
	FechaAlta datetime not null, 
	IdUsuarioModificacion int null, 
	FechaModificacion datetime null, 
	IdUsuarioBaja int null,
	FechaBaja datetime null
)

/*Inserto en segunda tabla*/
insert into EstadosContainer (Descripcion, IdUsuarioAlta, FechaAlta) values ('Activo', 1 ,getdate())

go 

select * from EstadosContainer 

go 

/*Crear Vista*/
Create view vwContainer 
as 

select IdContainer, DescripcionContainer, estadosContainer.IdEstadoContainer, EstadosContainer.Descripcion Estado from Container 
 left join EstadosContainer 
	on EstadosContainer.IdEstadoContainer = Container.IdEstadoContainer
	 
	go 


	select * From vwContainer

	update Container
	set DescripcionContainer = 'Container-12332131231-1' 
	where IdContainer = 1 

	go 
	/*Agrego Relacion*/
	Alter table Container add Constraint FK_Container_Estado foreign key (IdEstadoContainer) 
	references EstadosContainer(IdEstadoContainer)

	go 
	/*Crear SP */
	create procedure prUnlz_GetContainer
	( @pIdContainer int ) 

	as 

	begin 
		select * from vwContainer where IdContainer = @pIdContainer
		
	end 

	go 
	/*Ejecucion SP*/
	exec prUnlz_GetContainer 2 



