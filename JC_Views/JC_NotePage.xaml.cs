namespace JC_mauiApuntes.JC_Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class JC_NotePage : ContentPage
{
    
    public string ItemId
    {
        set { LoadNote(value); }
    }
    
    public JC_NotePage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is JC_Models.JC_Note note)
            File.WriteAllText(note.Filename, JC_TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is JC_Models.JC_Note note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        JC_Models.JC_Note noteModel = new JC_Models.JC_Note();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}