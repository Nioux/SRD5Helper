using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRD5Helper.Views;

public static class Geometries
{
    private static string ShieldPathMarkup = "M256 22C192 70 128 90 32 122c0 112 80 272 224 368 144-96 224-250 224-362-96-32-160-58-224-106z";
    private static string HeartPathMarkup = "M480.25 156.355c0 161.24-224.25 324.43-224.25 324.43S31.75 317.595 31.75 156.355c0-91.41 70.63-125.13 107.77-125.13 77.65 0 116.48 65.72 116.48 65.72s38.83-65.73 116.48-65.73c37.14.01 107.77 33.72 107.77 125.14z";
    private static string HexagonPathMarkup = "M256 21.52l-4.5 2.597L52.934 138.76v234.48L256 490.48l203.066-117.24V138.76L256 21.52z";

    private static Geometry _shieldGeometry = null;
    public static Geometry ShieldGeometry => _shieldGeometry ??= (Geometry)new PathGeometryConverter().ConvertFromInvariantString(ShieldPathMarkup);

    private static Geometry _heartGeometry = null;
    public static Geometry HeartGeometry => _heartGeometry ??= (Geometry)new PathGeometryConverter().ConvertFromInvariantString(HeartPathMarkup);

    private static Geometry _hexagonGeometry = null;
    public static Geometry HexagonGeometry => _hexagonGeometry ??= (Geometry)new PathGeometryConverter().ConvertFromInvariantString(HexagonPathMarkup);
}
