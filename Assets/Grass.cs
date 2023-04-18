using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : Terrain
{
    [SerializeField] List<GameObject> treePrefabList;
    [SerializeField, Range(0, 1)] float treeProbability;

    public void SetTreeProbability(float newProbability)
    {
        this.treeProbability = Mathf.Clamp01(newProbability);
    }

    public override void Generate(int size)
    {
        base.Generate(size);

        var limit = Mathf.FloorToInt((float)size / 2);
        var treeCount = Mathf.FloorToInt((float)size * treeProbability);

        List<int> emptyPosition = new List<int>();
        for (int i = -limit; i <= limit; i++)
        {
            emptyPosition.Add(i);
        }

        for (int i = 0; i < treeCount; i++)
        {
            //memilih posisi kosong secara random
            var randomIndex = Random.Range(0, emptyPosition.Count);
            var pos = emptyPosition[randomIndex];

            // posisi yg terpilih hapus dari daftar posisi kosong
            emptyPosition.RemoveAt(randomIndex);

            SpawnRandomTree(pos);

        }

        // tree di ujung
        SpawnRandomTree(-limit - 1);
        SpawnRandomTree(limit + 1);
    }

    private void SpawnRandomTree(int xPos)
    {
        // pilih prefab pohon random
        var randomIndex = Random.Range(0, treePrefabList.Count);
        var prefab = treePrefabList[randomIndex];

        //set pohon ke posisi yg terpilih
        var tree = Instantiate(
            prefab,
            new Vector3(xPos, 0, z: this.transform.position.z),
            Quaternion.identity,
            transform);
    }
}
