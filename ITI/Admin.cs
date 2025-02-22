using System;

namespace ITI
{
    public class Admin:User
    {
        Courses c1 = new Courses();
        Track t1 = new Track();


        public Admin()
        {
            base.Rule = "admin";
            base.Path = "C:\\Users\\DELL\\Desktop\\omnia\\ITI_Test_Rep\\ITI\\Admin.json";
        }

        public void WelcomeScreen()
        {

            base.WelcomeScreen();
            int action = int.Parse(Console.ReadLine());
            if (action == 1)
            {
                login(this);
                AdminDashboard();
            }
            else if (action == 2)
            {
                register(this);
                WelcomeScreen();
            }
        }

        public void AdminDashboard()
        {
            Console.WriteLine("Welcome Mr " + UserName);
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] Student");
            Console.WriteLine("[ 2 ] Instructor");
            Console.WriteLine("[ 3 ] Tracks");


            Console.Write("\n>>  ");
            int action = int.Parse(Console.ReadLine());
            switch (action)
            {
                case 1:
                    StudentPart();
                    break;
                case 2:
                    InstructorPart();
                    break;
                case 3:
                    TracksDashboard();
                    break;

            }
        }

        public void StudentPart()
        {
            Student s1 = new Student();
            Console.WriteLine("Welcome in Section Student");
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] Add Student");
            Console.WriteLine("[ 2 ] Edit Student");
            Console.WriteLine("[ 3 ] Delete Student");
            Console.WriteLine("[ 0 ] Go Back");

            Console.WriteLine("\n>> ");
            int choiceAction = int.Parse(Console.ReadLine());

            switch (choiceAction)
            {
                case 1:
                    s1.register(s1);
                    break;
                case 2:
                    s1.ShowAllStudents();
                    s1.EditStudent();
                    break;
                case 3:
                    s1.ShowAllStudents();
                    s1.DeleteStudent();
                    break;
                case 0:
                    AdminDashboard();
                    break;
            }
        }


        public void InstructorPart()
        {
            Instructor I1 = new Instructor();
            Console.WriteLine("Welcome in Section Instructor");
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] Add Instructor");
            Console.WriteLine("[ 2 ] Edit Instructor");
            Console.WriteLine("[ 3 ] Delete Instructor");
            Console.WriteLine("[ 0 ] Go Back");

            Console.WriteLine("\n>> ");
            int choiceAction = int.Parse(Console.ReadLine());

            switch (choiceAction)
            {
                case 1:
                    I1.register(I1);
                    break;
                case 2:
                    I1.ShowAllInstructor();
                    I1.EditInstructor();
                    break;
                case 3:
                    I1.ShowAllInstructor();
                    I1.DeleteInstructor();
                    break;
                case 0:
                    AdminDashboard();
                    break;

            }
        }


        public void TracksDashboard()
        {
            Console.WriteLine("Welcome To Tracks Dashboard");
            Console.WriteLine("---------------------------");
            Console.WriteLine("[ 1 ] View Track");
            Console.WriteLine("[ 2 ] Add Track");
            Console.WriteLine("[ 3 ] Edit Track");
            Console.WriteLine("[ 4 ] Delete Track");
            Console.WriteLine("[ 0 ] Go Back");

            Console.WriteLine("\n>> ");
            int choiceAction = int.Parse(Console.ReadLine());

            switch (choiceAction)
            {
                case 1:
                    t1.ViewTrack();//ID , Name
                    break;
                case 2:
                    t1.addNewTrack();//ID , Name
                    break;
                case 3:
                    t1.EditTrack();
                    break;
                case 4:
                    //SetExam();
                    break;
                case 0:
                    AdminDashboard();
                    break;

            }
        }



       
    }
}