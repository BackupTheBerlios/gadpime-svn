-- ----------------------------------------------------------------------
-- MySQL Migration Toolkit
-- SQL Create Script
-- ----------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

CREATE DATABASE IF NOT EXISTS `GAdPIME`
  CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `GAdPIME`;
-- -------------------------------------
-- Tables

DROP TABLE IF EXISTS `GAdPIME`.`Clientes`;
CREATE TABLE `GAdPIME`.`Clientes` (
  `CodCliente` VARCHAR(10) NOT NULL,
  `NIF_CIF` VARCHAR(12) NULL,
  `Nombre` VARCHAR(80) NULL,
  `Telef1` VARCHAR(9) NULL,
  `DesTel1` VARCHAR(50) NULL,
  `Telef2` VARCHAR(9) NULL,
  `DesTel2` VARCHAR(50) NULL,
  `Telef3` VARCHAR(9) NULL,
  `DesTel3` VARCHAR(50) NULL,
  `Fax` VARCHAR(9) NULL,
  `email` VARCHAR(60) NULL,
  `Persona Contacto` VARCHAR(50) NULL,
  `CCC` VARCHAR(20) NULL,
  `TipoIVA` DECIMAL(19, 4) NULL,
  `Observaciones` LONGTEXT NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`CodCliente`),
  INDEX `NIF_CIF` (`NIF_CIF`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`Direcciones`;
CREATE TABLE `GAdPIME`.`Direcciones` (
  `CodCliente` VARCHAR(10) NOT NULL,
  `Num` TINYINT(3) UNSIGNED NOT NULL,
  `Descripcion` VARCHAR(50) NULL,
  `Direccion` VARCHAR(50) NULL,
  `CodPost` VARCHAR(5) NULL,
  `Poblacion` VARCHAR(50) NULL,
  `Telef1` VARCHAR(9) NULL,
  `DesTel1` VARCHAR(50) NULL,
  `Telef2` VARCHAR(9) NULL,
  `DesTel2` VARCHAR(50) NULL,
  `Telef3` VARCHAR(9) NULL,
  `DesTel3` VARCHAR(50) NULL,
  `Fax` VARCHAR(9) NULL,
  `Observaciones` LONGTEXT NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`CodCliente`, `Num`),
  INDEX `ClientesDirecciones` (`CodCliente`),
  CONSTRAINT `ClientesDirecciones` FOREIGN KEY `ClientesDirecciones` (`CodCliente`)
    REFERENCES `GAdPIME`.`Clientes` (`CodCliente`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`Entradas`;
CREATE TABLE `GAdPIME`.`Entradas` (
  `Num` INT(10) NOT NULL,
  `Fecha` DATETIME NULL,
  `Codcliente` VARCHAR(10) NULL,
  `DirCli` TINYINT(3) UNSIGNED NULL,
  `Trabajos` LONGTEXT NULL,
  `Observaciones` LONGTEXT NULL,
  `Tipo` VARCHAR(1) NULL,
  `NumPresupuesto` INT(10) NULL,
  `NumOT` INT(10) NULL,
  `NumOTH` VARCHAR(50) NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`Num`),
  INDEX `Codcli` (`Codcliente`),
  CONSTRAINT `ClientesEntradas` FOREIGN KEY `ClientesEntradas` (`Codcliente`)
    REFERENCES `GAdPIME`.`Clientes` (`CodCliente`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`Factura`;
CREATE TABLE `GAdPIME`.`Factura` (
  `Numero` INT(10) NOT NULL,
  `FechaFactura` DATETIME NULL,
  `CodCli` VARCHAR(10) NULL,
  `CodDireccionCli` TINYINT(3) UNSIGNED NULL,
  `tpcIVA` DECIMAL(19, 4) NULL,
  `BaseImp` DECIMAL(19, 4) NULL,
  `ImpTotal` DECIMAL(19, 4) NULL,
  `Cobrada?` VARCHAR(50) NULL,
  `FechaCobrada` DATETIME NULL,
  `PeriodoContable` VARCHAR(6) NULL,
  `Estado` VARCHAR(1) NULL,
  `FechaImpresion` DATETIME NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`Numero`),
  INDEX `CodCli` (`CodCli`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`Factura Detalle`;
CREATE TABLE `GAdPIME`.`Factura Detalle` (
  `Numero` INT(10) NOT NULL,
  `Linea` TINYINT(3) UNSIGNED NOT NULL,
  `NumOT` INT(10) NULL,
  `NumHoja` TINYINT(3) UNSIGNED NULL,
  `Concepto` LONGTEXT NULL,
  `ImpNeto` DECIMAL(19, 4) NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`Numero`, `Linea`),
  INDEX `Factura DetalleNumero` (`Numero`),
  INDEX `FacturaFactura Detalle` (`Numero`),
  CONSTRAINT `FacturaFactura Detalle` FOREIGN KEY `FacturaFactura Detalle` (`Numero`)
    REFERENCES `GAdPIME`.`Factura` (`Numero`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`Operarios`;
CREATE TABLE `GAdPIME`.`Operarios` (
  `Num` TINYINT(3) UNSIGNED NOT NULL,
  `NIF_CIF` VARCHAR(12) NULL,
  `Nombre` VARCHAR(50) NULL,
  `Direccion` VARCHAR(50) NULL,
  `CodPost` VARCHAR(5) NULL,
  `Poblacion` VARCHAR(50) NULL,
  `Telef1` VARCHAR(9) NULL,
  `DesTel1` VARCHAR(50) NULL,
  `Telef2` VARCHAR(9) NULL,
  `DesTel2` VARCHAR(50) NULL,
  `Telef3` VARCHAR(9) NULL,
  `DesTel3` VARCHAR(50) NULL,
  `Fax` VARCHAR(50) NULL,
  `email` VARCHAR(60) NULL,
  `Autonomo` TINYINT(1) NOT NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`Num`),
  INDEX `NIF_CIF` (`NIF_CIF`),
  CONSTRAINT `OTH OperariosOperarios` FOREIGN KEY `OTH OperariosOperarios` (`Num`)
    REFERENCES `GAdPIME`.`OTH Operarios` (`NumOperario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`OT`;
CREATE TABLE `GAdPIME`.`OT` (
  `Numero` INT(10) NOT NULL AUTO_INCREMENT,
  `CodCli` VARCHAR(10) NULL,
  `CodDireccionCli` TINYINT(3) UNSIGNED NULL,
  `NumEntrada` INT(10) NULL,
  `FECHA_ALTA` DATETIME NULL,
  PRIMARY KEY (`Numero`),
  INDEX `CodCli` (`CodCli`),
  INDEX `NumEntrada` (`NumEntrada`),
  CONSTRAINT `EntradasOT` FOREIGN KEY `EntradasOT` (`NumEntrada`)
    REFERENCES `GAdPIME`.`Entradas` (`Num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`OT Hoja`;
CREATE TABLE `GAdPIME`.`OT Hoja` (
  `NumOT` INT(10) NOT NULL,
  `NumHoja` TINYINT(3) UNSIGNED NOT NULL,
  `Fecha` DATETIME NULL,
  `Trabajos efectuados` LONGTEXT NULL,
  `Terminado?` TINYINT(1) NOT NULL,
  `Verificado?` TINYINT(1) NOT NULL,
  `Observaciones` LONGTEXT NULL,
  `NumEntrada` INT(10) NULL,
  `Estado` VARCHAR(1) NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`NumOT`, `NumHoja`),
  INDEX `Estado` (`Estado`),
  INDEX `NumEntrada` (`NumEntrada`),
  INDEX `OTOT Hoja` (`NumOT`),
  CONSTRAINT `OTOT Hoja` FOREIGN KEY `OTOT Hoja` (`NumOT`)
    REFERENCES `GAdPIME`.`OT` (`Numero`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`OTH Materiales`;
CREATE TABLE `GAdPIME`.`OTH Materiales` (
  `NumOT` INT(10) NOT NULL,
  `NumHoja` TINYINT(3) UNSIGNED NOT NULL,
  `Linea` TINYINT(3) UNSIGNED NOT NULL,
  `Descripcion` VARCHAR(255) NULL,
  `Precio` DECIMAL(19, 4) NULL,
  `Cantidad` DECIMAL(19, 4) NULL,
  `Importe` DECIMAL(19, 4) NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`NumOT`, `NumHoja`, `Linea`),
  INDEX `OT HojaOTH Materiales` (`NumOT`, `NumHoja`),
  CONSTRAINT `OT HojaOTH Materiales` FOREIGN KEY `OT HojaOTH Materiales` (`NumOT`, `NumHoja`)
    REFERENCES `GAdPIME`.`OT Hoja` (`NumOT`, `NumHoja`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
ENGINE = INNODB;

CREATE TABLE `GAdPIME`.`OTH_Operarios` (
  `NumOT` INT(10) NOT NULL,
  `NumHoja` TINYINT(3) UNSIGNED NOT NULL,
  `NumOperario` TINYINT(3) UNSIGNED NOT NULL,
  `Horas` DATETIME NULL,
  `Precio_hora` DECIMAL(19, 4) NULL,
  `Importe` DECIMAL(19, 4) NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`NumOT`, `NumHoja`, `NumOperario`),
  INDEX `OT HojaOTH Operarios` (`NumOT`, `NumHoja`),
  CONSTRAINT `OT HojaOTH_Operarios` FOREIGN KEY `OT HojaOTH_Operarios` (`NumOT`, `NumHoja`)
    REFERENCES `GAdPIME`.`OT Hoja` (`NumOT`, `NumHoja`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
ENGINE = INNODB;


DROP TABLE IF EXISTS `GAdPIME`.`Presupuestos`;
CREATE TABLE `GAdPIME`.`Presupuestos` (
  `Numero` INT(10) NOT NULL AUTO_INCREMENT,
  `Fecha` DATETIME NULL,
  `CodCli` VARCHAR(10) NULL,
  `NumEntrada` INT(10) NULL,
  `Resumen` LONGTEXT NULL,
  `Encabezado` LONGTEXT NULL,
  `Trabajos` LONGTEXT NULL,
  `Materiales` LONGTEXT NULL,
  `TextoTotal` LONGTEXT NULL,
  `TituloPie` VARCHAR(50) NULL,
  `Pie` LONGTEXT NULL,
  `Importe` DECIMAL(19, 4) NULL,
  `Observaciones` LONGTEXT NULL,
  `Aceptado` TINYINT(1) NOT NULL,
  `Rechazado` TINYINT(1) NOT NULL,
  `FechaImpresion` DATETIME NULL,
  `FECHA_ALTA` DATETIME NULL,
  `FECHA_MOD` DATETIME NULL,
  PRIMARY KEY (`Numero`),
  INDEX `CodCli` (`CodCli`),
  CONSTRAINT `EntradasPresupuestos` FOREIGN KEY `EntradasPresupuestos` (`NumEntrada`)
    REFERENCES `GAdPIME`.`Entradas` (`Num`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`T Poblacions`;
CREATE TABLE `GAdPIME`.`T Poblacions` (
  `Codi` VARCHAR(5) NULL,
  `Nom` VARCHAR(45) NULL,
  `Comarca` VARCHAR(20) NULL,
  `Id` INT(10) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id` (`Id`),
  INDEX `CODI_MUNIC` (`Codi`),
  INDEX `NOM_MUNIC` (`Nom`)
)
ENGINE = INNODB;

DROP TABLE IF EXISTS `GAdPIME`.`T Text`;
CREATE TABLE `GAdPIME`.`T Text` (
  `Codi` VARCHAR(3) NOT NULL,
  `Text` LONGTEXT NULL,
  PRIMARY KEY (`Codi`)
)
ENGINE = INNODB;



-- -------------------------------------
-- Views

-- DROP VIEW IF EXISTS `GAdPIME`.`ClienteMax`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`ClienteMax` AS
-- SELECT Max(Val(CodCliente))
-- FROM Clientes;

-- DROP VIEW IF EXISTS `GAdPIME`.`Clientes con direccion principal`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`Clientes con direccion principal` AS
-- SELECT Direcciones.*, Clientes.*
-- FROM Direcciones, Clientes
-- WHERE (((Direcciones.Num)=1)) OR (((Direcciones.Num) Is Null));

-- DROP VIEW IF EXISTS `GAdPIME`.`Direcciones Mayores`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`Direcciones Mayores` AS
-- SELECT Max(Direcciones.Num), Direcciones.CodCliente
-- FROM Direcciones;

-- DROP VIEW IF EXISTS `GAdPIME`.`OTH Total`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`OTH Total` AS
-- SELECT `OT Hoja`.`Verificado?`, OT.CodCli, Clientes.Nombre, `OT Hoja`.NumOT, `OT Hoja`.NumHoja, `OT Hoja`.`Terminado?`, `OT Hoja`.Estado, Val(Nz(`OTH Total Mano de Obra`.`SumaDeImporte`,0)), Val(Nz(`OTH Total Material`.`SumaDeImporte`,0)), `ImpMO`+`ImpMat`, `BaseImp`*(`OT Hoja`.`Terminado?`+1), `BaseImp`*(`OT Hoja`.`Terminado?`*(-1)*(`OT Hoja`.`Verificado?`+1)), `BaseImp`*(`OT Hoja`.`Terminado?`*`OT Hoja`.`Verificado?`), `OT Hoja`.Fecha
-- FROM OT INNER JOIN OT Hoja ON OT.Numero = `OT Hoja`.NumOT, OT INNER JOIN Clientes ON OT.CodCli = Clientes.CodCliente, OTH Total Mano de Obra, OTH Total Material;

-- DROP VIEW IF EXISTS `GAdPIME`.`OTH Total Activas`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`OTH Total Activas` AS
-- SELECT `OTH Total`.*
-- FROM OTH Total
-- WHERE (((Nz(`Estado`,""))<>"2"))
-- ORDER BY `OTH Total`.NumHoja, `OTH Total`.NumOT, `OTH Total`.CodCli;

-- DROP VIEW IF EXISTS `GAdPIME`.`OTH Total Mano de Obra`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`OTH Total Mano de Obra` AS
-- SELECT Sum(`OTH Operarios`.Importe), Sum(`OTH Operarios`.Horas), Count(`OTH Operarios`.NumOperario), `OTH Operarios`.NumHoja, `OTH Operarios`.NumOT
-- FROM OTH Operarios;

-- DROP VIEW IF EXISTS `GAdPIME`.`OTH Total Material`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`OTH Total Material` AS
-- SELECT Sum(`OTH Materiales`.Importe), `OTH Materiales`.NumHoja, `OTH Materiales`.NumOT
-- FROM OTH Materiales;

-- DROP VIEW IF EXISTS `GAdPIME`.`OTHs a facturar`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`OTHs a facturar` AS
-- SELECT `OT Hoja`.NumOT, OT.CodDireccionCli, `OT Hoja`.NumHoja, `OT Hoja`.`Trabajos efectuados`, `OT Hoja`.Estado, `OT Hoja`.NumFactura, `OT Hoja`.LinFactura, OT.CodCli
-- FROM OT INNER JOIN OT Hoja ON OT.Numero = `OT Hoja`.NumOT
-- WHERE (((`OT Hoja`.Estado)="1") AND ((`OT Hoja`.`Terminado?`)=True) AND ((`OT Hoja`.`Verificado?`)=True) AND ((Nz(`NumFactura`,0))=0));

-- DROP VIEW IF EXISTS `GAdPIME`.`Selec Entradas`;
-- CREATE OR REPLACE VIEW `GAdPIME`.`Selec Entradas` AS
-- SELECT Entradas.Tipo, Entradas.NumPresupuesto, Entradas.NumOT, Entradas.NumOTH, Entradas.Num, Entradas.Fecha, Entradas.Codcliente, Entradas.Observaciones, Clientes.`NIF/CIF`, Clientes.Nombre, Clientes.Telef1, Clientes.DesTel1, Clientes.`Persona Contacto`, Entradas.DirCli, Direcciones.Descripcion, Direcciones.Direccion, Direcciones.CodPost, Direcciones.Poblacion, Entradas.Trabajos
-- FROM Entradas INNER JOIN Direcciones ON Entradas.DirCli = Direcciones.Num, Clientes INNER JOIN Entradas ON Clientes.CodCliente = Entradas.Codcliente, Entradas INNER JOIN Direcciones ON Entradas.Codcliente = Direcciones.CodCliente;



SET FOREIGN_KEY_CHECKS = 1;

-- ----------------------------------------------------------------------
-- EOF

