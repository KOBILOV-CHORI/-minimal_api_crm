 create database crm_crud_db;
 
 create table courses(
 	id serial primary key,
	name varchar(255),
	price float,
	createdat date
 );
 
 create table groups(
 	 id serial primary key,
	 name varchar(255),
	 maxstudent int,
	 createdat date,
	 lessonperweek int,
	 courseid int references courses (id)
 );
 
 create table mentors(
 	 id serial primary key,
	 firstname varchar(255),
	 lastname varchar(255),
	 dateofbirth date,
	 email varchar(255)
 );
 
 create table mentorgroups(
 	 id serial primary key,
	 mentorid int references mentors (id),
	 groupid int references groups (id)
);

 create table students(
 	 id serial primary key,
	 firstname varchar(255),
	 lastname varchar(255),
	 dateofbirth date,
	 email varchar(255)
 );
 
  create table studentgroups(
 	 id serial primary key,
	 studentid int references students (id),
	 groupid int references groups (id)
);
 
 