using UnityEngine;
using UnityEngine.UI;

public class SetupComment : MonoBehaviour
{
    public Sprite AvatarSprite;
    public string Text;
    public Text TextComponent;
    public Image AvatarImage;

    void Start()
    {
        TextComponent.text = Text;
        AvatarImage.sprite = AvatarSprite;
    }
}