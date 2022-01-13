using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CityBuilder;
using System;

public class GridStructureTest
{
    GridStructure structure;
    [OneTimeSetUp]
    public void Init()
    {
        structure = new GridStructure(3, 100, 100);
    }
    #region GridPositionTests
    // A Test behaves as an ordinary method
    [Test]
    public void CalculateGridPositionPasses()
    {
        //Arrange
        Vector3 position = new Vector3(0, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
        // Use the Assert class to test conditions
    }

    // A Test behaves as an ordinary method
    [Test]
    public void CalculateGridPositionFloatsPasses()
    {
        //Arrange
        Vector3 position = new Vector3(2.9f, 0, 2.9f);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreEqual(Vector3.zero, returnPosition);
        // Use the Assert class to test conditions
    }

    // A Test behaves as an ordinary method
    [Test]
    public void CalculateGridPositionFail()
    {
        //Arrange    
        Vector3 position = new Vector3(3.1f, 0, 2.9f);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        //Assert
        Assert.AreNotEqual(Vector3.zero, returnPosition);
        // Use the Assert class to test conditions
    }
    #endregion

    #region GridIndexTests    
    // A Test behaves as an ordinary method
    [Test]
    public void GridIndexTest()
    {
    }
    #endregion

    #region GridGridTests
    // A Test behaves as an ordinary method
    [Test]
    public void PlaceStructure303AndCheckIsTakenPasses()
    {
        //Arrange
        Vector3 position = new Vector3(3, 0, 3);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnGrid(testGameObject, position);
        //Assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructureMINAndCheckIsTakenPasses()
    {
        //Arrange
        Vector3 position = new Vector3(0, 0, 0);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnGrid(testGameObject, position);
        //Assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructureMAXAndCheckIsTakenPasses()
    {
        //Arrange
        Vector3 position = new Vector3(297, 0, 297);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = new GameObject("TestGameObject");
        structure.PlaceStructureOnGrid(testGameObject, position);
        //Assert
        Assert.IsTrue(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
    {
        //Arrange
        Vector3 position = new Vector3(3, 0, 3);
        //Act
        Vector3 returnPosition = structure.CalculateGridPosition(position);
        GameObject testGameObject = null;
        structure.PlaceStructureOnGrid(testGameObject, position);
        //Assert
        Assert.IsFalse(structure.IsCellTaken(position));
    }

    [Test]
    public void PlaceStructureAndCheckIsTakenIndexOutOfBoundsFail()
    {
        //Arrange
        Vector3 position = new Vector3(303, 0, 303);
        //Act        
        //Assert
        Assert.Throws<IndexOutOfRangeException>(() => structure.IsCellTaken(position));
    }
    #endregion
}
