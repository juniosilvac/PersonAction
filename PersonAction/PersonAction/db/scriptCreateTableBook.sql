﻿CREATE TABLE `books` (
	`Id` INT(11) NOT NULL AUTO_INCREMENT,
	`Author` LONGTEXT NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	`LaunchDate` DATETIME(6) NOT NULL,
	`Price` DECIMAL(65,2) NOT NULL,
	`Title` LONGTEXT NULL DEFAULT NULL COLLATE 'latin1_swedish_ci',
	PRIMARY KEY (`Id`) USING BTREE
)