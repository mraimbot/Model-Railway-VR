using UnityEngine.XR.Interaction.Toolkit;

public class XRRayController : XRRayInteractor {
	protected override void OnSelectEntering(SelectEnterEventArgs args) {
		base.OnSelectEntering(args);

		if (attachTransform) {
			var targetTransform = args.interactableObject.transform;
			attachTransform.position = targetTransform.position;
			attachTransform.rotation = targetTransform.rotation;
		}
	}
}
