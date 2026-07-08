using UnityEngine;

public class GateSystem : MonoBehaviour
{
    public enum GateType
    {
        Add,
        Multiply
    }

    public GateType gateType;
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player == null)
            return;

        switch (gateType)
        {
            case GateType.Add:
                player.SpawnSoldiers(value);
                break;

            case GateType.Multiply:
                int current = player.SoldierCount();
                player.SpawnSoldiers(current * (value - 1));
                break;
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(3f, 3f, 1f));
    }
}
