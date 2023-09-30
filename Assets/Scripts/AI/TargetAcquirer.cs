using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviors
{
    public class TargetAcquirer
    {
        public Unit GetClosestTarget(IUnitPool sampleToSearchFrom, Vector3 referencePosition, float maxSearchDistance, byte factionID)
        {
            float minimalDistance = maxSearchDistance;
            Unit minimalDistanceUnit = null;

            foreach (var unit in sampleToSearchFrom.GetStoredUnits())
            {
                if (unit != null && unit.FactionID != factionID)
                {
                    float currentDistance = Vector3.Distance(referencePosition, unit.transform.position);

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
