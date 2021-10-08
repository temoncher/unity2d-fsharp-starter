namespace CoreScripts

open UnityEngine

type TriggerLogger() =
    inherit MonoBehaviour()

    member private this.OnTriggerEnter2D(other: Collider2D) =
        Debug.Log($"Triggered with: {other.gameObject.name}")
