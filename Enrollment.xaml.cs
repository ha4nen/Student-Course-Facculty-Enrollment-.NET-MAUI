using exam.Models;

namespace exam;

public partial class Enrollment : ContentPage
{

    public Enrollment()
    {
        InitializeComponent();
        Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
        Course_List_View.ItemsSource = App.DBTrans.GetAllCourses();
        Enrollments_List_View.ItemsSource = App.DBTrans.GetAllEntroll();
        f_List_View.ItemsSource = App.DBTrans.GetAllFaculties();

    }

    private void Stu_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedStudent = e.Item as StudentClass;

    }

    private void Course_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedCourse = e.Item as CourseClass;

    }
    private void f_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedFaculty = e.Item as FacultyClass;
    }
    private void Button_Add_Clicked(object sender, EventArgs e)
    {

        if (Global.selectedStudent != null && Global.selectedCourse != null)
        {
            App.DBTrans.AddE(new EnrollClass
            {
                Student_Name = Global.selectedStudent.Student_Name,
                Cousre_Name = Global.selectedCourse.Course_Name,
                Faculty_Name= Global.selectedFaculty.Faculty_Name,
            });
        }
        else
        {
            DisplayAlert("Error", "Please select a student and a course .", "OK");
        }

    }

    private void Button_show_Clicked(object sender, EventArgs e)
    {
        Enrollments_List_View.ItemsSource = App.DBTrans.GetAllEntroll();


    }

    private void Button_delete_Clicked(object sender, EventArgs e)
    {
        if (Global.selectedEntroll != null)
        {
            App.DBTrans.DeleteE(Global.selectedEntroll.Enroll_Id);

            Enrollments_List_View.ItemsSource = App.DBTrans.GetAllEntroll();


            Global.selectedEntroll = null;

            DisplayAlert("Success", "Enrollment deleted successfully.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No Enrollment selected.", "OK");
        }
    }

    private void Enrollments_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedEntroll = e.Item as EnrollClass;

    }

}