using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Tooth : MonoBehaviour {
  private ToothManager _toothManager;

  private Material _toothMaterial;
  public Material toothMaterial {
    get {
      if(_toothMaterial == null) {
        Renderer renderer = GetComponent<Renderer>();
        _toothMaterial = renderer.material;
      }

      return _toothMaterial;
    }
  }

  void Start() {
    _toothManager = GetComponentInParent<ToothManager>();
    if(_toothManager == null) {
      throw new System.Exception("ToothManager not found amoung Tooth's parents.");
    }
  }

  public void OnDestroy() {
    _toothManager.RemoveTooth(gameObject);
  }
	public void OnCollisionEnter(Collision collision){
		GameObject otherGO = collision.collider.gameObject;
		if (otherGO.tag == "Sweets") {
			Rigidbody rigidbody = GetComponent<Rigidbody> ();
			rigidbody.isKinematic = false;
			rigidbody.useGravity = true;

			Rigidbody otherGORigidbody = otherGO.GetComponent<Rigidbody>();
			rigidbody.velocity = otherGORigidbody.velocity;
			rigidbody.angularVelocity = otherGORigidbody.angularVelocity;
			//skull.RemoveTooth (this.gameObject);
			Destroy (this.gameObject, 2.0f);
		}
	}
}
