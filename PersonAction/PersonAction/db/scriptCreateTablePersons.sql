CREATE TABLE `persons` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`FirstName` VARCHAR(50) NULL DEFAULT NULL,
	`LastName` VARCHAR(50) NULL DEFAULT NULL,
	`Address` VARCHAR(50) NULL DEFAULT NULL,
	`Gender` VARCHAR(50) NULL DEFAULT NULL,
	PRIMARY KEY (`Id`)
)