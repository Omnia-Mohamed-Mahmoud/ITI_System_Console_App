using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ITI
{
    public class Courses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrackId{get;set;}
        public int InstructorId{get;set;}

        //public int TrackId {get;set;}


        //Track Track;
        //List<Instructor> Instructors;
        //List<Student> Students;

        //int [] StdDegree ;

        public Courses(){
            // Id = id;
            // CourseName = courseName;
            // TrackId = trackId;
        }

        // public void SetCoursesProp(int id , string coursename , Track track , List<Instructor>instructors , List<Student> students)
        // {
        //      Id = id ;
        //     CourseName = coursename;
        //     Track = track;
        //     Instructors = instructors;
        //     Students = students;
        // }
       

        public List<Courses> showCourses(int trackid){
            // Read Json
                string json = File.ReadAllText(@"Courses.json");
                List<Courses> allCourses = JsonConvert.DeserializeObject<List<Courses>>(json);
                List<Courses> TrackCourses = new  List<Courses>();
                for(int i = 0 ; i < allCourses.Count ; i++){
                   if(allCourses[i].TrackId == trackid){
                   TrackCourses.Add(allCourses[i]);
                   }
                }
                return TrackCourses;
        }

        
        public List<Courses> showInstructorCourses(int instructorId){
            // Read Json
                string json = File.ReadAllText(@"Courses.json");
                List<Courses> allCourses = JsonConvert.DeserializeObject<List<Courses>>(json);
                List<Courses> InstructorCourses = new  List<Courses>();
                for(int i = 0 ; i < allCourses.Count ; i++){
                   if(allCourses[i].InstructorId == instructorId){
                   InstructorCourses.Add(allCourses[i]);
                   }
                }
                return InstructorCourses;
        }


        public void addNewCourse(int trackId)
        {
                //OverRidde Object 
                Console.WriteLine("Enter Course ID");
                Id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Course Name");
                Name = Console.ReadLine();
                // Console.WriteLine();

                // Show All Instructors
                Instructor i1 = new Instructor();
                i1.ShowAllInstructor();
                Console.WriteLine("Enter Instructor ID");
                InstructorId = int.Parse(Console.ReadLine());
        
                TrackId = trackId;
            
                // Read Json
                string json = File.ReadAllText(@"Courses.json");
                List<Courses> allCourses = JsonConvert.DeserializeObject<List<Courses>>(json);


                Courses NewCourse = this;
                allCourses.Add(NewCourse);
                var StoreStudentData = JsonConvert.SerializeObject(allCourses, Formatting.Indented);
                File.WriteAllText(@"Courses.json", 
                    StoreStudentData);
                // Console.ReadKey();

        }

        public void addNewCourses( int trackId){
            Console.WriteLine("How Many Courses Do You Want To Add?");
            int count = int.Parse(Console.ReadLine());
            for(int i = 1 ; i <= count ; i ++){

                Console.WriteLine("Please Enter Details For Course " + i);

                addNewCourse(trackId);
                Console.WriteLine("------------");


            }
        }

        public void EditCourse(){
            Console.WriteLine("Please Enter Course ID");
            int CourseId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(@"Courses.json");
            List<Courses> allCourses = JsonConvert.DeserializeObject<List<Courses>>(json);
            int position = 0;
            for(int i = 0 ; i < allCourses.Count ; i++){
                if(allCourses[i].Id == CourseId){
                    Console.WriteLine("Course ID = " + allCourses[i].Id);
                    Console.WriteLine("Course Name = " + allCourses[i].Name);
                    Console.WriteLine("Course TrackID = " + allCourses[i].TrackId);
                    Console.WriteLine("Course TrackID = " + allCourses[i].InstructorId);

                    position = i;
                    break; 
                }
            }

            Console.WriteLine("------------------");
            Console.WriteLine("[ 1 ] Edit Course ID");
            Console.WriteLine("[ 2 ] Edit Course Name");
            Console.WriteLine("[ 3 ] Edit Track ID");
            Console.WriteLine("[ 4 ] Edit Instructor ID");


            Console.WriteLine("What Do You Want To Edit");
            int action = int.Parse(Console.ReadLine());
             switch (action)
            {
                case 1:
                    Console.WriteLine("Please Enter New Course ID");
                    allCourses[position].Id = int.Parse(Console.ReadLine());
                    //c1.addNewCourse(trackid);
                    break;
                case 2:
                    Console.WriteLine("Please Enter New Course Name");
                    allCourses[position].Name = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Please Enter New Track ID");
                    allCourses[position].TrackId = int.Parse(Console.ReadLine());
                    break;
                case 4:
                    Instructor i1 = new Instructor();
                    i1.ShowAllInstructor();
                    Console.WriteLine("Please Enter New Instructor ID");
                    allCourses[position].TrackId = int.Parse(Console.ReadLine());
                    break;



            }

            var StoreStudentData = JsonConvert.SerializeObject(allCourses, Formatting.Indented);
                File.WriteAllText(@"Courses.json", 
                    StoreStudentData);




        }

        public void DeleteCourse(){

            Console.WriteLine("Please Enter Course ID");
            int CourseId = int.Parse(Console.ReadLine());

            string json = File.ReadAllText(@"Courses.json");
            List<Courses> allCourses = JsonConvert.DeserializeObject<List<Courses>>(json);
            int position = 0;
            for(int i = 0 ; i < allCourses.Count ; i++){
                if(allCourses[i].Id == CourseId){
                    position = i;
                    break; 
                }
            }

            allCourses.Remove(allCourses[position]);
            var StoreStudentData = JsonConvert.SerializeObject(allCourses, Formatting.Indented);
                File.WriteAllText(@"Courses.json", 
                    StoreStudentData);




        }

        public void returnListOfCourses(){}

    }
}
