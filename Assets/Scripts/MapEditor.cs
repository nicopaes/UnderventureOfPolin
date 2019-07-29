/* 
* Copyright (c) Bravarda Game Studio
* Little Prick Project 2017
*
*/
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

[ExecuteInEditMode]
public class MapEditor : MonoBehaviour
{
		[Header("Load File")]
		public string fileName;

		[Header("Generated Prefabs")]
		[Space]
		public GameObject BackgroundTile;
		public GameObject ForegroundTile;
		[Space]
		public GameObject BorderUpTile;
		public GameObject BorderLeftTile;
		public GameObject BorderDownTile;
		public GameObject BorderRightTile;
		[Space]
		public GameObject UpRightCornerTile;
		public GameObject UpLeftCornerTile;
		public GameObject DownLeftCornerTile;
		public GameObject DownRightCornerTile;
		[Space]
		public GameObject UpLeftConectTile;
		public GameObject UpRightConectTile;
		public GameObject DownLeftConectTile;
		public GameObject DownRightConectTile;


	//private Vector2 mapSize;
	private string jsonString;

		private float posX;
		private float posY;
		//private float posZ;

		int c;
		int t;

		Layers AllLayers;

		private void Awake()
		{
			c = 0;
		}
		void Start()
		{
		}
		public void GenerateMap()
		{
			if (AllLayers != null)
			{
				foreach (Layer layer in AllLayers.layers)
				{
					c = 0;
					if (GameObject.Find(layer.name) == null)
					{
						var layerEmptyObjt = new GameObject(layer.name);
						layerEmptyObjt.transform.parent = GameObject.Find("GeneratedTiles").transform;
					}
					for (int i = 0; i < layer.data.Length; i++)
					{

						if (i % layer.height == 0 && i != 0)
						{
							c++;
						}
						t = i - layer.width * c;

						posX = t * 4.33f;//4.358f;//* 0.850f * 5;
						posY = -c * 4.33f;//4.358f;//* 0.850f * 5;

						if (layer.name == "Base")
						{
							switch (layer.data[i])
							{
								case 1:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newBTile = Instantiate(BackgroundTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newBTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								case 2:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newFTile = Instantiate(ForegroundTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newFTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								case 3:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newBUTile = Instantiate(BorderUpTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newBUTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 4:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newBLTile = Instantiate(BorderLeftTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newBLTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 5:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newBDTile = Instantiate(BorderDownTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newBDTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 6:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									var newBRTile = Instantiate(BorderRightTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newBRTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 7:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(UpRightCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newURTile = Instantiate(UpRightCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newURTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								case 8:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(UpLeftCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newULTile = Instantiate(UpLeftCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newULTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								case 9:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(DownLeftCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newDLTile = Instantiate(DownLeftCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newDLTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								case 10:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(DownRightCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newDRTile = Instantiate(DownRightCornerTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newDRTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 11:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(DownRightConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newDRCTile = Instantiate(DownRightConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newDRCTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 12:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(DownLeftConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newDLCTile = Instantiate(DownLeftConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newDLCTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 13:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(UpLeftConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newULCTile = Instantiate(UpLeftConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newULCTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
							case 14:
									if (GameObject.Find("WallTiles") == null)
									{
										var floorEmpityObj = new GameObject("WallTiles");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
								//Instantiate(UpRightConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform);
									var newURCTile = Instantiate(UpRightConectTile, new Vector2(posX, posY), Quaternion.Euler(0, 0, 0), GameObject.Find("WallTiles").transform) as GameObject;
									newURCTile.GetComponent<SpriteRenderer>().sortingOrder = t + c;
									break;
								/*
								case 0:
									if (GameObject.Find("InvisibleWalls") == null)
									{
										var floorEmpityObj = new GameObject("InvisibleWalls");
										floorEmpityObj.transform.parent = GameObject.Find(layer.name).transform;
									}
									Instantiate(invisibleWall, new Vector3(posX, posY), Quaternion.identity, GameObject.Find("InvisibleWalls").transform);
									break;*/
						}
						}
					}
				}
			}
		}
		public void DeleteMap()
		{
			foreach (Transform child in GameObject.Find("GeneratedTiles").transform)
			{
				DestroyImmediate(child.gameObject);
				//Destroy(child.gameObject);
			}
		}
		public bool CheckChildZero()
		{
			return (transform.childCount == 0);
		}
		public void LoadMap()
		{
			jsonString = File.ReadAllText(Application.dataPath + "/Resources/jsonMaps/" + fileName + ".json");
			if (jsonString != null)
			{
				AllLayers = JsonUtility.FromJson<Layers>(jsonString);
				Debug.Log("Successfully Loaded: " + fileName);
			}
			else
			{
				Debug.Log("MAP FILE NOT FOUND, TRY CHANGING FILE NAME");
			}
		}

		[Serializable]
		public class Layers
		{
			public List<Layer> layers;
		}

		[Serializable]
		public class Layer
		{
			public int[] data;
			public string name;
			public int opacity;
			public string type;
			public bool visible;
			public int width;
			public int height;
			public int x;
			public int y;
		}
	}
