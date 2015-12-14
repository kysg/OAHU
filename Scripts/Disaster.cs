using UnityEngine;
using System.Collections;

public class Disaster : MonoBehaviour {

	public int type = -1;
	public Tile currentTile;
	public TileManager manager;

	public void Turn () {
		if (currentTile == null || type == -1)
			return;
		switch (type) {
			case 0:
				manager.cascade.OnThunder(currentTile);
				break;
			case 1:
				manager.cascade.OnEruption(currentTile);
				break;
			case 2:
				manager.cascade.OnFlood(currentTile);
				break;
			case 3:
				manager.cascade.OnQuake(currentTile);
				break;
		}
	}

	public void StartDisaster (Tile t) {
		currentTile = t;
		type = Random.Range(0, 4);

		MeshFilter filter = gameObject.AddComponent<MeshFilter> ();
		MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
		
		filter.mesh = Resource.disasterMesh; // This needs to be type dependent.
		renderer.material = Resource.disasterMaterial; // This needs to be type dependent.

		transform.position = new Vector3 (
				manager.objectFromTile[currentTile].transform.position.x,
				manager.objectFromTile[currentTile].transform.position.y+manager.worldScale.y, 
				manager.objectFromTile[currentTile].transform.position.z);
	}

}
