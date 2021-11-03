using Managers;
using Sources.BootSequence;

namespace Controllers
{
    public class CoreController: MonoBehaviourSingleton<CoreController>
    {
        public GameManager GameManager;
        public UIManager UiManager;
        public SoundManager SoundManager;
    }
}