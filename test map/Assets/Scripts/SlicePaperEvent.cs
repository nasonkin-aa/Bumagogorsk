using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Slicer2D {
	
	public class SlicePaperEvent : MonoBehaviour {

		void Start () {
			Sliceable2D slicer = GetComponent<Sliceable2D>();
			slicer.AddResultEvent(SliceEvent);
		}
		
		void SliceEvent(Slice2D slice){
			foreach(GameObject g in slice.GetGameObjects()) {
				Vector3 pos = g.transform.position;
				pos.z = Random.Range(pos.z, 50);
				g.transform.position = pos;

				Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
				rb.AddForce(new Vector2(Random.Range(-200, 200), Random.Range(100, 200)));
				rb.AddTorque(Random.Range(-100, 100));

				Sliceable2D slicer = g.GetComponent<Sliceable2D>();
				slicer.enabled = false;
				slicer.gameObject.GetComponent<LineRenderer>().enabled = false;
				slicer.gameObject.AddComponent<PaperFadeAway>();
			}
		}
	}
	
}