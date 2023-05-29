namespace JC_mauiApuntes;

public partial class JC_AboutPage : ContentPage
{
	public JC_AboutPage()
	{
		InitializeComponent();
	}

    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}