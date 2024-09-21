namespace MVC_Day1.Models
{
    public class StudentBL
    {
        List<Student> students;

        public StudentBL()
        {
            students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Amir", Age = 22, ImageUrl = "m.jpg", DeptId = 1 },
                new Student() { Id = 2, Name = "Ashraf", Age = 23, ImageUrl = "m.jpg", DeptId = 1 },
                new Student() { Id = 3, Name = "Shimaa", Age = 22, ImageUrl = "f.jpg", DeptId = 2 },
                new Student() { Id = 4, Name = "Shahd", Age = 24, ImageUrl = "f.jpg", DeptId = 3 },
                new Student() { Id = 5, Name = "Abanoub", Age = 21, ImageUrl = "m.jpg", DeptId = 2 }
            };
        }

        public List<Student> getAll()
        {
            return students;
        }

        public Student getById(int id)
        {
            return students.First(x => x.Id == id);
        }
    }
}
