using UnityEngine;

public class SteamManager : MonoBehaviour
{
    [SerializeField] private RectTransform steamFill;   // inner rectangle
    [SerializeField] private RectTransform steamBackground; // outer rectangle

    public int CurrentSteam { get; private set; } = 50;
    public int MaxSteam { get; private set; } = 100;

    private float fullWidth;
    private float timer;

    private void Awake()
    {
        if (steamFill == null || steamBackground == null)
        {
            Debug.LogError("Assign both rectangles in the inspector.");
            return;
        }

        // Use the background width as the max
        fullWidth = steamBackground.rect.width;
        UpdateSteamBar();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f) // 1 second passed
        {
            timer = 0f;
            DecreaseSteam(1);
        }


        if (Input.GetMouseButton(0))
        {
            DecreaseSteam(20);
        }

    }

    public void DecreaseSteam(int amount)
    {
        CurrentSteam = Mathf.Max(CurrentSteam - amount, 0);
        UpdateSteamBar();
    }

    public void IncreaseSteam(int amount)
    {
        CurrentSteam = Mathf.Min(CurrentSteam + amount, MaxSteam);
        UpdateSteamBar();
    }

    private void UpdateSteamBar()
    {
        float ratio = (float)CurrentSteam / MaxSteam;
        steamFill.sizeDelta = new Vector2(fullWidth * ratio, steamFill.sizeDelta.y);
    }
}
