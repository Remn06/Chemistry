using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculesRotator : MonoBehaviour
{
    public float rotationStep;
    public float moveStep;
    private Vector3 currentMoleculePos;
    public Camera currentCam;
    public GameObject currentMolecule;
    public GameObject[] molecules;

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        currentMolecule = molecules[0];
        currentMoleculePos = currentMolecule.GetComponent<Transform>().position;
        currentCam.GetComponent<Transform>().position = new Vector3(currentMoleculePos.x, 1, -15);
    }

    public void RotateMolecule()
    {
        currentMolecule.GetComponent<Transform>().Rotate(Vector3.up * rotationStep * Time.deltaTime);
    }

    public void MoveMolecule()
    {
        currentMoleculePos = currentMolecule.GetComponent<Transform>().position;
        currentMolecule.GetComponent<Transform>().position = new Vector3(currentMoleculePos.x, currentMoleculePos.y,
        currentMoleculePos.z + (moveStep * Time.deltaTime));
    }
}
