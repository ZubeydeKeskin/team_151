using UnityEngine;
using UnityEngine.SceneManagement;
public class Keys : MonoBehaviour
{
    public static bool key1, key2, key3;
    public AudioClip keyCollectAudio;
    static void collect_key1()
    {
        key1 = true;
    }

    static void collect_key2()
    {
        key2 = true;
    }
    static void collect_key3()
    {
        key3 = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            collect_key1();
        } else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            collect_key2();
        }else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            collect_key3();
        }
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(keyCollectAudio, gameObject.transform.position);
    }
}