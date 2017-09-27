using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class FlappyObstaclesSpawner : MonoBehaviour {

	public GameObject obstaclePrefab;
    private Transform cameraTransform;


    [SerializeField] [Range(4, 8)] private float distBlocks = 4f;
    [SerializeField] private float UpperBorder = 10f;
    [SerializeField] private float LowerBorder = -10f;
    [SerializeField] private float MinGapHeight = 3f;
    [SerializeField] private float MaxGapHeight = 6f;
    [SerializeField] private float GapDifference = 3f;
    private Vector3 offset;
	private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start() {
        cameraTransform = Camera.main.transform;
        offset = transform.position - cameraTransform.position;
    }
    private void Update() {
        if (spawnedObstacles.Count == 0) {
            Spawn(transform.position.x, Random.Range(-1f, 1f), Random.Range(MinGapHeight,MaxGapHeight));
        } else {
            Transform lastPosition = spawnedObstacles[spawnedObstacles.Count - 1].transform;
            float tempX = lastPosition.position.x + distBlocks;
            float cameraBorder = cameraTransform.position.x + offset.x;
            float tempY;
            do {
                tempY = lastPosition.position.y + Random.Range(-GapDifference,GapDifference);
            } while (tempY >= UpperBorder || tempY <= LowerBorder);
            if (tempX < cameraBorder) Spawn(tempX, tempY, Random.Range(MinGapHeight,MaxGapHeight));
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
