using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise 
{
 public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight,float scale,int seed, int octaves, float persistance, float lacunarity, Vector2 offset)
 {  
 	float[,] noiseMap = new float[mapHeight, mapWidth];


 	System.Random prng = new System.Random(seed);
 	Vector2[] octavesOffsets = new Vector2[octaves];
 	for(int i= 0; i< octaves; i++)
 	{	float OffsetsX = prng.Next(-100000, 100000) + offset.x;
 		float OffsetsY = prng.Next(-100000, 100000) + offset.y;
 		octavesOffsets[i]= new Vector2(OffsetsX, OffsetsY);
 	}

 	if(scale <= 0)
 		{scale= 0.0001f;
 	}

 		float maxNoiseHeight = float.MinValue;
 		float minNoiseHeight = float.MaxValue;
 		float halfWidth = mapWidth /2f;
 		float halfHeight = mapHeight /2f;

 	for(int width=0; width< mapWidth; width++)
 		{
 			for(int height=0; height < mapHeight; height++)

 			{
 				float amplitude =1;
 				float frequency =1;
 				float noiseHeight = 0;
 				for(int i = 0; i < octaves; i++) 
 				{
 					float sampleHeight = (height - halfHeight) /scale * frequency + octavesOffsets[i].x;
 					float sampleWidth = (width - halfWidth) /scale * frequency + octavesOffsets[i].y;

 					float perlinValue = 2* Mathf.PerlinNoise(sampleWidth, sampleHeight) - 1; //Perlin Value entre -1 et 1 pour + de naturel 

 					noiseHeight += perlinValue * amplitude;
 					amplitude *= persistance;
 					frequency *= lacunarity;

 				}
 				if(noiseHeight > maxNoiseHeight)
 				{ maxNoiseHeight = noiseHeight;}
 				else if(noiseHeight < minNoiseHeight)
 				{minNoiseHeight= noiseHeight;}

 				noiseMap[height, width] = noiseHeight;
 			}
 		} 


 		for(int width=0; width< mapWidth; width++)
 		{
 			for(int height=0; height < mapHeight; height++)

 			{

 				noiseMap[height,width]=Mathf.InverseLerp(minNoiseHeight,maxNoiseHeight, noiseMap[height, width]);

 			}

 		}
 		return noiseMap;
 	}


 
}
