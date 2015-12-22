
create table OWNER (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 firstname varchar(200) NOT NULL,
 lastname varchar(200) NOT NULL,
 address varchar(200) NOT NULL,
 city varchar(200) NOT NULL,
 telephone varchar(200) NOT NULL
)
create table PET (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 name varchar(200) NOT NULL,
 birthdate date NULL,
 pet_type int NULL,
 owner int NULL
)
create table PET_TYPE (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 description varchar(200) NOT NULL
)

create table VISIT (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 [date] date NOT NULL,
 description varchar(200) NOT NULL,
 pet int NOT NULL
)

create table VET (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 firstname varchar(200) NOT NULL,
 lastname varchar(200) NOT NULL
)

create table SPECIALTY (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 description varchar(200) NOT NULL
)
create table VET_SPECIALTIES (
 id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
 vet int NOT NULL,
 specialty int NOT NULL
)

-- NOT SHOWN: foreign keys and secondary indexes
