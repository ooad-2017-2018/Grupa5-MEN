using Windows.UI.Xaml.Media;

namespace eRouting2
{
    public interface IKorisnik
    {
        

        void DodajSliku(ImageSource s);
        void UrediInformacije(string ime, string prezime, string email, string username);
    }
}