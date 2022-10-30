using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Changes the material for a given mesh renderer dynamically.
/// </summary>
public class MaterialSetter : MonoBehaviour {
	[SerializeField]
	[Tooltip("The mesh renderer which gets the material set on.")]
	private MeshRenderer meshRenderer;
	
	[SerializeField]
	[Tooltip("Available materials to set.")]
	private List<Material> materials;

	[SerializeField]
	[Tooltip("The material the object gets at start. If empty, the material does not change.")]
	private Material startMaterial;

	private void Start() {
		if (!meshRenderer) {
			Debug.LogError("Mesh Renderer not set.");
			return;
		}

		if (materials.Count == 0) {
			Debug.LogWarning("No materials set.");
		}

		if (startMaterial) {
			meshRenderer.sharedMaterial = startMaterial;
		}
	}

	/// <summary>
	/// Sets the material of the given mesh renderer to the material with the id in the materials list.
	/// </summary>
	/// <param name="id">The id of the materials list.</param>
	public void SetMaterial(int id) {
		if (meshRenderer && id >= 0 && id < materials.Count) {
			meshRenderer.sharedMaterial = materials[id];
		}
	}
}
