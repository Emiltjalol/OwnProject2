namespace OwnProject2.Views;

public partial class DogInformationPage : ContentPage
{

    public DogInformationPage(List<Models.Dog> dogInformation)
    {
        InitializeComponent();
        this.BindingContext = dogInformation;

    }

}

