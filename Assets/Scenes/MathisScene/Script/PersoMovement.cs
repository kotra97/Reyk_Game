using UnityEngine;

public class PersoMovement : MonoBehaviour
{
    [SerializeField]
    private Transform[] Waypoints;
    private DoorsManagement[] doors;
    private GameLoopManager _manager;
    public int waypointWaitEntrance;
    public int waypointWaitExit;
    public int waypointWaitResponse; // set a zero quand nous donnons une réponse pour le contrat
    public int current = 0;
    private CarryBehaviour _carryVisitor;
    public float speed = 25;
    private int indexEntrance, indexExit;
    public bool test = false;
    void Start()
    {
        Transform[] toCopy = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<WaypointList>().listWaypoint;

        Waypoints = new Transform[toCopy.Length];
        System.Array.Copy(toCopy, 0, Waypoints, 0, toCopy.Length);

        _carryVisitor = transform.GetChild(0).GetComponent<CarryBehaviour>();
        _manager = GameObject.FindObjectOfType<GameLoopManager>();

        doors = GameObject.FindObjectsOfType<DoorsManagement>();
        if (doors[0]._isEntrance) { indexEntrance = 0; indexExit = 1; }
        else { indexExit = 0; indexEntrance = 1; }
    }

    public void receiveContract()
    {
        waypointWaitResponse = 0;
    }

    public bool bribeAsk()
    {
        GameObject[] moneys;

        moneys = GameObject.FindGameObjectsWithTag("Money");
        waypointWaitResponse = 0;
        if (Random.value > 0.5)
        {
            foreach (var money in moneys)
                money.GetComponent<MoneyBehaviour>().fixPositionObject(false);
            return true;
        }
        foreach (var money in moneys)
            money.GetComponent<MoneyBehaviour>()._canBePick = true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == Waypoints[current].position)
        {
            current++;
            if (current == Waypoints.Length)
                _manager.visitorLeave();
        }
        if (waypointWaitEntrance == current)
        {
            if (doors[indexEntrance].areDoorsOpen())
                waypointWaitEntrance = 0;
        }
        else if (waypointWaitResponse == current)
            _carryVisitor.sendContract();
        else if (waypointWaitExit == current)
        {
            if (doors[indexExit].areDoorsOpen())
                waypointWaitExit = 0;
        }
        else
        {
            if (current != Waypoints.Length && test == false)
                transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].position, Time.deltaTime * speed);
        }
    }
}
