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
using Windows.ApplicationModel.DataTransfer;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Partida : Page
    {
        public MediaPlayer player;
        

        public Partida()
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
        private void Image_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }
        //private async void Image_DropAsync(object sender, DragEventArgs e)
        //{
        //    var id = await e.DataView.GetTextAsync();
        //    var number = int.Parse(id);
        //    Point PD = e.GetPosition(MiCanvas);
        //    MiDron.Source = ListaDrones[number].Img.Source;
        //    MiImagen.Source = ListaDrones[number].Img.Source;
        //    Point pos = e.GetPosition(mi_mapa);
        //    MiDron.Visibility = Visibility.Visible;
        //    Texto.Text = ListaDrones[number].Explicacion;
        //    Sel = int.Parse(id);

        //    ListaDrones[Sel].X = (int)pos.X;
        //    ListaDrones[Sel].Y = (int)pos.Y;
        //    ListaDrones[Sel].Transformacion.TranslateX = pos.X;
        //    ListaDrones[Sel].Transformacion.TranslateY = pos.Y;
        //    MiDronCC.RenderTransform = ListaDrones[Sel].Transformacion;
        //}
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If e.Parameter is a string, set the TextBlock's text with it.
            if (e?.Parameter is ImageSource [] image)
            {

                MapaJugador1.Source = image[0];
                MapaJugador2.Source = image[0];
                ch1.Source = image[4];
                ch2.Source = image[5];
                ch3.Source = image[6];
                gn1.Source = image[1];
                gn2.Source = image[2];
                gn3.Source = image[3];
                
            }

            base.OnNavigatedTo(e);
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
            PlayButtonSound("Exit.wav");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PlayButtonSound("ButtonSound.wav");
        }

        private async void MapaJugador1_Drop(object sender, DragEventArgs e)
        {
            var Oname = await e.DataView.GetTextAsync();
            Object O = FindName(Oname.ToString());
            chStack.Children.Remove(O as Image);
            mapa1.Children.Remove(O as Image);
            mapa1.Children.Add(O as Image);

            Point pos = e.GetPosition(mapa1);
            mapa1.Children[mapa1.Children.Count() - 1].SetValue(Canvas.TopProperty, pos.Y + 10.0);
            mapa1.Children[mapa1.Children.Count() - 1].SetValue(Canvas.LeftProperty, pos.X + 10.0);
        }
    }
}
