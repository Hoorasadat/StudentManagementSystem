namespace StudentManagementSystem.WEB.ViewModels
{
    public class EditStudentViewModel : CreateStudentViewModel
    {
        public int Id { get; set; }
        public string? ExistingPhoto { get; set; }
    }
}
