namespace OwnProject2.Views;

public partial class ShowAllDogsPage : ContentPage
{
    public ShowAllDogsPage(List<Models.Dog> dogInformation)
    {
        InitializeComponent();
        this.BindingContext = dogInformation;
    }



    private async void SelectedDogBreed(object sender, SelectedItemChangedEventArgs e)
    {
        var selectedDog = ((ListView)sender).SelectedItem as Models.Dog;
        ((ListView)sender).SelectedItem = null;

        if (selectedDog != null)
        {
            var dogList = new List<Models.Dog> { selectedDog }; 
            var page = new DogInformationPage(dogList); 
            page.BindingContext = selectedDog;
            await Navigation.PushAsync(page);
        }
    }
}