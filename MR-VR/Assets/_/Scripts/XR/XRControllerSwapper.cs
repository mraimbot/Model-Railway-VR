using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Swaps between multiple xr controller
/// </summary>
public class XRControllerSwapper : MonoBehaviour {
	[SerializeField]
	[Tooltip("The trigger event that swaps to the next controller.")]
	private InputActionReference trigger;
	
	[SerializeField]
	[Tooltip("The controllers which swap in the given order.")]
	private List<GameObject> controllers;

	[SerializeField]
	[Tooltip("The list-id of the controller which is active at start.")]
	private int activeControllerId;

	private void Start() {
		if (controllers.Count == 0) {
			Debug.LogError("No controllers set.");
			return;
		}

		if (activeControllerId < 0 || activeControllerId >= controllers.Count) {
			Debug.LogWarning("Invalid start id. Start id is out of range and will be set to zero.");
			activeControllerId = 0;
		}
		
		for (var id = 0; id < controllers.Count; id++) {
			controllers[id].SetActive(id == activeControllerId);
		}

		trigger.action.performed += SwapToNextController;
	}
	
	/// <summary>
	/// Swaps to the next xr controller given in the controllers list.
	/// </summary>
	private void SwapToNextController(InputAction.CallbackContext context) {
		controllers[activeControllerId].SetActive(false);

		activeControllerId++;

		if (activeControllerId >= controllers.Count) {
			activeControllerId = 0;
		}
		
		controllers[activeControllerId].SetActive(true);
	}
}
