using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseHealth : MonoBehaviour
{
    public Image healthImage; // UI hiển thị sprite máu
    public Sprite[] healthSprites; // Danh sách sprite tương ứng với lượng máu
    public int maxHealth = 6; // Số mức máu tối đa
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    // Khi Base bị quái tấn công
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    // Cập nhật UI hiển thị máu
    void UpdateHealthUI()
    {
        if (currentHealth < healthSprites.Length)
        {
            healthImage.sprite = healthSprites[currentHealth];
        }
    }

    // Xử lý khi Base bị quái chạm vào
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Nếu quái có tag là "Enemy"
        {
            TakeDamage(); // Gọi hàm trừ máu
            Destroy(other.gameObject); // Xóa quái khi chạm vào Base
        }
    }

    // Xử lý khi thua game
    void GameOver()
    {
        Debug.Log("Base bị phá hủy! Game Over!");
        SceneManager.LoadScene("GameOver");
    }
}
