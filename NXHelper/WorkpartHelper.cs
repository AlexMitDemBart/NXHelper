using NXOpen;
using NXOpen.UF;
using System.Collections.Generic;
using static NXOpen.UF.UFWeight;

namespace NXHelper
{
    public class WorkpartHelper
    {
        /// <summary>
        /// returns the mass of the workpart in kilogram
        /// </summary>
        /// <param name="workpart"></param>
        /// <param name="theUFSession"></param>
        /// <returns></returns>
        public static double GetWorkPartMass(Part workpart, UFSession theUFSession)
        {
            Properties properties = new Properties();
            UFWeight.Exceptions expections = new UFWeight.Exceptions();
            bool isAssembly = WorkpartIsAssembly(workpart);

            if (isAssembly)
            {
                theUFSession.Weight.AskProps(workpart.Tag, UFWeight.UnitsType.UnitsKm, out properties);
            }
            else
            {
                theUFSession.Weight.EstabCompProps(workpart.ComponentAssembly.RootComponent.Tag,
                        0.9, true, UFWeight.UnitsType.UnitsKm, out properties, out expections);
            }

            return properties.mass;
        }

        /// <summary>
        /// returns the volume of the passed workpart in cubicmeter
        /// </summary>
        /// <param name="workpart"></param>
        /// <param name="theUFSession"></param>
        /// <returns></returns>
        public static double GetWorkPartVolume(Part workpart, UFSession theUFSession)
        {
            Properties properties = new Properties();
            UFWeight.Exceptions expections = new UFWeight.Exceptions();
            bool isAssembly = WorkpartIsAssembly(workpart);

            if (isAssembly)
            {
                theUFSession.Weight.AskProps(workpart.Tag, UFWeight.UnitsType.UnitsKm, out properties);
            }
            else
            {
                theUFSession.Weight.EstabCompProps(workpart.ComponentAssembly.RootComponent.Tag,
                        0.9, true, UFWeight.UnitsType.UnitsKm, out properties, out expections);
            }

            return properties.volume;
        }

        /// <summary>
        /// returns the mass of the passed reference set in kilogram
        /// </summary>
        /// <param name="refset"></param>
        /// <param name="workpart"></param>
        /// <param name="theSession"></param>
        /// <returns></returns>
        public static double GetRefSetMass(ReferenceSet refset, Part workpart, Session theSession)
        {
            List<Body> solidBodies = RefsetHelper.GetSolidBodiesFromRefset(workpart, refset);
            MeasureManager mManager = theSession.Parts.Display.MeasureManager;
            List<Unit> massUnits = new List<Unit>();

            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Area"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Volume"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Mass"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Length"));
            MeasureBodies measureBodies = mManager.NewMassProperties(massUnits.ToArray(),
                    0.99, solidBodies.ToArray());

            return measureBodies.Mass;
        }

        /// <summary>
        /// returns the volume of the passed reference set in kubicmeter
        /// </summary>
        /// <param name="refset"></param>
        /// <param name="workpart"></param>
        /// <param name="theSession"></param>
        /// <returns></returns>
        public static double GetRefSetVolume(ReferenceSet refset, Part workpart, Session theSession)
        {
            List<Body> solidBodies = RefsetHelper.GetSolidBodiesFromRefset(workpart, refset);
            MeasureManager mManager = theSession.Parts.Display.MeasureManager;
            List<Unit> massUnits = new List<Unit>();

            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Area"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Volume"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Mass"));
            massUnits.Add(theSession.Parts.Display.UnitCollection.GetBase("Length"));
            MeasureBodies measureBodies = mManager.NewMassProperties(massUnits.ToArray(),
                    0.99, solidBodies.ToArray());

            return measureBodies.Volume;
        }

        /// <summary>
        /// returns true when the passed workpart is a assembly
        /// </summary>
        /// <param name="workpart"></param>
        /// <returns></returns>
        public static bool WorkpartIsAssembly(Part workpart)
        {
            bool isAssembly = workpart.ComponentAssembly.RootComponent == null ? false : true;
            return isAssembly;
        }
    }
}
