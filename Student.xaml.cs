using exam.Models;

namespace exam;

public partial class Student : ContentPage
{
    public Student()
    {
        InitializeComponent();
        Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();
    }
    private void Gender_RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender == Male_RadioButton && e.Value)
        {
            Female_RadioButton.IsChecked = false;
        }
        else if (sender == Female_RadioButton && e.Value)
        {
            Male_RadioButton.IsChecked = false;
        }
    }
    private void Button_Add_Clicked(object sender, EventArgs e)
    {
        string gender = null;
        if (Male_RadioButton.IsChecked)
        {
            gender = "Male";
        }
        else if (Female_RadioButton.IsChecked)
        {
            gender = "Female";
        }
        App.DBTrans.AddS(new Models.StudentClass
        {
            Student_Name = Student_Name.Text,
            Student_Department = Student_Department.Text,
            Gender = gender

        });
        Student_Name.Text = string.Empty;
        Student_Department.Text = string.Empty;
        Male_RadioButton.IsChecked = false;
        Female_RadioButton.IsChecked = false;
    }

    private void Button_show_Clicked(object sender, EventArgs e)
    {
        Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();

    }

    private void Button_delete_Clicked(object sender, EventArgs e)
    {
        if (Global.selectedStudent != null)
        {
            App.DBTrans.DeleteS(Global.selectedStudent.Student_Id);

            Stu_List_View.ItemsSource = App.DBTrans.GetAllStudents();


            Global.selectedStudent = null;

            DisplayAlert("Success", "Student deleted successfully.", "OK");
        }
        else
        {
            DisplayAlert("Error", "No student selected.", "OK");
        }
    }
    private void Stu_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Global.selectedStudent = e.Item as StudentClass;
    }

}