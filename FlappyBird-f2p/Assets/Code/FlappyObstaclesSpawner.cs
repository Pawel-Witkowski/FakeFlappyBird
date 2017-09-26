using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class FlappyObstaclesSpawner : MonoBehaviour {

	public GameObject obstaclePrefab;
    public Transform camera;

    [SerializeField] [Range(1, 10)] private float distBlocks = 3f;
    Vector3 offset;
	List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start() {
        offset = transform.position - camera.position;
        Debug.Log(offset);
    }
    private void Update() {
        if (spawnedObstacles.Count == 0) {
            Spawn(transform.position.x, Random.Range(-1f, 1f), Random.Range(4f,8f));
        } else {
            Transform lastPosition = spawnedObstacles[spawnedObstacles.Count - 1].transform;
            float tempX = lastPosition.position.x + distBlocks;
            float cameraBorder = camera.position.x + offset.x;
            float tempY = lastPosition.position.y + Random.Range(-1f, 1f);
            if (tempX < cameraBorder) Spawn(tempX, tempY, Random.Range(4f, 8f));
        }
    }
    void Spawn( float x, float y, float gapHeight ) {
		GameObject spawned = GameObject.Instantiate( obstaclePrefab );
        spawned.transform.parent = transform;
		spawned.transform.position = new Vector3( x, y, 0 );
		spawnedObstacles.Add( spawned );

        Transform bottomTransform = spawned.transform.Find( "Bottom" );
        Transform topTransform = spawned.transform.Find( "Top" );
        float bottomY = -gapHeight/2;
        float topY = +gapHeight/2;
        bottomTransform.localPosition = Vector3.up * bottomY;
        topTransform.localPosition = Vector3.up * topY;
        Vector3 PointTriggerDimensions = new Vector3(1f, gapHeight, 1f);
        spawned.GetComponent<BoxCollider>().size = PointTriggerDimensions;


    }

}
