Create database Agenda;

use Agenda;

CREATE TABLE contactos(
  Id_Contacto INT NOT NULL AUTO_INCREMENT,
  Nombre VARCHAR(50) NOT NULL,
  Telefono VARCHAR(9) NOT NULL,
  Correo  VARCHAR(45),
  Direccion VARCHAR(100),
  PRIMARY KEY (Id_Contacto)
 ) ENGINE = InnoDB;

select * from contactos

DELIMITER $$
CREATE PROCEDURE Sp_Guardar(
 in NombreC VARCHAR(50),
 in TelefonoC VARCHAR(9),
 in CorreoC  VARCHAR(45),
 in DireccionC VARCHAR(100)
)
BEGIN 
	insert into contactos(Nombre,Telefono,Correo,Direccion) values (NombreC,TelefonoC,CorreoC,DireccionC);
END;
