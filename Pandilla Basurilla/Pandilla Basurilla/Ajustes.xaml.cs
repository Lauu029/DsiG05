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
    public sealed partial class Ajustes : Page
    {
        public MediaPlayer player;

        public Ajustes()
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TryGoBack();
            PlayButtonSound("Exit.wav");
        }

        private void MiCuentaButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("ButtonSound.wav");
        }

        private void EstadisticasButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("ButtonSound.wav");
        }

        private void IdiomaButton_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("ButtonSound.wav");
        }
    }
}
