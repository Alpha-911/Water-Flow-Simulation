using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    [SerializeField] GameObject tank_1_Water;
    [SerializeField] GameObject tank_2_Water;
    [SerializeField] GameObject pipe_Water;

    public Transform tank_1_Water_Transform;
    public Transform tank_2_Water_Transform;
    public Transform pipe_Water_Transform;
    public float pipe_Capacity = 2.88f;
    [SerializeField] float flowSpeed = 1.0f;
    private float totalWater;
    void Start() {
        tank_1_Water_Transform = tank_1_Water.transform;
        tank_2_Water_Transform = tank_2_Water.transform;
        pipe_Water_Transform = pipe_Water.transform;

        totalWater = tank_1_Water_Transform.localScale.y + tank_2_Water_Transform.localScale.y + pipe_Water_Transform.localScale.y;
    }

    void Update() {
        float tank_1_Level = tank_1_Water_Transform.localScale.y;
        float tank_2_Level = tank_2_Water_Transform.localScale.y;
        float pipe_Water_Level = pipe_Water_Transform.localScale.y;

        if (Mathf.Abs(tank_1_Level - tank_2_Level) > 0.01f) {
            float flow = flowSpeed * Time.deltaTime;
            if (tank_1_Level > tank_2_Level) {
                tank_1_Level -= flow;

                if (pipe_Water_Level < pipe_Capacity) {
                    pipe_Water_Level += flow*30;
                } else {
                    tank_2_Level += flow;
                }
            }
            tank_1_Water_Transform.localScale = new Vector3(tank_1_Water_Transform.localScale.x, Mathf.Clamp(tank_1_Level, 0, totalWater), tank_1_Water_Transform.localScale.z);
            tank_2_Water_Transform.localScale = new Vector3(tank_2_Water_Transform.localScale.x, Mathf.Clamp(tank_2_Level, 0, totalWater), tank_2_Water_Transform.localScale.z);
            pipe_Water_Transform.localScale = new Vector3(pipe_Water_Transform.localScale.x, Mathf.Clamp(pipe_Water_Level, 0, pipe_Capacity), pipe_Water_Transform.localScale.z);
        }
    }
}
