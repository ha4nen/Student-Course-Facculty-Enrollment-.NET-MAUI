using exam.Models;

namespace exam;

public partial class Course : ContentPage
{
	public Course()
	{
		InitializeComponent();
        c_List_View.ItemsSource = App.DBTrans.GetAllCourses();
    }
    private void Button_Add_Clicked(object sender, EventArgs e)
    {
        App.DBTrans.AddC(new Models.CourseClass
        {
            Course_Name = Course_Name.Text,
            Course_Code = Course_Code.Text,
        });
        Course_Name.Text = string.Empty;
        Course_Code.Text = string.Empty;

    }

    private void Button_show_Clicked(object sender, EventArgs e)
    {
        c_List_View.ItemsSource = App.DBTrans.GetAllCourses();

    }

    private void Button_delete_Clicked(object sender, EventArgs e)
    {
        if (Global.selectedCourse != null)
        {
            App.DBTrans.DeleteC(Global.selectedCourse.Course_Id);

            c_List_View.ItemsSource = App.DBTrans.GetAllCourses();


            Global.selectedCourse = null;

            DisplayAlert("Success", "Student deleted successfully.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No student selected.", "OK");
        }
    }
    private void c_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedCourse = e.Item as CourseClass;
    }

}