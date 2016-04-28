using UnityEngine;
using UnityEngine.UI;
public class Infection : MonoBehaviour {
  public Color infectedColor = Color.white;
	//private Text healthText = GameObject.Find("Health");
  private Tooth _tooth;
  private Color _oldColor = Color.white;
	private float decayTimer = 0.0f;
  private float _elapsedTime = 0.0f;

  // Use this for initialization
  void Start() {
    FindTooth();
  }

  void FindTooth() {
    _tooth = GetComponent<Tooth>();
    if(_tooth == null) {
      throw new System.Exception("Infection not added to a tooth.");
    }
  }

  // Update is called once per frame
  void Update() {
		if (_elapsedTime < 1.0f) {
			_elapsedTime += Time.deltaTime;

			_tooth.toothMaterial.color = Color.Lerp (_oldColor, infectedColor, _elapsedTime);
			if (_tooth.toothMaterial.color.Equals (infectedColor)) {
				if (decayTimer == 2.0f) {
					decayTimer = 0.0f;

					//int healthAmt = int.Parse (healthText.text);
					//healthAmt -= 5;
					//healthText.text = healthAmt.ToString ();
				}
			}
		}
		
    
  }

  public void OnCollisionEnter(Collision collision) {
    GameObject otherGO = collision.collider.gameObject;
    if(otherGO.tag == "Sweets") {
      Rigidbody rigidbody = GetComponent<Rigidbody>();
      rigidbody.isKinematic = false;
      rigidbody.useGravity = true;

      // Propogate velocity.
      Rigidbody otherGORigidbody = otherGO.GetComponent<Rigidbody>();
      rigidbody.velocity = otherGORigidbody.velocity;
      rigidbody.angularVelocity = otherGORigidbody.angularVelocity;

      // Destroy the game object after 2 seconds.
      Destroy(this /**/, 2.0f);
    }
  }
}
