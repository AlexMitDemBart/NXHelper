using NXOpen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NXHelper
{
    public class RefsetHelper
    {
        /// <summary>
        /// returns true if a reference set with the passed name exist
        /// </summary>
        /// <param name="workpart"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool RefsetExist(Part workpart, string name)
        {
            List<ReferenceSet> refsetList = workpart.
                    GetAllReferenceSets().Where(x => x.Name.Equals(name)).ToList();
            bool refsetExist = refsetList.Count > 0 ? true : false;
            return refsetExist;
        }

        /// <summary>
        /// if the reference set with the passed name exist, the reference set is returned otherwise null
        /// </summary>
        /// <param name="workpart"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ReferenceSet GetReferenceSet(Part workpart, string name)
        {
            List<ReferenceSet> refsetList = workpart.
                   GetAllReferenceSets().Where(x => x.Name.Equals(name)).ToList();
            return refsetList.First();
        }

        /// <summary>
        /// returns all solid bodies in the passed reference set
        /// </summary>
        /// <param name="workpart"></param>
        /// <param name="refset"></param>
        /// <returns></returns>
        public static List<Body> GetSolidBodiesFromRefset(Part workpart, ReferenceSet refset)
        {
            List<Body> solidBodies = new List<Body>();
            List<NXObject> objList = refset.AskAllDirectMembers().ToList();
            foreach(NXObject obj in objList)
            {
                Body body = TryConvertNxObjectToBody(obj);
                if(body != null && body.IsSolidBody)
                {
                    solidBodies.Add(body);
                }
            }

            return solidBodies;
        }

        public static Body TryConvertNxObjectToBody(NXObject nxObject)
        {
            Body body = null;

            try
            {
                body = (Body)nxObject;
            }
            catch (Exception){}

            return body;
        }
    }
}
