using MongoDB.Bson;
using MongoDB.Driver;
using OwnProject2.DataMananger;

namespace OwnProject2.Views;

public partial class Search : ContentPage
{
    public Search()
    {
        InitializeComponent();
    }

    public async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void ClickedOnSearchApi(object sender, EventArgs e)
    {
        try
        {
            string searchQuery = Searchbar.Text;

            if (string.IsNullOrWhiteSpace(searchQuery))
            {
              
                await DisplayAlert("Error", "Input field can not be empty", "OK");
                return; 
            }
            if (int.TryParse(searchQuery, out int parsedValue))
            {
                await DisplayAlert("Error", "Input can not be a number", "OK");
                return;
            }

            List<Models.Dog> dogInformation = await DogApiDataManager.GetDogsInformation($"v1/dogs?name={searchQuery}");
            await Navigation.PushAsync(new DogInformationPage(dogInformation));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Something went wrong with the API call.", "OK");
        }
    }


    public async Task InsertDogToDatabase(Models.Dog newDog)
    {
        var dogCollection = Data.DB.DogCollection();
        await dogCollection.InsertOneAsync(newDog);
    }

    public async Task InsertDogToDatabaseIfNotExists(Models.Dog newDog)
    {
        var dogCollection = Data.DB.DogCollection();


        var existingDog = await dogCollection.Find(d => d.name == newDog.name).FirstOrDefaultAsync();

        if (existingDog == null)
        {
            await dogCollection.InsertOneAsync(newDog);
        }

    }

    public async void ClickedOnSearch(object sender, EventArgs e)
    {
        try { 
        string searchQuery = Searchbar.Text;
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                await DisplayAlert("Error", "Input field can not be empty", "OK");
                return;
            }
            
            if (int.TryParse(searchQuery, out int parsedValue))
            {
                await DisplayAlert("Error", "Input can not be a number", "OK");
                return;
            }
            List<Models.Dog> dogInformation = await SearchInDatabase(searchQuery);
            await Navigation.PushAsync(new DogInformationPage(dogInformation));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Something went wrong when trying to search the database.", "OK");
        }
    }

    public async Task<List<Models.Dog>> SearchInDatabase(string searchQuery)
    {
        var dogCollection = Data.DB.DogCollection();
        var filter = Builders<Models.Dog>.Filter.Regex("name", new BsonRegularExpression(searchQuery, "i"));

        var dogInformation = await dogCollection.Find(filter).ToListAsync();

        return dogInformation;
    }

    private async void SearchEntryOnTextChanged(object sender, TextChangedEventArgs e)
    {
        string searchText = e.NewTextValue;
        if (string.IsNullOrEmpty(searchText))
        {
            SearchSuggestionListView.IsVisible = false;
            return;
        }

        List<string> searchSuggestions = await GetSearchSuggestions(searchText);
        if (!searchSuggestions.Any())
        {
            searchSuggestions.Add("No results found");
        }
        SearchSuggestionListView.ItemsSource = searchSuggestions;
        SearchSuggestionListView.IsVisible = true;
    }

   private async void SearchSuggestionTapped(object sender, EventArgs e)
    {
        var tappedItem = (TextCell)sender;
        string selectedSuggestion = tappedItem.Text;
        
            List<Models.Dog> dogInformation = await SearchInDatabase(selectedSuggestion);
            await Navigation.PushAsync(new DogInformationPage(dogInformation));
            Searchbar.Text = selectedSuggestion;
            SearchSuggestionListView.IsVisible = false;                  
      
    }
    private async Task<List<string>> GetSearchSuggestions(string searchText)
    {
        var dogInformation = await SearchInDatabase(searchText);
        List<string> searchSuggestions = dogInformation.Select(dog => dog.name).Take(5).ToList();
        return searchSuggestions;
    }


    //-------------------------------------------------Användes första gången för att fylla min mongoDB databas genom att söka igenom hela api-ninjas hund API---------------------------------------------------------------------
    //-------------------------------------------------Anledningen till att jag ville fylla en databas var för att slippa göra API anropp varje gång om det inte behövs och för att lätt kunna kategorisera alla raser-------------
    //-------------------------------------------------Offset användes för att man bara kunde hämta 20 resultat per anropp och fanns inget sätt att läsa in allt direkt------------------------------------------------------------
    //public async Task AddDogsToDatabaseFromApi()
    //{
    //    int maxOffset = 200;
    //    string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    //    foreach (var letter in letters)
    //    {
    //        int offset = 0;
    //        while (offset < maxOffset)
    //        {
    //            string searchQuery = letter;
    //            List<Models.Dog> dogInformation = await DogApiDataManager.GetDogsInformation($"v1/dogs?name={searchQuery}&offset={offset}");

    //            foreach (var dog in dogInformation)
    //            {
    //                await InsertDogToDatabaseIfNotExists(dog);
    //            }

    //            offset += 20;


    //            await Task.Delay(5000);
    //        }
    //    }
    //}



}






