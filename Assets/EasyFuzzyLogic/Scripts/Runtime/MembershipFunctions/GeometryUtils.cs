using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AillieoUtils.EasyFuzzyLogic
{
    public static class GeometryUtils
    {
        public static float AreaOfPolygon(params Vector2[] points)
        {
            return AreaOfPolygon((IEnumerable<Vector2>)points);
        }

        public static Vector2 CentroidOfPolygon(params Vector2[] points)
        {
            return CentroidOfPolygon((IEnumerable<Vector2>)points);
        }

        // https://en.wikipedia.org/wiki/Shoelace_formula#The_polygon_area_formulas
        public static float AreaOfPolygon(IEnumerable<Vector2> points)
        {
            float sum = 0;
            Vector2 last = default;
            bool first = true;
            foreach (var point in points)
            {
                if (first)
                {
                    last = point;
                    first = false;
                    continue;
                }

                sum += (last.x * point.y) - (point.x * last.y);

                last = point;
            }

            return 0.5f * sum;
        }

        // https://en.wikipedia.org/wiki/Centroid#Of_a_polygon
        public static Vector2 CentroidOfPolygon(IEnumerable<Vector2> points)
        {
            float xSum = 0;
            float ySum = 0;
            Vector2 last = default;
            bool first = true;
            foreach (var point in points)
            {
                if (first)
                {
                    last = point;
                    first = false;
                    continue;
                }

                float cross = (last.x * point.y) - (point.x * last.y);
                xSum += (last.x + point.x) * cross;
                ySum += (last.y + point.y) * cross;

                last = point;
            }

            float area = AreaOfPolygon(points);
            return new Vector2(xSum, ySum) / (6 * area);
        }
    }
}
