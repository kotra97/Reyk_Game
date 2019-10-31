using UnityEngine;

public class DoorsManagement : MonoBehaviour
{
    [SerializeField]
    private DoorBehaviour[] doors;
    public bool _isEntrance;
    void Start()
    {
        doors = transform.GetComponentsInChildren<DoorBehaviour>();
    }

    public bool areDoorsOpen()
    {
        if (doors[0].state == 2)
            return true;
        if (doors[0].state != 1)
            doors[0].state = doors[1].state = 1;
        return false;
    }
}
