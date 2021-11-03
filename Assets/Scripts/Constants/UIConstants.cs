using System.Collections;
using System.Collections.Generic;
using Classes;
using UnityEngine;

namespace Constants
{
    public static class UIConstants
    {
        public static readonly Dictionary<Menu, MenuConfig> MenuAddresses = new Dictionary<Menu, MenuConfig>
        {
            {
                Menu.Main,
                new MenuConfig("", true)
            }
        };
    }

    public enum Menu
    {
        Main,
        HUD,
        Pause,
        Controls,
        Options
    }
}