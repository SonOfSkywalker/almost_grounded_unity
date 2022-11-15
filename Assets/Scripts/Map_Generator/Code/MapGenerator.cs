using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

	public enum Drawmode { NoiseMap, ColourMap, Mesh };
	public Drawmode drawmode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	[Range(0,1)]
	public float persistance;


	public int octaves;


	public float lacunarity;
	public int seed;
	public Vector2 offset;

	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;




	public bool autoUpdate;

	public TerrainType[] regions;

	public void GenerateMap()
    {
        float[,] noiseMap= Noise.GenerateNoiseMap(mapWidth, mapHeight, noiseScale, seed, octaves, persistance, lacunarity, offset);

        Color[] colorMap =new Color[mapWidth * mapHeight];
        for(int y=0; y < mapHeight; y++)
        {
        	for(int x=0; x < mapWidth; x++)
        	    {
        	    	float currentHeight = noiseMap[x,y];
        	    	for(int i=0; i < regions.Length; i++)
        	    		{
        	    			if(currentHeight <= regions[i].height)
        	    			{
        	    				colorMap[y*mapWidth +x] = regions[i].colour;

        	    				break;
        	    			}
        	    		}
        	    }

        }

        Display display = FindObjectOfType<Display>();
        if(drawmode == Drawmode.NoiseMap)
        {
        	display.DrawTexture(TextureGenerator.TextureFromNoiseMap(noiseMap));
    	}else if(drawmode == Drawmode.ColourMap)
    	{
        	display.DrawTexture(TextureGenerator.TextureFromColourMap(colorMap, mapWidth, mapHeight));

    	}else if(drawmode == Drawmode.Mesh)
    	{
    		display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve),TextureGenerator.TextureFromColourMap(colorMap, mapWidth, mapHeight) );
    	}
    }

    private void OnValidate()
    {
    	if(mapWidth < 1)
    	{
    		mapWidth =1;
    	}
       	if(mapHeight<1)
    	{
    		mapHeight =1;
    	}

    	if(lacunarity<1)
    	{
    		lacunarity =1;
    	}

    	if(octaves < 1)
    	{
    		octaves =1;
    	}




    }
}

[System.Serializable]
public struct TerrainType
	{
		public string name;
		public float height;
		public Color colour;




	}
