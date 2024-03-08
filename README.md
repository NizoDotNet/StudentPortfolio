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
08.03.2024
1. Implement claims based auth.
...

