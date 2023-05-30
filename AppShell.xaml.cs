namespace JC_mauiApuntes;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(JC_Views.JC_NotePage), typeof(JC_Views.JC_NotePage));
    }
}
