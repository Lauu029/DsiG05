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
        private ImageSource imgSrc;
        public PreparacionPartida()
        {
            this.InitializeComponent();
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
            Frame.Navigate(typeof(Partida),imgSrc);
        }

        private void Personajes_Click(object sender, RoutedEventArgs e)
        {
            MapsScreen.Visibility = Visibility.Collapsed;
            PersonajesScreen.Visibility = Visibility.Visible;
            SkinsScreen.Visibility = Visibility.Collapsed;
           
        }

        private void Skins_Click(object sender, RoutedEventArgs e)
        {
            MapsScreen.Visibility = Visibility.Collapsed;
            PersonajesScreen.Visibility = Visibility.Collapsed;
            SkinsScreen.Visibility = Visibility.Visible;
          
        }

        private void Mapas_Click(object sender, RoutedEventArgs e)
        {
            
            MapsScreen.Visibility = Visibility.Visible;
            PersonajesScreen.Visibility = Visibility.Collapsed;
            SkinsScreen.Visibility = Visibility.Collapsed;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa1.Source;
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa2.Source;
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa3.Source;
        }
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            imgSrc = Mapa4.Source;
        }
    }
}
