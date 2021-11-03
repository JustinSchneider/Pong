using UnityEngine;

namespace Constants
{
    public static class UIConstants
    {
        public static readonly Color32 BaseColor = Color.white;
        public static readonly Color32 HoverColor = new Color32(0xff, 0x00, 0x00, 0xff);
    }

    public enum Menu
    {
        Main,
        HUD,
        Pause,
        GameOver
    }
}