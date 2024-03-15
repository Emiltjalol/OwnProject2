namespace OwnProject2
{
    public partial class MainPage : ContentPage
    {
   
        // Tyckte inte att jag hade något bra ställe att använda mig av singleton i mitt projekt så har därför valt att inte ha med det, tyckte inte det kändes logiskt att ha t.ex en inloggningsfunktion för denna app.
        // Försökte få till en quiz funktion där jag skickade ett anropp till chatgpt som skulle generera en fråga med 4 svarsalternativ men fick inte till det i tid.
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToSearch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Search());
        }

        private async void GoToSort(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.SortByCategory());

        }
       
    }

}
