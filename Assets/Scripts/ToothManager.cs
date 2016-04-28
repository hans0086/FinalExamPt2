using System.Collections.Generic;
using UnityEngine;

public class ToothManager : MonoBehaviour {
  public List<GameObject> teeth;
  public Color infectionColor;
	public GameObject newTooth;
  public float nextInfectionDelay = 1.0f;
  private float _elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
    // go and store all of the initial positions/transforms of the teeth so that we can spawn new teeth at this location later.
	}
	
	// Update is called once per frame
	void Update () {
    _elapsedTime += Time.deltaTime;
    if(_elapsedTime >= nextInfectionDelay) {
      _elapsedTime = 0.0f;

      InfectTooth();
    }
  }

  public void InfectTooth() {
    if(teeth.Count > 0) {
      for(int attemptedToothCount = 0; attemptedToothCount < teeth.Count; attemptedToothCount++) {

        // Get our infection index.
        int index = Random.Range(0, teeth.Count);
        GameObject selectedTooth = teeth[index];

        // Make sure we're infecting a valid tooth, and not infecting a tooth that's already infected.
        if(selectedTooth != null && /* */ selectedTooth.GetComponent<Infection>() == null) {
          Infection newInfection = selectedTooth.AddComponent<Infection>();
          newInfection.infectedColor = infectionColor;
        }
        else {
          continue;
        }
      }
    }
  }

  public void RemoveTooth(GameObject toothToRemove) {
    // Make sure that we have a tooth to remove.
    if(teeth.Contains(toothToRemove)) {
      // Remove the tooth so that we can populate this index later.
      int toothIndex = teeth.IndexOf(toothToRemove);
      teeth[toothIndex] = null;
    }
  }

  public void SpawnTooth() {
    for(int toothIndex = 0; toothIndex < teeth.Count; toothIndex++) {
      if(teeth[toothIndex] == null) {
        // spawn a tooth here.
      }
    }
  }
}
