using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Playback;
using Windows.Media.Core;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MediaPlayer player;

        public MainPage()
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

        private void Misiones_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MenuMisiones));
            PlayButtonSound("ButtonSound.wav");
        }

        private void PreparacionPartida_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PreparacionPartida));
            PlayButtonSound("ButtonSound.wav");
        }

        // Lleva a la página de elección de modos de juego
        private void JugarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ModosdeJuego));
            PlayButtonSound("ButtonSound.wav");
        }

        private void TiendaButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("ButtonSound.wav");
        }

        private void ButtonAjustes_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ajustes));
            PlayButtonSound("ButtonSound.wav");
        }

        private void Salida_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Exit.wav");
        }
    }
}
