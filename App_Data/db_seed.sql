INSERT INTO [SPECIALTY] ([description]) VALUES ( 'radiology'), ( 'surgery'), ( 'dentistry')

INSERT INTO [VET]           ([firstname] ,[lastname] )
     VALUES (  'James',   'Carter'),
			(  'Helen',   'Leary'),
				(  'Linda',   'Douglas'),
			(  'Rafael',   'Ortega'),
			(  'Henry',   'Stevens'),
			(  'Sharon',   'Jenkins' )

INSERT INTO [VET_SPECIALTIES]          ([vet]          ,[specialty])
     VALUES (1,1), (2,2) , (2,3) , (3,1), (3,2)

INSERT INTO [PET_TYPE]           ([description])
     VALUES ('dog'), ('lizard'), ('cat'), ('snake'), ('bird'), ('hamster')

INSERT INTO [OWNER]           ([firstname]           ,[lastname]           ,[address]           ,[city]           ,[telephone])
     VALUES
		 (  'John', 'Smith',    '123 EZ St.',  'NO',  '123-876-7657'),
			 (  'Jane','Smith',     '456 My Way',  'NY',  '456-786-7685'),
			 (  'Woody','Bubinga',     '789 Hard Road',  'WI',  '789-098-9876'),
			 ('Travis', 'Smith', '55433 No Way', 'HI', '654-543-5433' )

INSERT INTO [dbo].[PET]
           ([name]
           ,[birthdate]
           ,[pet_type]
           ,[owner])
     VALUES ( 'Lucinda-belle' , '2-6-2009' , 1 , 1 ) ,
            ( 'Mr Markus', '5-4-2008' , 2, 2) ,
            ( 'Feather' , '3-4-2007' , 3, 3 ) ,
            ( 'Ripley', '6-2-2014' , 2, 4 )
