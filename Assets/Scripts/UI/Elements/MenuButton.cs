using Constants;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.ProceduralImage;
using Button = UnityEngine.UI.Button;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button btn;
    private ProceduralImage img;
    private TMP_Text txt;
    [SerializeField] private AudioClip hover;
    [SerializeField] private AudioClip click;

    private void Awake()
    {
        btn = GetComponent<Button>();
        img = GetComponent<ProceduralImage>();
        txt = GetComponentInChildren<TMP_Text>();
        btn.onClick.AddListener(() =>
        {
            CoreController.Instance.SoundManager.PlaySoundEffect(click);
        });
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        img.color = UIConstants.HoverColor;
        txt.color = UIConstants.HoverColor;
        CoreController.Instance.SoundManager.PlaySoundEffect(hover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.color = UIConstants.BaseColor;
        txt.color = UIConstants.BaseColor;
    }
}
