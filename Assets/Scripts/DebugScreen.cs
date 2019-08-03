using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScreen : MonoBehaviour
{
    World world;
    Text  textComponent;

    float frameRate;
    float timer;

    int halfWorldSizeInVoxel;
    int halfWorldSizeInChunks;

    // Start is called before the first frame update
    void Start()
    {
        world         = GameObject.Find("World").GetComponent<World>();
        textComponent = GetComponent<Text>();

        halfWorldSizeInVoxel  = VoxelData.WorldSizeInVoxels / 2;
        halfWorldSizeInChunks = VoxelData.WorldSizeInChunks / 2;
    }

    // Update is called once per frame
    void Update()
    {
        string debugText = "MyCraft v1.0";
        debugText += "\n" + frameRate + "fps\n";

        debugText += "\nXYZ: " 
            + (Mathf.FloorToInt(world.player.transform.position.x) - halfWorldSizeInVoxel) + "/" 
            + (Mathf.FloorToInt(world.player.transform.position.y)) + "/" 
            + (Mathf.FloorToInt(world.player.transform.position.z) - halfWorldSizeInVoxel);

        debugText += "\nChunk: " + (world.playerChunkCoord.x - halfWorldSizeInChunks) + "/" + (world.playerChunkCoord.z - halfWorldSizeInChunks);



        textComponent.text = debugText;

        if (timer > 1f)
        {
            frameRate = (int)(1f / Time.unscaledDeltaTime);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
