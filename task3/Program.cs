namespace task3
{
    class Instructor
    {
        public int InstructorId;
        public string Name;
        public string Specialization;

        public Instructor(int instructorId, string name, string specialization)
        {
            this.InstructorId = instructorId;
            this.Name = name;
            this.Specialization = specialization;
        }

        public string PrintDetails()
        {
            if (this.InstructorId < 0)
            {
                return "";
            }
            return "Instructor ID: " + InstructorId + ", Name: " + Name + ", Specialization: " + Specialization;
        }
    }

    class Course
    {
        public int CourseId;
        public string Title;
        public Instructor Instructor;

        public Course(int courseId, string title, Instructor instructor)
        {
            this.CourseId = courseId;
            this.Title = title;
            this.Instructor = instructor;
        }

        public string PrintDetails()
        {
            if (this.CourseId < 0)
            {
                return "";
            }
            if (this.Instructor == null)
            {
                return "CourseId: " + CourseId + ", Title: " + Title + ", Instructor: None";
            }
            return "CourseId: " + CourseId + ", Title: " + Title + ", Instructor: " + Instructor.Name;
        }
    }

    class Student
    {
        public int StudentId;
        public string Name;
        public int Age;
        public List<Course> Courses;

        public Student(int studentId, string name, int age)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;
            this.Courses = new List<Course>();
        }

        public bool Enroll(Course course)
        {
            if (course == null)
            {
                return false;
            }

            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].CourseId == course.CourseId)
                {
                    return false; 
                }
            }

            this.Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            if (this.StudentId < 0)
            {
                return "";
            }
            return "StudentId: " + StudentId + ", Name: " + Name + ", Age: " + Age;
        }
    }

    class StudentManager
    {
        public List<Student> Students;
        public List<Course> Courses;
        public List<Instructor> Instructors;

        public StudentManager()
        {
            Students = new List<Student>();
            Courses = new List<Course>();
            Instructors = new List<Instructor>();
        }

        public bool AddStudent(Student student)
        {
            if (student == null)
            {
                return false;
            }

            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == student.StudentId)
                {
                    return false;
                }
            }

            Students.Add(student);
            return true;
        }

        public bool AddCourse(Course course)
        {
            if (course == null)
            {
                return false;
            }

            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == course.CourseId)
                {
                    return false;
                }
            }

            Courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                return false;
            }

            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructor.InstructorId)
                {
                    return false;
                }
            }

            Instructors.Add(instructor);
            return true;
        }

        public Student FindStudent(int studentId)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }

        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            int choice = 0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find Student");
                Console.WriteLine("9. Find Course");
                Console.WriteLine("10. Exit");
                Console.Write("Choose: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Student Id: ");
                        int studentId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string studentName = Console.ReadLine();
                        Console.Write("Age: ");
                        int age = int.Parse(Console.ReadLine());

                        Student student = new Student(studentId, studentName, age);
                        if (manager.AddStudent(student))
                            Console.WriteLine("Student added.");
                        else
                            Console.WriteLine("Id already exists.");
                        break;

                    case 2:
                        Console.Write("Instructor Id: ");
                        int instructorId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string instructorName = Console.ReadLine();
                        Console.Write("Specialization: ");
                        string spec = Console.ReadLine();

                        Instructor instructor = new Instructor(instructorId, instructorName, spec);
                        if (manager.AddInstructor(instructor))
                            Console.WriteLine("Instructor added.");
                        else
                            Console.WriteLine("Id already exists.");
                        break;

                    case 3:
                        Console.Write("Course Id: ");
                        int courseId = int.Parse(Console.ReadLine());
                        Console.Write("Title: ");
                        string title = Console.ReadLine();
                        Console.Write("Instructor Id: ");
                        int instId = int.Parse(Console.ReadLine());

                        Instructor foundInstructor = manager.FindInstructor(instId);
                        if (foundInstructor == null)
                        {
                            Console.WriteLine("Instructor not found.");
                        }
                        else
                        {
                            Course course = new Course(courseId, title, foundInstructor);
                            if (manager.AddCourse(course))
                                Console.WriteLine("Course added.");
                            else
                                Console.WriteLine("Id already exists.");
                        }
                        break;

                    case 4:
                        Console.Write("Student Id: ");
                        int sId = int.Parse(Console.ReadLine());
                        Console.Write("Course Id: ");
                        int cId = int.Parse(Console.ReadLine());

                        if (manager.EnrollStudentInCourse(sId, cId))
                            Console.WriteLine("Enrolled.");
                        else
                            Console.WriteLine("Failed: not found or already enrolled.");
                        break;

                    case 5:
                        for (int i = 0; i < manager.Students.Count; i++)
                        {
                            Console.WriteLine(manager.Students[i].PrintDetails());
                        }
                        break;

                    case 6:
                        for (int i = 0; i < manager.Courses.Count; i++)
                        {
                            Console.WriteLine(manager.Courses[i].PrintDetails());
                        }
                        break;

                    case 7:
                        for (int i = 0; i < manager.Instructors.Count; i++)
                        {
                            Console.WriteLine(manager.Instructors[i].PrintDetails());
                        }
                        break;

                    case 8:
                        Console.Write("Enter student id: ");
                        int searchStudentId = int.Parse(Console.ReadLine());
                        Student foundStudent = manager.FindStudent(searchStudentId);
                        if (foundStudent == null)
                            Console.WriteLine("Student not found.");
                        else
                            Console.WriteLine(foundStudent.PrintDetails());
                        break;

                    case 9:
                        Console.Write("Enter course id: ");
                        int searchCourseId = int.Parse(Console.ReadLine());
                        Course foundCourse = manager.FindCourse(searchCourseId);
                        if (foundCourse == null)
                            Console.WriteLine("Course not found.");
                        else
                            Console.WriteLine(foundCourse.PrintDetails());
                        break;

                    case 10:
                        Console.WriteLine("Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 10);
        }
    }
}