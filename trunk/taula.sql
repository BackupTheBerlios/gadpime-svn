# MySQL Navigator Xport
# Database: gadpime
# gadpime@localhost

# CREATE DATABASE gadpime;
# USE gadpime;

#
# Table structure for table 'clients'
#

# DROP TABLE IF EXISTS clients;
CREATE TABLE `clients` (
  `id` int(11) NOT NULL auto_increment,
  `name` text NOT NULL,
  `surname1` text,
  `surname2` text,
  PRIMARY KEY  USING BTREE (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

#
# Dumping data for table 'clients'
#

INSERT INTO clients VALUES (2,'a','b','c');
INSERT INTO clients VALUES (3,'ss','dd','ff');
INSERT INTO clients VALUES (4,'','','');
INSERT INTO clients VALUES (6,'oscar','2','2');
INSERT INTO clients VALUES (7,'oscar','3','');
INSERT INTO clients VALUES (8,'oscar','','4');

