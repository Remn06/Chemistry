using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMolOnClick : MonoBehaviour
{
    public GameObject gameManager;
    public Camera currentCamera;
    public int rotate;
    public int molecule;
    public int changeMoleculePos;
    public int moveMolecule;
    private Vector3 newMoleculePos;
    private MoleculesRotator moleculesRotator;

    private void Start()
    {
        moleculesRotator = gameManager.GetComponent<MoleculesRotator>();
    }

    private void Update()
    {
        if (rotate == 1)
        {
            moleculesRotator.rotationStep = 180;
            RotateMolecule();
        }
        else if (rotate == -1)
        {
            moleculesRotator.rotationStep = -180;
            RotateMolecule();
        }
        else if (changeMoleculePos == -1)
        {
            if (currentCamera.GetComponent<Transform>().position.x > newMoleculePos.x)
            {
                currentCamera.GetComponent<Transform>().position = new Vector3(currentCamera.GetComponent<Transform>().position.x - (60f * Time.deltaTime), 1f, -15f);
            }
        }
        else if (changeMoleculePos == 1)
        {
            if (currentCamera.GetComponent<Transform>().position.x < newMoleculePos.x)
            {
                currentCamera.GetComponent<Transform>().position = new Vector3(currentCamera.GetComponent<Transform>().position.x + (60f * Time.deltaTime), 1f, -15f);
            }
        }
        else if (moveMolecule == -1)
        {
            moleculesRotator.moveStep = -10f;
            moleculesRotator.MoveMolecule();
        }
        else if (moveMolecule == 1)
        {
            moleculesRotator.moveStep = 10f;
            moleculesRotator.MoveMolecule();
        }
    }

    private void RotateMolecule()
    {
        moleculesRotator = gameManager.GetComponent<MoleculesRotator>();
        moleculesRotator.RotateMolecule();
    }

    public void SetRotate(int newRotate)
    { 
        rotate = newRotate;
    }

    public void ChangeMolecule(int newMolecule)
    {
        moleculesRotator.currentMolecule = moleculesRotator.molecules[newMolecule];
        newMoleculePos = moleculesRotator.molecules[newMolecule].GetComponent<Transform>().position;
        if (newMolecule == 0)
        {
            changeMoleculePos = -1;
            Invoke("SetChangeMoleculePos", 1f);
        }
        else if (newMolecule == 1)
        {
            changeMoleculePos = 1;
            Invoke("SetChangeMoleculePos", 1f);
        }
    }

    private void SetChangeMoleculePos()
    {
        changeMoleculePos = 0;
        if (newMoleculePos.x == 60f)
        {
            currentCamera.GetComponent<Transform>().position = new Vector3(60f, 1f, -15f);
        }
        else if (newMoleculePos.x == 0f)
        {
            currentCamera.GetComponent<Transform>().position = new Vector3(0f, 1f, -15f);
        }
    }

    public void SetMoveMolecule(int newMoveMolecule)
    {
        moveMolecule = newMoveMolecule;
    }
}