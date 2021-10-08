namespace CoreScripts

open UnityEngine

type Package() =
    inherit MonoBehaviour()

    [<DefaultValue>]
    [<SerializeField>]
    val mutable packageName: string
