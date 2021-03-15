# NXOpen-Helper

## Description

The NXHelper library contains different classes that simplify working with NXOpen.
What is NXOpen? NXOpen is a collection of APIs that allows you to create custom 
applications for SiemensNX through an open architecture using well-known programming languages 
(C/C++, Visual Basic, C#, Java, and Python).

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
```
## What is Siemens NX?

<kbd>
<img src="/Images/nx.png"/>
</kbd>

<br />

Short and sweet its a CAD Software (computer-aided design) Common types of computer-aided design are metalworking, carpentry, and 3D printing.
[Wikipedia Siemens NX](https://en.wikipedia.org/wiki/Siemens_NX)

## Requirements

To compile the project you need the NXOpen libraries which you can find in your SiemensNX installation folder.
Just create a reference in the project solution.
