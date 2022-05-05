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
using Windows.ApplicationModel;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MiCuenta : Page
    {
        public string UserName { get; set; }
        public MediaPlayer player;
        public MiCuenta()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
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

        public async void PlayButtonSound(string filename)
        {
            Windows.Storage.StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(filename);
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Windows.UI.Popups.MessageDialog($"Hola {UserName}! Ha iniciado sesión correctamente.");
            dlg.ShowAsync();
        }
    }
}
