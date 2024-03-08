Things I wanna implement in this project
1. Claims:
	Student
	Teacher
	Super-Admin
2. Models:
	Student (guid id, name, email, course, Subjects, PowerPoint Presentations)
	Teacher (guid id, name, subjects, email, phone number)
	Subjects (guid id, name, laboratory works(can be null), assignments(can be null), Teachers id, creadits, hours)
3. Relationships:
	Student - Subject => one-to-many
	Teacher - Subjects => many-to-many
4. Main Pages:
	Index => Shecdule or to-do list
	Account => Finished and unfinshed homeworks, grades
	Teachers-Profiles => Just Information
	Chat-Room => Group chat and one-to-one chat

ToDo:
1. Implement Authorization and Authentication 
1.1 Use AspNet identity and create Register, Login, Profile
1.2 Profiles can be PRIVITE
...

