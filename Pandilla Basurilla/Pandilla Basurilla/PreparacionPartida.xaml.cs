﻿using System;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Pandilla_Basurilla
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PreparacionPartida : Page
    {
        public bool mapsVisible, skinsVisible, personajesVisible;
        public PreparacionPartida()
        {
            this.InitializeComponent();
            personajesVisible = false;
            skinsVisible = false;
            mapsVisible = false;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            TryGoBack();
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
            Frame.Navigate(typeof(Partida));
        }

        private void Personajes_Click(object sender, RoutedEventArgs e)
        {
            if (!personajesVisible)
            {
                personajesVisible = true;
                skinsVisible = false;
                mapsVisible = false;
            }
        }

        private void Skins_Click(object sender, RoutedEventArgs e)
        {
            if (!skinsVisible)
            {
                personajesVisible = false;
                skinsVisible = true;
                mapsVisible = false;
            }
        }

        private void Mapas_Click(object sender, RoutedEventArgs e)
        {
            if (!mapsVisible)
            {
                personajesVisible = false;
                skinsVisible = false;
                mapsVisible = true;
            }
        }
    }
}
