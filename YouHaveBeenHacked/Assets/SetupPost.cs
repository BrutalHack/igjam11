using UnityEngine;
using UnityEngine.UI;

public class SetupPost : MonoBehaviour
{
    public string Text;
    public Sprite AvatarSprite;
    public Sprite PostSprite;
    public Text TextComponent;
    public Image AvatarImage;
    public Image PostImage;
    public SetupComment CommentPrefab;
    [SerializeField] public string[] CommentTexts;
    [SerializeField] public Sprite[] CommentAvatarSprites;

    // Use this for initialization
    void Start()
    {
        TextComponent.text = Text;
        AvatarImage.sprite = AvatarSprite;
        if (PostSprite != null)
        {
            PostImage.gameObject.SetActive(true);
            PostImage.sprite = PostSprite;
        }
        for (int i = 0; i < CommentTexts.Length; i++)
        {
            var com = Instantiate(CommentPrefab);
            com.AvatarSprite = CommentAvatarSprites[i];
            com.Text = CommentTexts[i];
            com.transform.SetParent(transform, false);
        }
    }
}