using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScript : MonoBehaviour
{
    //public TextMeshProUGUI endScore;
    public Text endScore;
    void OnEnable()
    {
        endScore.text = "SKORUNUZ: " + Score.totalScore;
    }

    public void tekrar() // Tekrar oynama butonu için gerekli olan sıfırlamalar.
    { 
        Score.totalScore = 0;  // TotalScore'u sıfırla
        Score.firstZone = 0;   // İlk bölümün skorunu sıfırla
        Score.secondZone = 0;  // İkinci bölümün skorunu sıfırla
        Score.thirdZone = 0;   // Üçüncü bölümün skorunı sıfırla
        Keys.key1 = Keys.key2 = Keys.key3 = false; // Verilen anahtaları sıfırla
        SceneManager.LoadScene(0); //Karakteri ana ekrana gönder
    }
}
