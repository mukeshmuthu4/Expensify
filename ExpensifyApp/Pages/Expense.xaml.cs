namespace ExpensifyApp.Pages;

public partial class Expense : ContentView
{
	public Expense()
	{
		InitializeComponent();
        this.IsVisible = false; // Initially hidden
    }

    public void ShowPopup()
    {
        this.IsVisible = true;
    }

    private void ClosePopup(object sender, EventArgs e)
    {
        this.IsVisible = false;
    }

    private void saveButton_Clicked(object sender, EventArgs e)
    {

    }
}
