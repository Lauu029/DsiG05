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
        public ImageSource imgSrc;
        bool g1 = false, g2 = false, g3 = false;
        bool cr1 = false, cr2 = false, cr3 = false;
        ImageSource[] sources = new ImageSource[7];
        //Controla que el array esté lleno antes de pasar a la partida
        int fullsource = 0;
        //controla si se ha elegido mapa
        bool map = false;
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
            sources[0] = imgSrc;
            Frame.Navigate(typeof(Partida), sources);
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
            map = true;
            if (fullsource >= 6) PlayButton.IsEnabled = true;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa2.Source;
            map = true;
            if (fullsource >= 6) PlayButton.IsEnabled = true;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {

            imgSrc = Mapa3.Source;
            map = true;
            if ( fullsource >= 6) PlayButton.IsEnabled = true;
            PlayButtonSound("Seleccion.wav");
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {

           
            imgSrc = Mapa4.Source;
            map = true;
            if (fullsource >= 6) PlayButton.IsEnabled = true;
            PlayButtonSound("Seleccion.wav");
        }

        private void Seleccion1_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I1.Source);
        }
        private void Seleccion2_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I2.Source);
        }
        private void Seleccion3_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I3.Source);
        }
        private void Seleccion4_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I4.Source);
        }
        private void Seleccion5_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I5.Source);
        }
        private void Seleccion6_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I6.Source);
        }
        private void Seleccion7_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I7.Source);
        }
        private void Seleccion8_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I8.Source);
        }
        private void Seleccion9_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImage(I9.Source);
        }
        private void Seleccion_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
        }
        private void changeImage(ImageSource src)
        {
            if (!g1)
            {
                Gun1.Source = src;
                sources[1] = src;
                g1 = true;
                fullsource++;
            }
            else if (!g2)
            {
                Gun2.Source = src;
                sources[2] = src;
                g2 = true;
                fullsource++;
            }
            else if (!g3)
            {
                Gun3.Source = src;
                sources[3] = src;
                g3 = true;
                fullsource++;
            }
            if (map && fullsource >= 6) PlayButton.IsEnabled = true;
        }
        private void Seleccionc1_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c1.Source);
        }
        private void Seleccionc2_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c2.Source);
        }
        private void Seleccionc3_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c3.Source);
        }
        private void Seleccionc4_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c4.Source);
        }
        private void Seleccionc5_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c5.Source);
        }
        private void Seleccionc6_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c6.Source);
        }
        private void Seleccionc7_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c7.Source);
        }
        private void Seleccionc8_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c8.Source);
        }
        private void Seleccionc9_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("Seleccion.wav");
            changeImageChar(c9.Source);
        }
        private void changeImageChar(ImageSource src)
        {
            if (!cr1)
            {
                Ch1.Source = src;
                sources[4] = src;
                cr1 = true;
                fullsource++;
            }
            else if (!cr2)
            {
                Ch2.Source = src;
                sources[5] = src;
                cr2 = true;
                fullsource++;
            }
            else if (!cr3)
            {
                Ch3.Source = src;
                sources[6] = src;
                cr3 = true;
                fullsource++;
            }
            if (map && fullsource >= 6) PlayButton.IsEnabled = true;
        }
    }
}
