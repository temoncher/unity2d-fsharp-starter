namespace CoreScripts

open UnityEngine

type StickToTarget() =
    inherit MonoBehaviour()

    [<SerializeField>]
    let _offset = 10f

    [<DefaultValue>]
    [<SerializeField>]
    val mutable private _target: GameObject

    member private this.LateUpdate() =
        let newPosition =
            this._target.transform.position
            + Vector3(0f, 0f, _offset)

        this.transform.SetPositionAndRotation(newPosition, this.transform.rotation)
