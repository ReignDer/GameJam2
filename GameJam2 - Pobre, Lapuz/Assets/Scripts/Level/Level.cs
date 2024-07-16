using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int levelID;
    public List<Anomaly> anomalies;
    public Level(int levelID, Anomaly anomaly)
    {
        this.levelID = levelID;
        anomalies.Add(anomaly);
    }
}
