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
using Windows.Gaming.Input;
using Windows.ApplicationModel;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Partida : Page
    {
        public MediaPlayer player;
        public MediaPlayer music;

        private readonly object myLock = new object();
        private List<Gamepad> myGamepads = new List<Gamepad>();
        private Gamepad mainGamepad;

        private GamepadReading reading, prereading;

        public DispatcherTimer GamePadTimer;
        public Partida()
        {
            this.InitializeComponent();
            player = new MediaPlayer();
            music = new MediaPlayer();
            //PlayMusic("I Think I Like You - Orchestrated.WAV");
            
            Gamepad.GamepadAdded += (object sender, Gamepad e) =>
            {
                {
                    lock (myLock)
                    {
                        bool gamepadInList = myGamepads.Contains(e);

                        if (!gamepadInList)
                        {
                            myGamepads.Add(e);
                            mainGamepad = myGamepads[0];
                        }
                    }
                }
            };
            Gamepad.GamepadRemoved += (object sender, Gamepad e) =>
            {
                lock (myLock)
                {
                    int indexRemoved = myGamepads.IndexOf(e);

                    if (indexRemoved > -1)
                    {
                        if (mainGamepad == myGamepads[indexRemoved])
                        {
                            mainGamepad = null;
                        }

                        myGamepads.RemoveAt(indexRemoved);
                    }
                }
            };
        }

        public async void PlayButtonSound(string filename)
        {
            Windows.Storage.StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(filename);
            player.AutoPlay = false;
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }

        public async void PlayMusic(string filename)
        {
            Windows.Storage.StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync(filename);
            music.AutoPlay = true;
            music.Source = MediaSource.CreateFromStorageFile(file);
            music.IsLoopingEnabled = true;
            music.Play();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If e.Parameter is a string, set the TextBlock's text with it.
            if (e?.Parameter is ImageSource[] image)
            {

                
                //MapaJugador1.Source = image[0];
                MapaJugador2.Source = image[0];
                ch1.Source = image[4];
                ch2.Source = image[5];
                ch3.Source = image[6];
                gn1.Source = image[1];
                gn2.Source = image[2];
                gn3.Source = image[3];

            }

            base.OnNavigatedTo(e);
            GamePadTimerSetup();
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




        private void O1_DragStarting(UIElement sender, DragStartingEventArgs args)
        {
            ContentControl Item = sender as ContentControl;
            string id = Item.Name;
            args.Data.SetText(id);
            args.Data.RequestedOperation = DataPackageOperation.Copy;
        }

        private void mapa1_DragOver(object sender, DragEventArgs e)
        {
            e.AcceptedOperation = DataPackageOperation.Copy;
        }

        private void Per1_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            var item = sender as ContentControl;
            string id = item.Name;
            ContentControl O = FindName(id) as ContentControl;
            if (e.Key == Windows.System.VirtualKey.Enter || e.Key == Windows.System.VirtualKey.Space)
            {
                string name = O.Parent.GetType().Name;
                
                if (name == "StackPanel")
                {
                    chStack.Children.Remove(O);
                    
                    mapa1.Children.Add(O);
                }

            }
           
        }



        //mando
        public void GamePadTimerSetup()
        {
            GamePadTimer = new DispatcherTimer();
            GamePadTimer.Tick += GamePadTimer_Tick;// dispatcherTimer_Tick;
            GamePadTimer.Interval = new TimeSpan(100000); //100000*10^-7s=1cs;
            GamePadTimer.Start();
        }
        void GamePadTimer_Tick(object sender, object e)
        { //Función de respuesta al Timer cada 0.01s
            if (mainGamepad != null)
            {
                LeeMando(); //Lee GamePAd   
                            //DetectaGestosMando(); //Detecta Gestos del Mando
                ZMMando(); //ZonaMuerta JoyStick y Triggers
                ActualizaIU(); //Aplica cambios en IU y VM
                FeedBack();               // FeedBack(); //Activa motores del Mando
            }
        }
        void LeeMando()
        {
            if (mainGamepad != null)
            {
                prereading = reading;
                reading = mainGamepad.GetCurrentReading();
            }
        }
        void ZMMando()
        {
            if (reading.RightThumbstickX < -0.1) reading.RightThumbstickX += 0.1;
            else if (reading.RightThumbstickX > 0.1) reading.RightThumbstickX -= 0.1;
            else reading.RightThumbstickX = 0;

            if (reading.RightThumbstickY < -0.1) reading.RightThumbstickY += 0.1;
            else if (reading.RightThumbstickY > 0.1) reading.RightThumbstickY -= 0.1;
            else reading.RightThumbstickY = 0;

        }

        void ActualizaIU()
        {
            //var item = sender as ContentControl;
            ContentControl O = FocusManager.GetFocusedElement() as ContentControl;
            string id = O.Name;
            if ((mainGamepad != null) & (O != null))
            {
                var OY = O.GetValue(Canvas.TopProperty);
                double Y = (double)OY;
                O.SetValue(Canvas.TopProperty, Y - 10.0 * reading.RightThumbstickY);

                var OX = O.GetValue(Canvas.LeftProperty);
                double X = (double)OX;
                O.SetValue(Canvas.LeftProperty, X + 10.0 * reading.RightThumbstickX);

               

            }
        }

        private async void mapa1_Drop(object sender, DragEventArgs e)
        {
            var Oname = await e.DataView.GetTextAsync();
            ContentControl O = FindName(Oname.ToString()) as ContentControl;
            chStack.Children.Remove(O);
            mapa1.Children.Remove(O);
            mapa1.Children.Add(O);

            Point pos = e.GetPosition(mapa1);
            O.SetValue(Canvas.TopProperty, pos.Y + 10.0);
            O.SetValue(Canvas.LeftProperty, pos.X + 10.0);
        }

        private void mapa1_DragStarting(UIElement sender, DragStartingEventArgs args)
        {

        }

        void FeedBack() { }
    }
}

