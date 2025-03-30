using UnityEngine;

public class AbilityBarSprite : MonoBehaviour
{
    public SpriteRenderer[] skillIcons;
    public float cooldownTime = 2f;

    void Start()
    {
        ResetCooldowns();
    }

    public void UseAbility(int index)
    {
        if (index < 0 || index >= skillIcons.Length) return;

        skillIcons[index].color = new Color(1, 1, 1, 0.5f); // Làm mờ khi dùng
        Invoke(nameof(ResetCooldowns), cooldownTime);
    }

    void ResetCooldowns()
    {
        foreach (SpriteRenderer icon in skillIcons)
        {
            icon.color = new Color(1, 1, 1, 1); // Phục hồi icon
        }
    }
}
