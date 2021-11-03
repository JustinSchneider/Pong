using Managers;
using Sources.BootSequence;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Controllers
{
    public class CoreController: MonoBehaviourSingleton<CoreController>
    {
        public GameManager GameManager;
        public UIManager UiManager;
        
        void Awake()
        {
            base.Awake();
            
        }

    }
}