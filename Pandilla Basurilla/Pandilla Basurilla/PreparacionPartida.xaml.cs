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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PreparacionPartida : Page
    {
        public MediaPlayer player;
        private ImageSource imgSrc;

        public PreparacionPartida()
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
            TryGoBack();
            PlayButtonSound("Exit.wav");
        }

        // App.xaml.cs
        //
        // Add this method to the App class.
        public static bool TryGoBack()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                return true;
            }
            return false;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Partida),imgSrc);
            PlayButtonSound("Jugar.mp3");
        }

        private void Personajes_Click(object sender, RoutedEventArgs e)
        {
            MapsScreen.Visibility = Visibility.Collapsed;
            PersonajesScreen.Visibility = Visibility.Visible;
            SkinsScreen.Visibility = Visibility.Collapsed;
            PlayButtonSound("ButtonSound.wav");
        }

        private void Skins_Click(object sender, RoutedEventArgs e)
        {
            MapsScreen.Visibility = Visibility.Collapsed;
            PersonajesScreen.Visibility = Visibility.Collapsed;
            SkinsScreen.Visibility = Visibility.Visible;
            PlayButtonSound("ButtonSound.wav");
        }

        private void Mapas_Click(object sender, RoutedEventArgs e)
        {
            
            MapsScreen.Visibility = Visibility.Visible;
            PersonajesScreen.Visibility = Visibility.Collapsed;
            SkinsScreen.Visibility = Visibility.Collapsed;
            PlayButtonSound("ButtonSound.wav");
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa1.Source;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa2.Source;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa3.Source;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            imgSrc = Mapa4.Source;
        }

        private void Seleccion_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
        }

    }
}
