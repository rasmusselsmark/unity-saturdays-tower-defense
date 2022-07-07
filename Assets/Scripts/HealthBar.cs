using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform bar;
    
    public void SetHealth(float health)
    {
        bar.localScale = new Vector3((health / 100) * 150, 20, 1);
        bar.transform.localPosition = new Vector3(health * 0.0075f, 0, 0);
    }
}
