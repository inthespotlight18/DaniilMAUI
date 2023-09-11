//using Microsoft.Identity.Client;

//namespace DaniilMAUI;

//public partial class MainPage : ContentPage
//{
//	int count = 0;

//	public MainPage()
//	{
//		InitializeComponent();
//	}

//	private void OnCounterClicked(object sender, EventArgs e)
//	{
//		count++;

//		if (count == 1)
//			CounterBtn.Text = $"Clicked {count} time";
//		else
//			CounterBtn.Text = $"Clicked {count} times";

//		SemanticScreenReader.Announce(CounterBtn.Text);
//	}
//}


//-----------------------------------------------


//using Android.Widget;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using CommunityToolkit.Maui.Alerts;



namespace DaniilMAUI;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

}
