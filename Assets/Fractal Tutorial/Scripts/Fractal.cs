﻿using UnityEngine;
using System.Collections;

public class Fractal : MonoBehaviour {

	public Mesh[] meshes;
	public Material material;

	public float maximumRoationSpeed;
	public float maxTwist;
	public int maxDepth;
	public float childScale;

	[Range(0,1)]
	public float spawnProbability;

	float rotationSpeed;
	int depth;
	Material[,] materials;

	private static Vector3[] childDirections = {
		Vector3.up,
		Vector3.right,
		Vector3.left,
		Vector3.forward,
		Vector3.back
	};

	private static Quaternion[] childOrientations = {
		Quaternion.identity,
		Quaternion.Euler (0f, 0f, -90f),
		Quaternion.Euler (0f, 0f, 90f),
		Quaternion.Euler (90f, 0f, 0f),
		Quaternion.Euler (-90f, 0f, 0f),
	};

	void InitializeMaterials () {
		materials = new Material[maxDepth + 1, 2];
		for (int i = 0; i <= maxDepth; i++)
		{
			float t = i / (maxDepth - 1f);
			t *= t;
			materials[i, 0] = new Material (material);
			materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
			materials[i, 1] = new Material (material);
			materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
		}
		materials[maxDepth, 0].color = Color.magenta;
		materials[maxDepth, 1].color = Color.red;
	}

	void Start () {
		rotationSpeed = Random.Range (-maximumRoationSpeed, maximumRoationSpeed);
		transform.Rotate (Random.Range(0, maxTwist), 0f, 0f);
		if (materials == null)
		{
			InitializeMaterials ();
		}
		gameObject.AddComponent<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Length)];
		gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0, 2)];
		if (depth < maxDepth)
		{
			StartCoroutine (CreateChildren ());
		}

	}
	
	void Initialize (Fractal parent, int childIndex) {
		meshes = parent.meshes;
		materials = parent.materials;
		maxDepth = parent.maxDepth;	
		depth = parent.depth + 1;
		childScale = parent.childScale;
		maxTwist = parent.maxTwist;
		spawnProbability = parent.spawnProbability;
		maximumRoationSpeed = parent.maximumRoationSpeed;
		transform.parent = parent.transform;
		transform.localScale = Vector3.one * childScale;
		transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
		transform.localRotation = childOrientations[childIndex];
	}

	void Update () {
		transform.Rotate (0f, rotationSpeed * Time.deltaTime, 0f);
	}
	
	IEnumerator CreateChildren () {
		for (int i = 0; i < childDirections.Length; i++)
		{
			if (Random.value < spawnProbability)
			{
				yield return new WaitForSeconds (Random.Range (0.1f, 0.5f));
				new GameObject("Fractal Child").AddComponent<Fractal>().Initialize(this, i);
			}
		}
	}

}
