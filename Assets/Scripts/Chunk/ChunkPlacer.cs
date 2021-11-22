using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChunkPlacer : MonoBehaviour
{
    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;
    //public Chunk FinalChunk;

    public Text Chunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    public LeanToken Token;

    // Start is called before the first frame update
    void Start()
    {
        Main.IsEndless = true;
        Main.ChunkBegin = 0;
        spawnedChunks.Add(FirstChunk);
        Chunk.text = "Distances passed: " + Main.ChunkBegin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Player.position.x > spawnedChunks[spawnedChunks.Count - 1].End.position.x - 15)
        {
            SpawnChunk();
        }

        
    }

    public void SpawnChunk()
    {

        
        Main.ChunkBegin++;
        Chunk.text = "Distances passed: " + Main.ChunkBegin.ToString();
        Token.Value = Main.ChunkBegin.ToString();

        Chunk newChunk = Instantiate(GetRandomChunk());
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

        if(spawnedChunks.Count >= 4){
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }

    private Chunk GetRandomChunk()
    {

        // if(ChunkBegin > 25){
        //     return FinalChunk;
        // }
        
        List<float> chances = new List<float>();

        for (int i = 0; i < ChunkPrefabs.Length; i++)
        {
            chances.Add(ChunkPrefabs[i].ChanceFromDistance.Evaluate(Player.transform.position.x));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if(value < sum)
            {
                return ChunkPrefabs[i];
            }
        }

        return ChunkPrefabs[ChunkPrefabs.Length-1];
    }


    
}
