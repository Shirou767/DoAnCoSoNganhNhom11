using UnityEngine;
using UnityEngine.UI;

public class BaseSystem : MonoBehaviour
{
    public int maxHealth = 6; // Tổng số lần nhận sát thương (6 nửa máu = 3 tim)
    private int currentHealth;
    
    public Image healthUI; // Ảnh thanh máu
    public Sprite[] healthSprites; // Danh sách ảnh hiển thị máu
    public GameObject gameOverUI; // UI Game Over

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) // Khi quái chạm vào nhà chính
        {
            TakeDamage(1); // Mỗi quái trừ nửa tim
            Destroy(other.gameObject); // Xóa quái sau khi gây sát thương
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void UpdateHealthUI()
    {
        int spriteIndex = Mathf.Clamp(currentHealth, 0, healthSprites.Length - 1);
        healthUI.sprite = healthSprites[spriteIndex];
    }

    void GameOver()
    {
        Debug.Log("🏴 Game Over! Nhà Chính Đã Bị Phá!");
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
