namespace CoreScripts

open UnityEngine

type MessageLogger() =
    inherit MonoBehaviour()

    [<DefaultValue>]
    [<SerializeField>]
    val mutable private message: string

    member this.Start() = Debug.Log(this.message)
