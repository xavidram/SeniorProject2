// Navigation2D Script (c) noobtuts.com
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class NavMeshAgent2D : MonoBehaviour {
    // NavMeshAgent properties
    public float radius = 0.5f;
    public float speed = 3.5f;
    public float angularSpeed = 120;
    public float acceleration = 8;
    public float stoppingDistance = 0;
    public bool autoBraking = false;

    // the projection
    NavMeshAgent agent;

    // monobehaviour ///////////////////////////////////////////////////////////
    void Awake() {
        // create projection
        var go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        go.name = "NAVIGATION2D_AGENT";
        go.transform.position = NavMeshUtils2D.ProjectTo3D(transform.position); // todo height 0.5 again?
        agent = go.AddComponent<NavMeshAgent>();
        // disable navmesh and collider (no collider for now...)
        Destroy(agent.GetComponent<Collider>());
        Destroy(agent.GetComponent<MeshRenderer>());
    }

    void FixedUpdate() {
        // copy properties to projection all the time
        // (in case they are modified after creating it)
        agent.radius = radius;
        agent.speed = speed;
        agent.angularSpeed = angularSpeed;
        agent.acceleration = acceleration;
        agent.stoppingDistance = stoppingDistance;
        agent.autoBraking = autoBraking;
        
        // copy projection's position
        var rb = GetComponent<Rigidbody2D>();
        if (rb != null && !rb.isKinematic)
            rb.MovePosition(NavMeshUtils2D.ProjectTo2D(agent.transform.position));
        else
            transform.position = NavMeshUtils2D.ProjectTo2D(agent.transform.position);
        
        // stuck detection: get max distance first (best with collider)
        float maxdist = 2; // default if no collider
        if (GetComponent<Collider2D>()) {
            var bounds = GetComponent<Collider2D>().bounds;
            maxdist = Mathf.Max(bounds.extents.x, bounds.extents.y) * 2;
        }
        
        // stuck detection: reset if distance > max distance
        float dist = Vector2.Distance(transform.position, NavMeshUtils2D.ProjectTo2D(agent.transform.position));
        if (dist > maxdist) {
            // stop agent movement, reset it to current position
            agent.ResetPath();
            agent.transform.position = NavMeshUtils2D.ProjectTo3D(transform.position);
            Debug.Log("stopped agent because of collision in 2D plane");
        }
    }

    void OnDestroy() {
        if (agent != null) Destroy(agent.gameObject);
    }

    void OnEnable() {
        if (agent != null) agent.enabled = true;
    }

    void OnDisable() {
        if (agent != null) agent.enabled = false;
    } 

    // draw radius gizmo (gizmos.matrix for correct rotation)
    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.localRotation, transform.localScale);
        Gizmos.DrawWireSphere(Vector3.zero, radius);
    }

    // NavMeshAgent proxies ////////////////////////////////////////////////////
    public bool CalculatePath(Vector2 targetPosition, NavMeshPath2D path) {
        var temp = new NavMeshPath();
        if (agent.CalculatePath(NavMeshUtils2D.ProjectTo3D(targetPosition), temp)) {
            // convert 3D to 2D
            path.corners = temp.corners.Select(NavMeshUtils2D.ProjectTo2D).ToArray();
            path.status = temp.status;
            return true;
        }
        return false;
    }

    public Vector2 destination {
        get { return NavMeshUtils2D.ProjectTo2D(agent.destination); }
        set { agent.destination = NavMeshUtils2D.ProjectTo3D(value); }
    }

    public bool hasPath {
        get { return agent.hasPath; }
    }

    public bool isOnNavMesh {
        get { return agent.isOnNavMesh; }
    }

    public bool isPathStale {
        get { return agent.isPathStale; }
    }

    public bool pathPending {
        get { return agent.pathPending; }
    }

    public NavMeshPathStatus pathStatus {
        get { return agent.pathStatus; }
    }
    
    public float remainingDistance {
        get { return agent.remainingDistance; }
    }

    public void ResetPath() {
        agent.ResetPath();
    }

    public void Resume() {
        agent.Resume();
    }

    public void SetDestination(Vector2 v) {
        destination = v;
    }

    public void Stop() {
        agent.Stop();
    }
    
    public Vector2 velocity {
        get { return NavMeshUtils2D.ProjectTo2D(agent.velocity); }
    }

    public void Warp(Vector2 v) {
        // try to warp, set this agent's position immediately if it worked, so
        // that Update doesn't cause issues when trying to move the rigidbody to
        // a far away position etc.
        if (agent.Warp(NavMeshUtils2D.ProjectTo3D(v)))
            transform.position = v;
    }
}
