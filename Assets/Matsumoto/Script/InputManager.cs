using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	public static Vector3 GetAccSensor() {
		if(Application.isEditor) {

			var gyro = DebugGyroInterface.GetPositionNormalize();
			return gyro;

		}
		else {

			return new Vector3(
				Input.acceleration.x,
				Input.acceleration.y,
				0
				);
		}

	}
}
