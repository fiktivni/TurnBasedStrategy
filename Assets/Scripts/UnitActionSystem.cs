using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    private event EventHandler OnSelectedUnitChange;

    [SerializeField] private Unit selectedUnit;

    [SerializeField] private LayerMask unitsLayerMask;


    private void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;

            selectedUnit.Move(MouseWorld.GetPosition());
        }
    }

    private bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, unitsLayerMask))
        {
            if (hitInfo.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;

        OnSelectedUnitChange?.Invoke(this, EventArgs.Empty);

        // Does the same thing as this code would.
        //
        //if (OnSelectedUnitChange != null)
        //{
        //    OnSelectedUnitChange(this, EventArgs.Empty);
        //}
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
