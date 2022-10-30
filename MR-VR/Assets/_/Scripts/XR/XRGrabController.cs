using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabController : XRDirectInteractor {
	protected override void OnSelectEntering(SelectEnterEventArgs args) {
		var targetTransform = args.interactableObject.transform;
		attachTransform.position = targetTransform.position;
		attachTransform.rotation = targetTransform.rotation;
		
		base.OnSelectEntering(args);
	}
}
