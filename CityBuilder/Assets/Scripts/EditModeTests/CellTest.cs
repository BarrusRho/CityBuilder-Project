using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CityBuilder;

public class CellTest
{
    #region CellTests
    [Test]
    public void CellSetGameObjectPass()
    {
        Cell cell = new Cell();
        cell.SetConstruction(new GameObject());
        Assert.IsTrue(cell.IsTaken);
    }

    [Test]
    public void CellSetGameObjectNullFail()
    {
        Cell cell = new Cell();
        cell.SetConstruction(null);
        Assert.IsFalse(cell.IsTaken);
    }
    #endregion
}
