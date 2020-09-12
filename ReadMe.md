# NXHelper

## Description

The NXHelper library contains different classes that simplify working with NXOpen.


## Code Snippet

simple way to check if a reference set in a workpart exist 
```javascript
 public static bool RefsetExist(Part workpart, string name)
        {
            List<ReferenceSet> refsetList = workpart.
                    GetAllReferenceSets().Where(x => x.Name.Equals(name)).ToList();
            bool refsetExist = refsetList.Count > 0 ? true : false;
            return refsetExist;
        }
}
```