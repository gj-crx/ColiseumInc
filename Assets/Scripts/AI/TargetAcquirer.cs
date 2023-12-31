using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class TargetAcquirer
    {
        public Unit GetClosestTarget(IUnitPool sampleToSearchFrom, Vector3 referencePosition, float maxSearchDistance, string factionTag)
        {
            float minimalDistance = maxSearchDistance;
            Unit minimalDistanceUnit = null;

            foreach (var unit in sampleToSearchFrom.GetStoredUnits())
            {
                if (unit != null && unit.FactionTag != factionTag)
                {
                    float currentDistance = Vector3.Distance(referencePosition, unit.LastPosition);

                    if (currentDistance < minimalDistance)
                    {
                        minimalDistanceUnit = unit;
                        minimalDistance = currentDistance;
                    }

                }
            }

            return minimalDistanceUnit;
        }
    }
}
