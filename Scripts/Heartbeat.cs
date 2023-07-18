using UnityEngine;
using UnityEngine.UI;

public class Heartbeat : MonoBehaviour
{
    public Transform playerTransform;
    public Transform enemyTransform;
    public AudioSource heartbeatSound;
    public float maxDistance = 10f;
    public float minVolume = 0.2f;
    public float maxVolume = 1f;
    public float minDistance = 0.2f;

    private float initialVolume;
    private bool isPlaying;

    [SerializeField] private Image enemyImage = null;

    void Start()
    {
        initialVolume = heartbeatSound.volume;
        isPlaying = false;
    }

    void Update()
    {
        float distance = Vector3.Distance(enemyTransform.position, playerTransform.position);

        if (distance <= maxDistance)
        {
            if (!isPlaying)
            {
                heartbeatSound.Play();
                isPlaying = true;
            }

            Color splatterAlpha = enemyImage.color;
            splatterAlpha.a = Mathf.Lerp(minDistance, maxVolume, 1f - distance / maxDistance);
            enemyImage.color = splatterAlpha;

            float volume = Mathf.Lerp(minVolume, maxVolume, 1f - distance / maxDistance);
            heartbeatSound.volume = initialVolume * volume;
        }
        else
        {
            if (isPlaying)
            {
                heartbeatSound.Stop();
                isPlaying = false;
            }

            Color splatterAlpha = enemyImage.color;
            splatterAlpha.a = 0f;
            enemyImage.color = splatterAlpha;
        }
    }
}
