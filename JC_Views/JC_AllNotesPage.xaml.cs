namespace JC_mauiApuntes.JC_Views;

public partial class JC_AllNotesPage : ContentPage
{
    public JC_AllNotesPage()
    {
        InitializeComponent();

        BindingContext = new JC_Models.AllNotes();
    }

    protected override void OnAppearing()
    {
        ((JC_Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(JC_NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (JC_Models.JC_Note)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(JC_NotePage)}?{nameof(JC_NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}