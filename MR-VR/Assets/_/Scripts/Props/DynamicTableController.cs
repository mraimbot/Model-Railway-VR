using System.Collections.Generic;
using UnityEngine;

public class DynamicTableController : MonoBehaviour {
	[Header("Table")]
	[SerializeField]
	[Tooltip("Main transform of table. If empty, transform of assigned game object will be used.")]
	private Transform main;
	
	[SerializeField]
	[Tooltip("The plate of the table.")]
	private Transform plate;
	
	[SerializeField]
	[Tooltip("The legs of the table.")]
	private List<Transform> legs;
	
	[SerializeField]
	[Tooltip("Scale of the legs for 1m.")]
	private float legDimension = 0.33333f;

	private void Start() {
		if (!main) {
			main = transform;
		}

		if (!plate) {
			Debug.LogError("The table has no plate.");
		}

		if (legs.Count == 0) {
			Debug.LogError("The table has no legs.");
		}

		if (legDimension <= 0.0f) {
			Debug.LogError("legDimension must be positive.");
		}
	}

	/// <summary>
	/// Sets the tables leg height in meters.
	/// </summary>
	/// <param name="height">The new size in meters.</param>
	public void SetHeight(float height) {
		if (height <= 0.0f) {
			Debug.LogWarning("Size must be positive.");
			return;
		}
		
		var scale = legs[0].localScale;
		var newScaleY = height * legDimension;
		foreach (var leg in legs) {
			leg.localScale = new Vector3(scale.x, newScaleY , scale.z);
		}
		main.Translate(new Vector3(0.0f, scale.y - newScaleY, 0.0f), Space.Self);
	}
}
