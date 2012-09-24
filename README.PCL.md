Portable Evil DICOM - A DICOM library in C#
===========================================

Copyright (c) 2011-2012 Rex Cardan, Portable Class Library adaptation (c) 2012 Anders Gustafsson, Cureos AB

This project is a Portable Class Library adapted fork of Rex Cardan's original [Evil DICOM](https://github.com/rexcardan/Evil-DICOM) library. 
For general information and tutorials, see [here](http://evildicom.rexcardan.com/).

Applicability
-------------

The _EvilDicom.Core_ Visual Studio solution contains both Rex Cardan's regular _.NET 4_ class library project and the corresponding _Portable
Class Library_ project. The PCL library is completely applicable on the following platforms:

* .NET Framework version 4 and higher
* Silverlight version 4 and higher
* Windows Phone version 4 and higher
* Windows Store Applications

Public API Differences
----------------------

To meet the requirements of the _Portable Class Library_ project, the PCL library public API differs from the regular .NET 4 library as follows:

* `DICOMBinaryReader` and `DICOMBinaryWriter` constructors, `DICOMFileReader.Read`, `DICOMFileReader.ReadFileMetadata` and `DICOMFileWriter.WriteLittleEndian` methods takes a `Stream` argument instead of file path `string`.
* `DICOMNetworkBinaryReader` is excluded due to its dependency to the `Socket` class.
