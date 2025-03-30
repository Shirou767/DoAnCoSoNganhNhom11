using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    public Image[] abilityIcons; // Mảng chứa các icon kỹ năng
    public float cooldownTime = 2f; // Thời gian hồi chiêu

    void Start()
    {
        ResetCooldowns();
    }

    public void UseAbility(int index)
    {
        if (index < 0 || index >= abilityIcons.Length) return;

        abilityIcons[index].color = new Color(1, 1, 1, 0.5f); // Làm mờ icon khi dùng
        Invoke(nameof(ResetCooldowns), cooldownTime); // Gọi hàm reset sau cooldown
    }

    void ResetCooldowns()
    {
        foreach (Image icon in abilityIcons)
        {
            icon.color = new Color(1, 1, 1, 1); // Khôi phục độ sáng icon
        }
    }
}
