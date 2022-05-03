using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Globalization;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Idiomas : Page
    {
        public MediaPlayer player;

        public Idiomas()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
        }

        public async void PlayButtonSound(string filename)
        {
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(filename);
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ajustes));
            PlayButtonSound("Exit.wav");
        }

        private void IdiomasButton_Click(object sender, RoutedEventArgs e)
        {
            var hbIdioma = sender as Button;
            string lang = "es-ES";

            switch (hbIdioma.Name)
            {
                case "EspañolButton":
                    lang = "es-ES";
                    break;
                case "InglesButton":
                    lang = "en-US";
                    break;
                case "FrancesButton":
                    lang = "fr-FR";
                    break;
                case "AlemanButton":
                    lang = "de-DE";
                    break;
            }

            ApplicationLanguages.PrimaryLanguageOverride = lang;

            Frame.Navigate(this.GetType());
        }
    }
}
