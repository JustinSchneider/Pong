using UI.Menus;
using UnityEngine;

namespace Managers
{
    public class UIManager: MonoBehaviour
    {
        [SerializeField] private MainMenu MainMenu;
        [SerializeField] private Hud Hud;
        [SerializeField] private ControlsMenu ControlsMenu;
        [SerializeField] private OptionsMenu OptionsMenu;
        [SerializeField] private PauseMenu PauseMenu;
        
        public void UpdateScoreUi()
        {
            Hud.UpdateScores();
        }
    }
}