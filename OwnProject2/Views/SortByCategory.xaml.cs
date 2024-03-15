
using MongoDB.Driver;
using OwnProject2.DataMananger;

namespace OwnProject2.Views;

public partial class SortByCategory : ContentPage
{
	public SortByCategory()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }


    private async Task<List<Models.Dog>> GetDogsFromDB()
    {
        Task<List<Models.Dog>> fetchTask = Data.DB.DogCollection().AsQueryable().ToListAsync();
        Task delayTask = Task.Delay(3000); 

        Task completedTask = await Task.WhenAny(fetchTask, delayTask);

        if (completedTask == delayTask)
        {
       
            await DisplayAlert("Error", "Data fetching timed out", "OK");
            return new List<Models.Dog>(); 
        }
        else
        {
            return await fetchTask; 
        }
    }


    private async void GetAllDogsFromDb(object sender, EventArgs e)
    {
     
        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderBy(d => d.name).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));
    }

    private async void GetAllDogsSortedBySizeWeight(object sender, EventArgs e)
    {
        
        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderByDescending(d => d.max_weight_male).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));
       
    }
    private async void GetAllDogsSortedBySizeHeight(object sender, EventArgs e)
    {

        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderByDescending(d => d.max_height_male).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));

    }

    private async void GetAllDogsSortedByTrainability(object sender, EventArgs e)
    {

        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderByDescending(d => d.trainability).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));
    }

    private async  void GetAllDogsSortedByPlayfulness(object sender, EventArgs e)
    {
        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderByDescending(d => d.playfulness).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));
    }

    private async void GetAllDogsSortedByEnergyLevel(object sender, EventArgs e)
    {
        List<Models.Dog> dogInformation = await GetDogsFromDB();
        dogInformation = dogInformation.OrderByDescending(d => d.energy).ToList();
        await Navigation.PushAsync(new ShowAllDogsPage(dogInformation));
    }
}