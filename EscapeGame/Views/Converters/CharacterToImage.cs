﻿using EscapeGame.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace EscapeGame.Views.Converters
{
    public static class CharacterToImage
    {
        public static BitmapImage Convert(Character character, CharacterAction action, bool first = true)
        {
            string key = "img";

            switch (character)
            {
                case Character.Robs: key += "Robs"; break;
                case Character.Vati: key += "Vati"; break;
                case Character.Tabs: key += "Tabs"; break;
                case Character.Lule: key += "Lule"; break;
                case Character.Mutti: key += "Mutti"; break;
            }

            switch (action)
            {
                case CharacterAction.Talking: 
                    key += "Talking" + (first ? "1" : "2"); break;
            }

            BitmapImage resource = (BitmapImage)Application.Current.FindResource(key);

            return resource ?? new BitmapImage();
        }

    }
}
