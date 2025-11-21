using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject[] hearts;     // Tes 3 hearts dans l’inspector
    public float invincibilityTime = 1f;

    private int currentHearts;
    private bool isInvincible = false;

    void Start()
    {
        currentHearts = hearts.Length;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isInvincible && collision.collider.CompareTag("enemy"))
        {
            LoseHeart();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!isInvincible && collision.collider.CompareTag("enemy"))
        {
            LoseHeart();
        }
    }


    void LoseHeart()
    {
        if (currentHearts <= 0) return;

        currentHearts--;
        hearts[currentHearts].SetActive(false);

        StartCoroutine(Invincibility());
    }

    System.Collections.IEnumerator Invincibility()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
