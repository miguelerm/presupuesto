CREATE TABLE [Gastos] (
[Id] INTEGER  PRIMARY KEY NOT NULL,
[Nombre] TEXT  UNIQUE NOT NULL,
[Descripcion] TEXT  NOT NULL
);

CREATE TABLE [Productos] (
[Id] INTEGER  NOT NULL PRIMARY KEY,
[Nombre] TEXT  UNIQUE NOT NULL,
[Caracteristicas] TEXT  NULL,
[PrecioVenta] REAL  NOT NULL
);

CREATE TABLE [ProyeccionGasto] (
[Id] INTEGER  PRIMARY KEY NOT NULL,
[Anio] INT  NOT NULL,
[Mes] INT  NOT NULL
);

CREATE TABLE [ProyeccionGastoDetalle] (
[ProyeccionId] INTEGER  NOT NULL,
[GastoId] INTEGER  NOT NULL,
[Monto] REAL  NOT NULL,
PRIMARY KEY ([ProyeccionId],[GastoId])
);

CREATE TABLE [ProyeccionVenta] (
[Id] INTEGER  PRIMARY KEY NOT NULL,
[Anio] INT  NOT NULL,
[Mes] INT  NOT NULL
);

CREATE TABLE [ProyeccionVentaDetalle] (
[ProyeccionId] INTEGER  NOT NULL,
[ProductoId] INTEGER  NOT NULL,
[Cantidad] INT  NOT NULL,
PRIMARY KEY ([ProyeccionId],[ProductoId])
);

