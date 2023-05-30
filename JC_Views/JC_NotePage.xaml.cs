namespace JC_mauiApuntes.JC_Views;

public partial class JC_NotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "JC_BaseApuntes.txt");
    public JC_NotePage()
	{
		InitializeComponent();
        if (File.Exists(_fileName))
            JC_TextEditor.Text = File.ReadAllText(_fileName);
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Save the file.
        File.WriteAllText(_fileName, JC_TextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        // Delete the file.
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        JC_TextEditor.Text = string.Empty;
    }
}