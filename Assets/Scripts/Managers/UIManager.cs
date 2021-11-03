using System.Collections.Generic;
using DG.Tweening;
using UI.Menus;
using UnityEngine;
using Menu = Constants.Menu;

namespace Managers
{
    public class UIManager: MonoBehaviour
    {
        [SerializeField] private CanvasGroup screenFade;
        
        [SerializeField] private MainMenu mainMenu;
        [SerializeField] private Hud hud;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private GameOverMenu gameOverMenu;

        private List<Transform> menus = new List<Transform>();

        private void Awake()
        {
            menus.Add(mainMenu.transform);
            menus.Add(hud.transform);
            menus.Add(pauseMenu.transform);
            menus.Add(gameOverMenu.transform);

            screenFade.alpha = 1f;
            screenFade.gameObject.SetActive(true);
            screenFade.DOFade(0f, 1f).OnComplete(() =>
            {
                screenFade.gameObject.SetActive(false);
                ShowMenu(Menu.Main);
            });
        }

        public void ShowMenu(Menu menuToShow, bool doFadeOut = false)
        {
            foreach (Transform menu in menus)
            {
                if (menu.gameObject.activeSelf)
                {
                    if (doFadeOut) menu.GetComponent<CanvasGroup>().DOFade(0f, 1f).SetUpdate(true);
                    menu.gameObject.SetActive(false);
                }
            }

            GameObject menuObj;
            CanvasGroup menuCanvasGroup;
            
            switch (menuToShow)
            {
                case Menu.Main:
                    menuObj = mainMenu.gameObject;
                    break;
                case Menu.Pause:
                    menuObj = pauseMenu.gameObject;
                    break;
                case Menu.HUD:
                    menuObj = hud.gameObject;
                    break;
                case Menu.GameOver:
                    menuObj = gameOverMenu.gameObject;
                    break;
                default:
                    return;
            }

            menuCanvasGroup = menuObj.GetComponent<CanvasGroup>();
            menuCanvasGroup.alpha = 0;
            menuObj.gameObject.SetActive(true);
            menuCanvasGroup.DOFade(1f, 1f).SetUpdate(true);
        }

        public void UpdateScoreUi(int playerId)
        {
            hud.UpdateScore(playerId);
        }

        public void ShowWin(int playerId)
        {
            gameOverMenu.ShowWin(playerId);
            ShowMenu(Menu.GameOver, true);
        }

        public void StartCountdown()
        {
            StartCoroutine(hud.Countdown());
        }
    }
}