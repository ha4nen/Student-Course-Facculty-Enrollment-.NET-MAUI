using exam.Models;

namespace exam;

public partial class Faculty : ContentPage
{
	public Faculty()
	{
		InitializeComponent();
        f_List_View.ItemsSource = App.DBTrans.GetAllFaculties();

    }
    private void Button_Add_Clicked(object sender, EventArgs e)
    {
        App.DBTrans.AddF(new Models.FacultyClass
        {
            Faculty_Name = Faculty_Name.Text,
            Faculty_Department = Faculty_Department.Text,
            IsDean = Dean_CheckBox.IsChecked,
            IsHeadOfDepartment = HOD_CheckBox.IsChecked,
            IsProfessor = Professor_CheckBox.IsChecked
        });
        Faculty_Name.Text = string.Empty;
        Faculty_Department.Text = string.Empty;
        Dean_CheckBox.IsChecked = false;
        HOD_CheckBox.IsChecked = false;
        Professor_CheckBox.IsChecked = false;

    }

    private void Button_show_Clicked(object sender, EventArgs e)
    {
        f_List_View.ItemsSource = App.DBTrans.GetAllFaculties();

    }

    private void Button_delete_Clicked(object sender, EventArgs e)
    {
        if (Global.selectedFaculty != null)
        {
            App.DBTrans.DeleteF(Global.selectedFaculty.Faculty_Id);

            f_List_View.ItemsSource = App.DBTrans.GetAllFaculties();


            Global.selectedFaculty = null;

            DisplayAlert("Success", "Student deleted successfully.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No student selected.", "OK");
        }
    }
    private void f_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedFaculty = e.Item as FacultyClass;
    }

}